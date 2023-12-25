using System;
using System.Threading.Tasks;
using EmbedIO.WebSockets;
using Newtonsoft.Json;

namespace Sekiro40v;

public class DeathCounter
{
    public enum CounterAlign
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

        //counterAlign = CounterAlign.Right;
        //counterColor = "#CB0000";
        //counterFontFamily = "Architects Daughter";
        //counterImageOffsetX = 8;
        //counterImageOffsetY = 3;
        //counterImageSize = 59;
        //counterImageMode = ImageMode.Right;

        CounterChangedEventHandler += DeathCounter_CounterChangedEventHandler;
    }

    public event EventHandler<CounterChangedEventArgs> CounterChangedEventHandler;

    private void DeathCounter_CounterChangedEventHandler(object sender, CounterChangedEventArgs e)
    {
        Module.BroadcastUpdate(new CounterUpdate
        {
            action = CounterUpdateAction.Counter,
            value = Counter
        });
    }

    private class ImageOffset
    {
        public int x;
        public int y;
    }

    public class CounterChangedEventArgs : EventArgs
    {
        public int value;
    }

    public class CounterUpdate
    {
        public CounterUpdateAction action { get; set; }
        public object value { get; set; }
    }

    public class CounterWebSocketModule : WebSocketModule
    {
        private readonly DeathCounter DeathCounter;

        public CounterWebSocketModule(string urlPath, DeathCounter deathCounter) : base(urlPath, true)
        {
            DeathCounter = deathCounter;
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
                action = CounterUpdateAction.Counter,
                value = DeathCounter.Counter
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                action = CounterUpdateAction.Align,
                value = DeathCounter.counterAlign
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                action = CounterUpdateAction.Color,
                value = DeathCounter.counterColor
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                action = CounterUpdateAction.FontFamily,
                value = DeathCounter.counterFontFamily
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                action = CounterUpdateAction.ImageMode,
                value = DeathCounter.counterImageMode
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                action = CounterUpdateAction.ImageOffset,
                value = new ImageOffset
                {
                    x = DeathCounter.counterImageOffsetX,
                    y = DeathCounter.counterImageOffsetY
                }
            }));

            SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate
            {
                action = CounterUpdateAction.ImageSize,
                value = DeathCounter.counterImageSize
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
        get => Statistics.deaths;
        set
        {
            if (Statistics.deaths != value)
            {
                Statistics.deaths = value;
                CounterChangedEventHandler?.Invoke(this, new CounterChangedEventArgs { value = value });
            }
        }
    }

    public string counterFontFamily
    {
        get => Config.counterFontFamily;
        set
        {
            if (value != Config.counterFontFamily)
            {
                Config.counterFontFamily = value;
                Module.BroadcastUpdate(new CounterUpdate
                    { action = CounterUpdateAction.FontFamily, value = counterFontFamily });
            }
        }
    }

    public string counterColor
    {
        get => Config.counterColor;
        set
        {
            var changed = value != Config.counterColor;
            Config.counterColor = value;
            if (changed)
                Module.BroadcastUpdate(new CounterUpdate { action = CounterUpdateAction.Color, value = counterColor });
        }
    }

    public CounterAlign counterAlign
    {
        get => Config.counterAlign;
        set
        {
            if (value != Config.counterAlign)
            {
                Config.counterAlign = value;
                Module.BroadcastUpdate(new CounterUpdate { action = CounterUpdateAction.Align, value = counterAlign });
            }
        }
    }

    public ImageMode counterImageMode
    {
        get => Config.counterImageMode;
        set
        {
            if (Config.counterImageMode != value)
            {
                Config.counterImageMode = value;
                Module.BroadcastUpdate(new CounterUpdate
                    { action = CounterUpdateAction.ImageMode, value = counterImageMode });
            }
        }
    }

    public int counterImageOffsetX
    {
        get => Config.counterImageOffsetX;
        set
        {
            if (Config.counterImageOffsetX != value)
            {
                Config.counterImageOffsetX = value;
                Module.BroadcastUpdate(new CounterUpdate
                {
                    action = CounterUpdateAction.ImageOffset,
                    value = new ImageOffset { x = counterImageOffsetX, y = counterImageOffsetY }
                });
            }
        }
    }

    public int counterImageOffsetY
    {
        get => Config.counterImageOffsetY;
        set
        {
            if (Config.counterImageOffsetY != value)
            {
                Config.counterImageOffsetY = value;
                Module.BroadcastUpdate(new CounterUpdate
                {
                    action = CounterUpdateAction.ImageOffset,
                    value = new ImageOffset { x = counterImageOffsetX, y = counterImageOffsetY }
                });
            }
        }
    }

    public int counterImageSize
    {
        get => Config.counterImageSize;
        set
        {
            if (Config.counterImageSize != value)
            {
                Config.counterImageSize = value;
                Module.BroadcastUpdate(new CounterUpdate
                    { action = CounterUpdateAction.ImageSize, value = counterImageSize });
            }
        }
    }

    #endregion Getters Setters
}