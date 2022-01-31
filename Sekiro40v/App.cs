using System;
using System.Diagnostics;

namespace Sekiro40v
{
    public class App
    {
        public Config Config;
        public StatisticsManager StatisticsManager;
        public MemoryHook memoryHook;
        public DeathCounter deathCounter;
        public WebServerManager webServerManager;
        public PainSender painSender;

        public App()
        {
            Config = new();
            StatisticsManager = new();

            memoryHook = new(Config.settings.memoryHook);
            deathCounter = new(Config.settings.deathCounter, StatisticsManager.statistics.deathCounter);

            memoryHook.DeathEventHandler += MemoryHook_DeathEventHandler;

            webServerManager = new(Config.settings.general, deathCounter.Module);

            painSender = new(Config.settings.painSender, StatisticsManager.statistics.painSender);
        }

        private void MemoryHook_DeathEventHandler(object sender, EventArgs e)
        {
            deathCounter.Counter++;
        }
    }
}