using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sekiro40v;

public partial class MemoryHook
{
    public int MaxHp;
    public int CurrentHp { get; private set; }

    public event EventHandler CurrentHpChanged;

    public event EventHandler MaxHpChanged;

    public event EventHandler<DamageEventHandlerEventArgs> DamageEventHandler;

    public event EventHandler DeathEventHandler;

    private void StartLoop()
    {
        Task.Run(() =>
            {
                var lastHp = 0;

                while (true)
                {
                    var startTime = DateTime.Now;

                    try
                    {
                        var reading = ReadMemory();

                        if (reading != lastHp)
                        {
                            CurrentHp = reading.Value; // Exception will be thrown here if reading is null
                            CurrentHpChanged?.Invoke(this, EventArgs.Empty);

                            if (CurrentHp < lastHp)
                            {
                                DamageEventHandler?.Invoke(this,
                                    new DamageEventHandlerEventArgs
                                    {
                                        Damage = lastHp - CurrentHp, MaxHp = MaxHp
                                    });
                                if (CurrentHp == 0)
                                    DeathEventHandler?.Invoke(this, EventArgs.Empty);
                            }

                            if (CurrentHp > MaxHp)
                            {
                                MaxHp = CurrentHp;
                                MaxHpChanged?.Invoke(this, EventArgs.Empty);
                            }
                        }

                        lastHp = CurrentHp;
                    }
                    catch
                    {
                        MaxHp = 0;
                        lastHp = 0;

                        Thread.Sleep(1000);
                        continue;
                    }

                    var executionTime = DateTime.Now - startTime;

                    if (Config.MaxRps <= 0)
                        Config.MaxRps = 1;
                    var timeout = (int)(1000 / Config.MaxRps - executionTime.TotalMilliseconds);

                    if (timeout >= 1)
                        Thread.Sleep(timeout);
                }
            }
        );
    }

    public class DamageEventHandlerEventArgs : EventArgs
    {
        public int Damage;
        public int MaxHp;
    }
}