using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Reloaded.Memory.Sources;

namespace Sekiro40v;

public enum MemoryHookStatus
{
    Searching,
    Ready,
    Starting
}

public partial class MemoryHook
{
    public readonly Config.MemoryHook Config;
    private nint _baseAddress;
    private Task _currentSearchingTask;
    private ExternalMemory _externalMemory;
    private MemoryHookStatus _status;

    public Process Process;

    public MemoryHook(Config.MemoryHook config)
    {
        Config = config;

        Status = MemoryHookStatus.Starting;

        RestartSearchingTask();
        StartLoop();
    }

    public string ProcessName
    {
        get => Config.ProcessName;
        set
        {
            if (Config.ProcessName == value) return;
            Config.ProcessName = value;
            if (_currentSearchingTask is not null &&
                _currentSearchingTask
                    .IsCompleted) // the "is not null" part is here in case processName gets changed before any searching task is started
                RestartSearchingTask();
        }
    }

    public MemoryHookStatus Status
    {
        get => _status;
        private set
        {
            _status = value;

            StatusChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler StatusChanged;

    private void WaitForProcess()
    {
        try
        {
            Status = MemoryHookStatus.Searching;

            Process[] processes;
            do
            {
                processes = Process.GetProcessesByName(ProcessName);
                if (processes.Length == 0)
                    Thread.Sleep(1000);
            } while (processes.Length < 1);

            Process = processes[0];

            _baseAddress = Process.MainModule.BaseAddress;

            _externalMemory = new ExternalMemory(Process);

            Status = MemoryHookStatus.Ready;
        }
        catch (Exception)
        {
            WaitForProcess();
        }
    }

    private int? ReadMemory()
    {
        try
        {
            _externalMemory.Read(nint.Add(_baseAddress, Config.Offset), out int value);
            return value;
        }
        catch (Exception)
        {
            if (_currentSearchingTask.IsCompleted) RestartSearchingTask();

            return null;
        }
    }

    private void RestartSearchingTask()
    {
        // we are nulling here because we don't want anything to read memory of old process before new one is found
        Process = null;
        _externalMemory = null;
        // baseAddress should technically be nulled here but who cares

        _currentSearchingTask = Task.Run(WaitForProcess);
    }
}