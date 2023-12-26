const Action = {
    Value: 0,
    FontFamily: 1,
    Color: 2,
    Align: 3,
    ImageMode: 4,
    ImageOffsetX: 5,
    ImageOffsetY: 6,
    ImageSize: 7,
}

const ImageMode = {
    Hide: 0,
    Left: 1,
    Right: 2
}

const CounterAlign = {
    Left: 0,
    Right: 1
}

class App {
    constructor() {
        this.counter = document.getElementById('counter');
        this.container = document.getElementsByClassName('container')[0];
        this.image = document.getElementById('image');

        this.startWebsocket();
    }

    startWebsocket() {
        this.webscocket = new WebSocket(`ws://${location.host}/counter/socket`);

        this.webscocket.addEventListener('error', this.startWebsocket.bind(this));
        this.webscocket.addEventListener('close', this.startWebsocket.bind(this));

        this.webscocket.addEventListener('message', (event) => {
            var e = JSON.parse(event.data);

            switch (e.Action) {
                case Action.Value:
                    this.counter.innerText = e.Value;
                    break;
                case Action.FontFamily:
                    this.counter.style.fontFamily = e.Value;

                    WebFont.load({
                        google: {
                            families: [e.Value]
                        }
                    });

                    break;

                case Action.Color:
                    this.counter.style.color = e.Value;
                    break;

                case Action.Align:
                    switch (e.Value) {
                        case CounterAlign.Left:
                            this.container.style.float = 'left';
                            break;

                        case CounterAlign.Right:
                            this.container.style.float = 'right';
                            break;
                    }
                    break;

                case Action.ImageMode:
                    switch (e.Value) {
                        case ImageMode.Hide:
                            this.image.style.display = 'none';
                            break;

                        case ImageMode.Left:
                            this.image.style.display = 'block';
                            this.container.style.flexDirection = 'row-reverse';
                            break;

                        case ImageMode.Right:
                            this.image.style.display = 'block';
                            this.container.style.flexDirection = 'row';
                            break;
                    }

                    break;

                case Action.ImageOffsetX:
                    this.image.style.transform = `translateX(${e.Value}%)`;
                    break;

                case Action.ImageOffsetY:
                    this.image.style.transform = `translateY(${e.Value}%)`;
                    break;

                case Action.ImageSize:
                    this.image.style.height = `${e.Value}vh`;
                    break;
            }
        });
    }
}

new App();