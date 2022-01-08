using Reloaded.Memory.Sources;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Sekiro40v
{
    public enum MemoryHookStatus
    {
        Searching,
        Ready,
        Starting
    }

    public partial class MemoryHook
    {
        public Config.MemoryHook Config;

        public Process process;
        private ExternalMemory externalMemory;
        private IntPtr baseAddress;
        private Task currentSearchingTask;

        public string processName
        {
            get { return Config.processName; }
            set
            {
                if (Config.processName != value)
                {
                    Config.processName = value;
                    if (currentSearchingTask is not null && currentSearchingTask.IsCompleted) // the "is not null" part is here in case processName gets changed before any searching task is started
                    {
                        RestartSearchingTask();
                    }
                }
            }
        }

        public event EventHandler StatusChanged;

        private MemoryHookStatus _status;

        public MemoryHookStatus status
        {
            get { return _status; }
            set
            {
                _status = value;

                StatusChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public MemoryHook(Config.MemoryHook config)
        {
            this.Config = config;

            status = MemoryHookStatus.Starting;

            RestartSearchingTask();
            StartLoop();
        }

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
                }
                while (processes.Length < 1);

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
                externalMemory.Read(IntPtr.Add(baseAddress, Config.offset), out int value);
                return value;
            }
            catch (Exception)
            {
                if (currentSearchingTask.IsCompleted)
                {
                    RestartSearchingTask();
                }

                return null;
            }
        }

        private void RestartSearchingTask()
        {
            // we are nulling here because we don't want anything to read memory of old process before new one is found
            process = null;
            externalMemory = null;
            // baseAddress should technically be nulled here but who cares

            currentSearchingTask = Task.Run(() =>
            {
                WaitForProcess();
            });
        }
    }
}