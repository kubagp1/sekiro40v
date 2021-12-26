using System;
using System.Diagnostics;

namespace Sekiro40v
{
    public class App
    {
        public MemoryHook memoryHook;
        public DeathCounter deathCounter;
        public WebServerManager webServerManager;

        public App()
        {
            memoryHook = new();
            deathCounter = new();

            memoryHook.DeathEventHandler += MemoryHook_DeathEventHandler;

            webServerManager = new(deathCounter.Module);
        }

        private void MemoryHook_DeathEventHandler(object sender, EventArgs e)
        {
            deathCounter.Counter++;
        }
    }
}