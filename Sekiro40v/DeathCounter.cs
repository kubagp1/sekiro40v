using EmbedIO.WebSockets;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Sekiro40v
{
    public class DeathCounter
    {
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

        public enum CounterAlign
        {
            Left,
            Right
        }

        public enum ImageMode
        {
            Hide,
            Left,
            Right
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

        public event EventHandler<CounterChangedEventArgs> CounterChangedEventHandler;

        #region Getters Setters

        private int _counter;

        public int Counter
        {
            get { return _counter; }
            set
            {
                var changed = _counter != value;
                _counter = value;
                if (changed)
                    CounterChangedEventHandler?.Invoke(this, new CounterChangedEventArgs { value = value });
            }
        }

        public string counterFontFamily
        {
            get { return Config.counterFontFamily; }
            set
            {
                if (value != Config.counterFontFamily)
                {
                    Config.counterFontFamily = value;
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.FontFamily, value = counterFontFamily });
                }
            }
        }

        public string counterColor
        {
            get { return Config.counterColor; }
            set
            {
                var changed = value != Config.counterColor;
                Config.counterColor = value;
                if (changed)
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.Color, value = counterColor });
            }
        }

        public CounterAlign counterAlign
        {
            get { return Config.counterAlign; }
            set
            {
                if (value != Config.counterAlign)
                {
                    Config.counterAlign = value;
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.Align, value = counterAlign });
                }
            }
        }

        public ImageMode counterImageMode
        {
            get { return Config.counterImageMode; }
            set
            {
                if (Config.counterImageMode != value)
                {
                    Config.counterImageMode = value;
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.ImageMode, value = counterImageMode });
                }
            }
        }

        public int counterImageOffsetX
        {
            get { return Config.counterImageOffsetX; }
            set
            {
                if (Config.counterImageOffsetX != value)
                {
                    Config.counterImageOffsetX = value;
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.ImageOffset, value = new ImageOffset() { x = this.counterImageOffsetX, y = this.counterImageOffsetY } });
                }
            }
        }

        public int counterImageOffsetY
        {
            get { return Config.counterImageOffsetY; }
            set
            {
                if (Config.counterImageOffsetY != value)
                {
                    Config.counterImageOffsetY = value;
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.ImageOffset, value = new ImageOffset() { x = this.counterImageOffsetX, y = this.counterImageOffsetY } });
                }
            }
        }

        public int counterImageSize
        {
            get { return Config.counterImageSize; }
            set
            {
                if (Config.counterImageSize != value)
                {
                    Config.counterImageSize = value;
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.ImageSize, value = this.counterImageSize });
                }
            }
        }

        #endregion Getters Setters

        public class CounterUpdate
        {
            public CounterUpdateAction action { get; set; }
            public object value { get; set; }
        }

        public class CounterWebSocketModule : WebSocketModule
        {
            private DeathCounter DeathCounter;

            public CounterWebSocketModule(string urlPath, DeathCounter deathCounter) : base(urlPath, true)
            {
                DeathCounter = deathCounter;
            }

            protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] buffer, IWebSocketReceiveResult result)
                => Task.CompletedTask;

            protected override Task OnClientConnectedAsync(IWebSocketContext context)
            {
                SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate()
                {
                    action = CounterUpdateAction.Counter,
                    value = DeathCounter.Counter
                }));

                SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate()
                {
                    action = CounterUpdateAction.Align,
                    value = DeathCounter.counterAlign
                }));

                SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate()
                {
                    action = CounterUpdateAction.Color,
                    value = DeathCounter.counterColor
                }));

                SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate()
                {
                    action = CounterUpdateAction.FontFamily,
                    value = DeathCounter.counterFontFamily
                }));

                SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate()
                {
                    action = CounterUpdateAction.ImageMode,
                    value = DeathCounter.counterImageMode
                }));

                SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate()
                {
                    action = CounterUpdateAction.ImageOffset,
                    value = new ImageOffset()
                    {
                        x = DeathCounter.counterImageOffsetX,
                        y = DeathCounter.counterImageOffsetY
                    }
                }));

                SendAsync(context, JsonConvert.SerializeObject(new CounterUpdate()
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

        public CounterWebSocketModule Module;

        public Config.DeathCounter Config;

        public DeathCounter(Config.DeathCounter config)
        {
            Config = config;

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

        private void DeathCounter_CounterChangedEventHandler(object sender, CounterChangedEventArgs e)
        {
            Module.BroadcastUpdate(new CounterUpdate()
            {
                action = CounterUpdateAction.Counter,
                value = Counter
            });
        }
    }
}