using System;
using System.Threading.Tasks;
using EmbedIO.WebSockets;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            get
            {
                return _counter;
            }
            set
            {
                var changed = _counter != value;
                _counter = value;
                if (changed)
                    CounterChangedEventHandler?.Invoke(this, new CounterChangedEventArgs { value = value });
            }
        }

        private string _counterFontFamily;

        public string counterFontFamily
        {
            get
            {
                return _counterFontFamily;
            }
            set
            {
                var changed = value != _counterFontFamily;
                _counterFontFamily = value;
                if (changed)
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.FontFamily, value = _counterFontFamily });
            }
        }

        private string _counterColor;

        public string counterColor
        {
            get
            {
                return _counterColor;
            }
            set
            {
                var changed = value != _counterColor;
                _counterColor = value;
                if (changed)
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.Color, value = _counterColor });
            }
        }

        private CounterAlign _counterAlign;

        public CounterAlign counterAlign
        {
            get
            {
                return _counterAlign;
            }
            set
            {
                var changed = value != _counterAlign;
                _counterAlign = value;
                if (changed)
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.Align, value = _counterAlign });
            }
        }

        private ImageMode _counterImageMode;

        public ImageMode counterImageMode
        {
            get { return _counterImageMode; }
            set
            {
                var changed = _counterImageMode != value;
                _counterImageMode = value;
                if (changed)
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.ImageMode, value = _counterImageMode });
            }
        }

        private int _counterImageOffsetX;

        public int counterImageOffsetX
        {
            get { return _counterImageOffsetX; }
            set
            {
                var changed = _counterImageOffsetX != value;
                _counterImageOffsetX = value;
                if (changed)
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.ImageOffset, value=new ImageOffset() { x = this.counterImageOffsetX, y = this.counterImageOffsetY } });
            }
        }

        private int _counterImageOffsetY;

        public int counterImageOffsetY
        {
            get { return _counterImageOffsetY; }
            set
            {
                var changed = _counterImageOffsetY != value;
                _counterImageOffsetY = value;
                if (changed)
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.ImageOffset, value = new ImageOffset() { x = this.counterImageOffsetX, y = this.counterImageOffsetY } });
            }
        }

        private int _counterImageSize;

        public int counterImageSize
        {
            get { return _counterImageSize; }
            set
            {
                var changed = _counterImageSize != value;
                _counterImageSize = value;
                if (changed)
                    Module.BroadcastUpdate(new CounterUpdate() { action = CounterUpdateAction.ImageSize, value = this.counterImageSize});
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
                SendAsync(context, JsonSerializer.Serialize(new CounterUpdate()
                {
                    action = CounterUpdateAction.Counter,
                    value = DeathCounter.Counter
                }));

                SendAsync(context, JsonSerializer.Serialize(new CounterUpdate()
                {
                    action = CounterUpdateAction.Align,
                    value = DeathCounter.counterAlign
                }));

                SendAsync(context, JsonSerializer.Serialize(new CounterUpdate()
                {
                    action = CounterUpdateAction.Color,
                    value = DeathCounter.counterColor
                }));

                SendAsync(context, JsonSerializer.Serialize(new CounterUpdate()
                {
                    action = CounterUpdateAction.FontFamily,
                    value = DeathCounter.counterFontFamily
                }));

                SendAsync(context, JsonSerializer.Serialize(new CounterUpdate()
                {
                    action = CounterUpdateAction.ImageMode,
                    value = DeathCounter.counterImageMode
                }));

                SendAsync(context, JsonSerializer.Serialize(new CounterUpdate()
                {
                    action = CounterUpdateAction.ImageOffset,
                    value = new ImageOffset()
                    {
                        x = DeathCounter.counterImageOffsetX,
                        y = DeathCounter.counterImageOffsetY
                    }
                }));

                SendAsync(context, JsonSerializer.Serialize(new CounterUpdate()
                {
                    action = CounterUpdateAction.ImageSize,
                    value = DeathCounter.counterImageSize
                }));

                return base.OnClientConnectedAsync(context);
            }

            public void BroadcastUpdate(CounterUpdate update)
            {
                BroadcastAsync(JsonSerializer.Serialize(update));
            }
        }

        public CounterWebSocketModule Module;

        public DeathCounter()
        {
            Module = new CounterWebSocketModule("/counter/socket", this);

            counterAlign = CounterAlign.Left;
            counterColor = "#FF0000";
            counterFontFamily = "Arial";
            counterImageOffsetX = 0;
            counterImageOffsetY = 0;
            counterImageSize = 50;
            counterImageMode = ImageMode.Left;

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