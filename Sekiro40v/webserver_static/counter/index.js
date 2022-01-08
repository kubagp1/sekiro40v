const Action = {
  Counter: 0,
  FontFamily: 1,
  Color: 2,
  Align: 3,
  ImageMode: 4,
  ImageOffset: 5,
  ImageSize: 6,
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

      switch (e.action) {
        case Action.Counter:
          this.counter.innerText = e.value;
          break;
        case Action.FontFamily:
          this.counter.style.fontFamily = e.value;

          if (!document.fonts.check('1em ' + e.value)) {
            WebFont.load({
              google: {
                families: [e.value]
              }
            });
          }

          break;
        
        case Action.Color:
          this.counter.style.color = e.value;
          break;
        
        case Action.Align:
          switch (e.value) {
            case CounterAlign.Left:
              this.container.style.float = 'left';
              break;
            
            case CounterAlign.Right:
              this.container.style.float = 'right';
              break;
          }
          break;
        
          case Action.ImageMode:
            switch (e.value) {
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

          case Action.ImageOffset:
            this.image.style.transform = `translate(${e.value.x}%, ${e.value.y}%)`;
            break;

          case Action.ImageSize:
            this.image.style.height = `${e.value}vh`;
            break;
      }
    });
  }
}

new App();