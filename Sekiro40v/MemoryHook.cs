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
    private MemoryHookStatus _status;
    private nint baseAddress;
    public Config.MemoryHook Config;
    private Task currentSearchingTask;
    private ExternalMemory externalMemory;

    public Process process;

    public MemoryHook(Config.MemoryHook config)
    {
        Config = config;

        status = MemoryHookStatus.Starting;

        RestartSearchingTask();
        StartLoop();
    }

    public string processName
    {
        get => Config.processName;
        set
        {
            if (Config.processName != value)
            {
                Config.processName = value;
                if (currentSearchingTask is not null &&
                    currentSearchingTask
                        .IsCompleted) // the "is not null" part is here in case processName gets changed before any searching task is started
                    RestartSearchingTask();
            }
        }
    }

    public MemoryHookStatus status
    {
        get => _status;
        set
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
            status = MemoryHookStatus.Searching;

            Process[] processes;
            do
            {
                processes = Process.GetProcessesByName(processName);
                if (processes.Length == 0)
                    Thread.Sleep(1000);
            } while (processes.Length < 1);

            process = processes[0];

            baseAddress = process.MainModule.BaseAddress;

            externalMemory = new ExternalMemory(process);

            status = MemoryHookStatus.Ready;
        }
        catch (Exception)
        {
            WaitForProcess();
        }
    }

    public int? ReadMemory()
    {
        try
        {
            externalMemory.Read(nint.Add(baseAddress, Config.offset), out int value);
            return value;
        }
        catch (Exception)
        {
            if (currentSearchingTask.IsCompleted) RestartSearchingTask();

            return null;
        }
    }

    private void RestartSearchingTask()
    {
        // we are nulling here because we don't want anything to read memory of old process before new one is found
        process = null;
        externalMemory = null;
        // baseAddress should technically be nulled here but who cares

        currentSearchingTask = Task.Run(() => { WaitForProcess(); });
    }
}