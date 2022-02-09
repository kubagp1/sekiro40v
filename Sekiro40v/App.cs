using System;
using System.Diagnostics;

namespace Sekiro40v
{
    public enum ShockOnDamageMode
    {
        ScaleStrength,
        ScaleDuration,
        ScaleBoth,
        StaticBoth
    }

    public class App
    {
        public Config Config;
        public StatisticsManager StatisticsManager;
        public MemoryHook memoryHook;
        public DeathCounter deathCounter;
        public WebServerManager webServerManager;
        public PainSender painSender;

        public Config.General settings;

        public App()
        {
            Config = new();
            StatisticsManager = new();

            settings = Config.settings.general;

            memoryHook = new(Config.settings.memoryHook);
            deathCounter = new(Config.settings.deathCounter, StatisticsManager.statistics.deathCounter);
            webServerManager = new(Config.settings.general, deathCounter.Module);
            painSender = new(Config.settings.painSender, StatisticsManager.statistics.painSender);

            memoryHook.DeathEventHandler += MemoryHook_DeathEventHandler;
            memoryHook.DamageEventHandler += MemoryHook_DamageEventHandler;
        }

        private void MemoryHook_DamageEventHandler(object sender, MemoryHook.DamageEventHandlerEventArgs e)
        {
            if (settings.shockOnDamage)
            {
                double percentage = (double)e.damage / e.maxHP;
                switch (settings.shockOnDamageMode)
                {
                    case ShockOnDamageMode.ScaleBoth:
                        painSender.SendShock(
                            (int)(settings.shockOnDamageStrength * percentage),
                            (int)(settings.shockOnDamageDuration * percentage)
                            );
                        break;
                    case ShockOnDamageMode.ScaleDuration:
                        painSender.SendShock(
                            settings.shockOnDamageStrength,
                            (int)(settings.shockOnDamageDuration * percentage)
                            );
                        break;
                    case ShockOnDamageMode.ScaleStrength:
                        painSender.SendShock(
                            (int)(settings.shockOnDamageStrength * percentage),
                            settings.shockOnDamageDuration
                            );
                        break;
                    case ShockOnDamageMode.StaticBoth:
                        painSender.SendShock(
                            settings.shockOnDamageStrength,
                            settings.shockOnDamageDuration
                            );
                        break;
                }
            }
        }

        private void MemoryHook_DeathEventHandler(object sender, EventArgs e)
        {
            deathCounter.Counter++;

            if (settings.shockOnDeath)
            {
                painSender.SendShock(settings.shockOnDeathStrength, settings.shockOnDeathDuration);
            }
        }
    }
}