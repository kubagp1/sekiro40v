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
            Align
        }

        public enum CounterAlign
        {
            Left,
            Right
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