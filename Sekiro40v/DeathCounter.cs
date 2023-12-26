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

    private readonly Config.DeathCounter _config;

    public readonly CounterWebSocketModule WebSocketModule;
    private readonly StatisticsManager.DeathCounter _statistics;

    public DeathCounter(Config.DeathCounter config, StatisticsManager.DeathCounter statistics)
    {
        _config = config;
        _statistics = statistics;

        WebSocketModule = new CounterWebSocketModule("/counter/socket", this);

        CounterChangedEventHandler += DeathCounter_CounterChangedEventHandler;
    }

    public event EventHandler<CounterChangedEventArgs> CounterChangedEventHandler;

    private void DeathCounter_CounterChangedEventHandler(object sender, CounterChangedEventArgs e)
    {
        WebSocketModule.BroadcastUpdate(new CounterUpdate
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
        get => _statistics.Deaths;
        set
        {
            if (_statistics.Deaths == value) return;
            
            _statistics.Deaths = value;
            CounterChangedEventHandler?.Invoke(this, new CounterChangedEventArgs { Value = value });
        }
    }

    public string CounterFontFamily
    {
        get => _config.CounterFontFamily;
        set
        {
            if (value == _config.CounterFontFamily) return;
            
            _config.CounterFontFamily = value;
            WebSocketModule.BroadcastUpdate(new CounterUpdate
                { Action = CounterUpdateAction.FontFamily, Value = CounterFontFamily });
        }
    }

    public string CounterColor
    {
        get => _config.CounterColor;
        set
        {
            // TODO: Why is this one using a 'checked' variable?
            var changed = value != _config.CounterColor;
            _config.CounterColor = value;
            if (changed)
                WebSocketModule.BroadcastUpdate(new CounterUpdate { Action = CounterUpdateAction.Color, Value = CounterColor });
        }
    }

    public ECounterAlign CounterAlign
    {
        get => _config.CounterAlign;
        set
        {
            if (value == _config.CounterAlign) return;
            
            _config.CounterAlign = value;
            WebSocketModule.BroadcastUpdate(new CounterUpdate { Action = CounterUpdateAction.Align, Value = CounterAlign });
        }
    }

    public ImageMode CounterImageMode
    {
        get => _config.CounterImageMode;
        set
        {
            if (_config.CounterImageMode == value) return;
            
            _config.CounterImageMode = value;
            WebSocketModule.BroadcastUpdate(new CounterUpdate
                { Action = CounterUpdateAction.ImageMode, Value = CounterImageMode });
        }
    }

    public int CounterImageOffsetX
    {
        get => _config.CounterImageOffsetX;
        set
        {
            if (_config.CounterImageOffsetX == value) return;
            
            _config.CounterImageOffsetX = value;
            WebSocketModule.BroadcastUpdate(new CounterUpdate
            {
                Action = CounterUpdateAction.ImageOffset,
                Value = new ImageOffset { X = CounterImageOffsetX, Y = CounterImageOffsetY }
            });
        }
    }

    public int CounterImageOffsetY
    {
        get => _config.CounterImageOffsetY;
        set
        {
            if (_config.CounterImageOffsetY == value) return;
            
            _config.CounterImageOffsetY = value;
            WebSocketModule.BroadcastUpdate(new CounterUpdate
            {
                Action = CounterUpdateAction.ImageOffset,
                Value = new ImageOffset { X = CounterImageOffsetX, Y = CounterImageOffsetY }
            });
        }
    }

    public int CounterImageSize
    {
        get => _config.CounterImageSize;
        set
        {
            if (_config.CounterImageSize == value) return;
            
            _config.CounterImageSize = value;
            WebSocketModule.BroadcastUpdate(new CounterUpdate
                { Action = CounterUpdateAction.ImageSize, Value = CounterImageSize });
        }
    }

    #endregion Getters Setters
}