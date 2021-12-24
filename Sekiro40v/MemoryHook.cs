using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Reloaded.Memory.Sources;

namespace Sekiro40v
{
    public class MemoryHook
    {
        public Process process;
        public ExternalMemory externalMemory;
        public IntPtr baseAddress;
        private Task currentSearchingTask;

        public int offset = 64535204;

        private string _processName;

        public string processName
        {
            get
            {
                return _processName;
            }
            set
            {
                if (_processName != value)
                {
                    _processName = value;
                    if (currentSearchingTask is not null && currentSearchingTask.IsCompleted) // the "is not null" part is here in case processName gets changed before any searching task is started
                    {
                        RestartSearchingTask();
                    }
                }
            }
        }

        public MemoryHook()
        {
            processName = "sekir";

            RestartSearchingTask();
        }

        private void WaitForProcess()
        {
            Debug.WriteLine("Started looking for process");

            Process[] processes;
            do
            {
                processes = Process.GetProcessesByName(processName);
            }
            while (processes.Length < 1);

            Debug.WriteLine("Found process!");

            process = processes[0];

            baseAddress = process.MainModule.BaseAddress;

            externalMemory = new ExternalMemory(process);
        }

        public int? ReadMemory()
        {
            Debug.WriteLine("Attempted to read memory");
            try
            {
                externalMemory.Read(IntPtr.Add(baseAddress, offset), out int value);
                return value;
            }
            catch
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