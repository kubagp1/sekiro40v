using System;

namespace Sekiro40v;

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
    public DeathCounter DeathCounter;
    public MemoryHook MemoryHook;
    public PainSender PainSender;

    public Config.General Settings;
    public StatisticsManager StatisticsManager;
    public WebServerManager WebServerManager;

    public App()
    {
        Config = new Config();
        StatisticsManager = new StatisticsManager();

        Settings = Config.Settings.General;

        MemoryHook = new MemoryHook(Config.Settings.MemoryHook);
        DeathCounter = new DeathCounter(Config.Settings.DeathCounter, StatisticsManager.Statistics.DeathCounter);
        WebServerManager = new WebServerManager(Config.Settings.General, DeathCounter.Module);
        PainSender = new PainSender(Config.Settings.PainSender, StatisticsManager.Statistics.PainSender);

        MemoryHook.DeathEventHandler += MemoryHook_DeathEventHandler;
        MemoryHook.DamageEventHandler += MemoryHook_DamageEventHandler;
    }

    private void MemoryHook_DamageEventHandler(object sender, MemoryHook.DamageEventHandlerEventArgs e)
    {
        if (Settings.ShockOnDamage)
        {
            var percentage = (double)e.Damage / e.MaxHp;
            switch (Settings.ShockOnDamageMode)
            {
                case ShockOnDamageMode.ScaleBoth:
                    PainSender.SendShock(
                        (int)(Settings.ShockOnDamageStrength * percentage),
                        (int)(Settings.ShockOnDamageDuration * percentage)
                    );
                    break;
                case ShockOnDamageMode.ScaleDuration:
                    PainSender.SendShock(
                        Settings.ShockOnDamageStrength,
                        (int)(Settings.ShockOnDamageDuration * percentage)
                    );
                    break;
                case ShockOnDamageMode.ScaleStrength:
                    PainSender.SendShock(
                        (int)(Settings.ShockOnDamageStrength * percentage),
                        Settings.ShockOnDamageDuration
                    );
                    break;
                case ShockOnDamageMode.StaticBoth:
                    PainSender.SendShock(
                        Settings.ShockOnDamageStrength,
                        Settings.ShockOnDamageDuration
                    );
                    break;
            }
        }
    }

    private void MemoryHook_DeathEventHandler(object sender, EventArgs e)
    {
        DeathCounter.Counter++;

        if (Settings.ShockOnDeath) PainSender.SendShock(Settings.ShockOnDeathStrength, Settings.ShockOnDeathDuration);
    }
}