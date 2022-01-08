using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sekiro40v
{
    public partial class MemoryHook
    {
        public int currentHP { get; private set; }
        public int maxHP = 0;

        public event EventHandler CurrentHPChanged;

        public event EventHandler MaxHPChanged;

        public class DamageEventHandlerEventArgs : EventArgs
        {
            public int currentHP;
            public int damage;
            public int maxHP;
        }

        public event EventHandler<DamageEventHandlerEventArgs> DamageEventHandler;

        public event EventHandler DeathEventHandler;

        public void StartLoop()
        {
            Task.Run(() =>
                {
                    int lastHP = 0;

                    while (true)
                    {
                        DateTime startTime = DateTime.Now;

                        try
                        {
                            var reading = ReadMemory();

                            if (reading != lastHP)
                            {
                                currentHP = reading.Value; // Exception will be thrown here if reading is null
                                CurrentHPChanged?.Invoke(this, EventArgs.Empty);

                                if (currentHP < lastHP)
                                {
                                    DamageEventHandler?.Invoke(this, new DamageEventHandlerEventArgs { currentHP = currentHP, damage = lastHP - currentHP, maxHP = maxHP });
                                    if (currentHP == 0)
                                        DeathEventHandler?.Invoke(this, EventArgs.Empty);
                                }
                                if (currentHP > maxHP)
                                {
                                    maxHP = currentHP;
                                    MaxHPChanged?.Invoke(this, EventArgs.Empty);
                                }
                            }

                            lastHP = currentHP;
                        }
                        catch
                        {
                            maxHP = 0;
                            lastHP = 0;

                            Thread.Sleep(1000);
                            continue;
                        }

                        TimeSpan executionTime = DateTime.Now - startTime;

                        if (Config.maxRPM <= 0)
                            Config.maxRPM = 1;
                        int timeout = (int)(1000 / Config.maxRPM - executionTime.TotalMilliseconds);

                        if (timeout >= 1)
                            Thread.Sleep(timeout);
                    }
                }
            );
        }
    }
}