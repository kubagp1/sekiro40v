using System;
using System.Threading.Tasks;
using EmbedIO.WebSockets;
using Newtonsoft.Json;

namespace Sekiro40v;

public class DeathCounter
{
    public enum ECounterAlign
    {
        Left,
        Right
    }

    public enum CounterUpdateAction
    {
        Counter,
        FontFamily,
        Color,
        Align,
        ImageMode,
        ImageOffset,
        ImageSize
    }

    public enum ImageMode
    {
        Hide,
        Left,
        Right
    }

    public Config.DeathCounter Config;

    public CounterWebSocketModule Module;
    public StatisticsManager.DeathCounter Statistics;

    public DeathCounter(Config.DeathCounter config, StatisticsManager.DeathCounter statistics)
    {
        Config = config;
        Statistics = statistics;

        Module = new CounterWebSocketModule("/counter/socket", this);

        CounterChangedEventHandler += DeathCounter_CounterChangedEventHandler;
    }

    public event EventHandler<CounterChangedEventArgs> CounterChangedEventHandler;

    private void DeathCounter_CounterChangedEventHandler(object sender, CounterChangedEventArgs e)
    {
        Module.BroadcastUpdate(new CounterUpdate
        {
            Action = CounterUpdateAction.Counter,
            Value = Counter
        });
    }

    private class ImageOffset
    {
        public int X;
        public int Y;
    }

    public class CounterChangedEventArgs : EventArgs
    {
        public int Value;
    }

    public class CounterUpdate
    {
        public CounterUpdateAction Action { get; set; }
        public object Value { get; set; }
    }

    public class CounterWebSocketModule : WebSocketModule
    {
        private readonly DeathCounter _deathCounter;

        public CounterWebSocketModule(string urlPath, DeathCounter deathCounter) : base(urlPath, true)
        {
            _deathCounter = deathCounter;
        }

        protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] buffer,
            IWebSocketReceiveResult result)
        {
            return Task.CompletedTask;
        }

        protected override Task OnClientConnectedAsync(IWebSocketContext context)
        {
            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                Action = CounterUpdateAction.Counter,
                Value = _deathCounter.Counter
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                Action = CounterUpdateAction.Align,
                Value = _deathCounter.CounterAlign
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                Action = CounterUpdateAction.Color,
                Value = _deathCounter.CounterColor
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                Action = CounterUpdateAction.FontFamily,
                Value = _deathCounter.CounterFontFamily
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                Action = CounterUpdateAction.ImageMode,
                Value = _deathCounter.CounterImageMode
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                Action = CounterUpdateAction.ImageOffset,
                Value = new ImageOffset
                {
                    X = _deathCounter.CounterImageOffsetX,
                    Y = _deathCounter.CounterImageOffsetY
                }
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                Action = CounterUpdateAction.ImageSize,
                Value = _deathCounter.CounterImageSize
            }));

            return base.OnClientConnectedAsync(context);
        }

        public void BroadcastUpdate(CounterUpdate update)
        {
            BroadcastAsync(JsonConvert.SerializeObject(update));
        }
    }

    #region Getters Setters

    public int Counter
    {
        get => Statistics.Deaths;
        set
        {
            if (Statistics.Deaths != value)
            {
                Statistics.Deaths = value;
                CounterChangedEventHandler?.Invoke(this, new CounterChangedEventArgs { Value = value });
            }
        }
    }

    public string CounterFontFamily
    {
        get => Config.CounterFontFamily;
        set
        {
            if (value != Config.CounterFontFamily)
            {
                Config.CounterFontFamily = value;
                Module.BroadcastUpdate(new CounterUpdate
                    { Action = CounterUpdateAction.FontFamily, Value = CounterFontFamily });
            }
        }
    }

    public string CounterColor
    {
        get => Config.CounterColor;
        set
        {
            var changed = value != Config.CounterColor;
            Config.CounterColor = value;
            if (changed)
                Module.BroadcastUpdate(new CounterUpdate { Action = CounterUpdateAction.Color, Value = CounterColor });
        }
    }

    public ECounterAlign CounterAlign
    {
        get => Config.CounterAlign;
        set
        {
            if (value != Config.CounterAlign)
            {
                Config.CounterAlign = value;
                Module.BroadcastUpdate(new CounterUpdate { Action = CounterUpdateAction.Align, Value = CounterAlign });
            }
        }
    }

    public ImageMode CounterImageMode
    {
        get => Config.CounterImageMode;
        set
        {
            if (Config.CounterImageMode != value)
            {
                Config.CounterImageMode = value;
                Module.BroadcastUpdate(new CounterUpdate
                    { Action = CounterUpdateAction.ImageMode, Value = CounterImageMode });
            }
        }
    }

    public int CounterImageOffsetX
    {
        get => Config.CounterImageOffsetX;
        set
        {
            if (Config.CounterImageOffsetX != value)
            {
                Config.CounterImageOffsetX = value;
                Module.BroadcastUpdate(new CounterUpdate
                {
                    Action = CounterUpdateAction.ImageOffset,
                    Value = new ImageOffset { X = CounterImageOffsetX, Y = CounterImageOffsetY }
                });
            }
        }
    }

    public int CounterImageOffsetY
    {
        get => Config.CounterImageOffsetY;
        set
        {
            if (Config.CounterImageOffsetY != value)
            {
                Config.CounterImageOffsetY = value;
                Module.BroadcastUpdate(new CounterUpdate
                {
                    Action = CounterUpdateAction.ImageOffset,
                    Value = new ImageOffset { X = CounterImageOffsetX, Y = CounterImageOffsetY }
                });
            }
        }
    }

    public int CounterImageSize
    {
        get => Config.CounterImageSize;
        set
        {
            if (Config.CounterImageSize != value)
            {
                Config.CounterImageSize = value;
                Module.BroadcastUpdate(new CounterUpdate
                    { Action = CounterUpdateAction.ImageSize, Value = CounterImageSize });
            }
        }
    }

    #endregion Getters Setters
}