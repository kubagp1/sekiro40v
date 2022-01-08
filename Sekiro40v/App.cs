using System;
using System.Diagnostics;

namespace Sekiro40v
{
    public class App
    {
        public Config Config;
        public MemoryHook memoryHook;
        public DeathCounter deathCounter;
        public WebServerManager webServerManager;

        public App()
        {
            Config = new();

            memoryHook = new(Config.settings.memoryHook);
            deathCounter = new(Config.settings.deathCounter);

            memoryHook.DeathEventHandler += MemoryHook_DeathEventHandler;

            webServerManager = new(Config.settings.general, deathCounter.Module);
        }

        private void MemoryHook_DeathEventHandler(object sender, EventArgs e)
        {
            deathCounter.Counter++;
        }
    }
}