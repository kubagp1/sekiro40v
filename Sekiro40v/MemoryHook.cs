﻿using System;
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
    private Task _currentSearchingTask;
    private ExternalMemory _externalMemory;
    private MemoryHookStatus _status;

    public MemoryHook(Config.MemoryHook config)
    {
        Config = config;

        Status = MemoryHookStatus.Starting;

        RestartSearchingTask();
        StartLoop();
    }

    public Process Process { get; private set; }

    public string ProcessName
    {
        get => Config.ProcessName;
        set
        {
            if (Config.ProcessName == value) return;
            Config.ProcessName = value;
            if (_currentSearchingTask is not null &&
                _currentSearchingTask.IsCompleted)
                // the "is not null" part is here in case ProcessName gets changed before any searching task is started
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
            if (Process.MainModule is null) throw new Exception("MainModule is null");

            _externalMemory.Read(nint.Add(Process.MainModule.BaseAddress, Config.Offset), out int value);
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
        // we don't want anything to read memory of the old process before a new one is found
        Process = null;
        _externalMemory = null;

        _currentSearchingTask = Task.Run(WaitForProcess);
    }
}