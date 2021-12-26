const Action = {
  Counter: 0,
  FontFamily: 1,
  Color: 2,
  Align: 3
}

const CounterAlign = {
  Left: 0,
  Right: 1
}

class App {
  constructor() {
    this.counter = document.getElementById('counter');

    this.startWebsocket();
  }

  startWebsocket() {
    this.webscocket = new WebSocket(`ws://${location.host}/counter/socket`);

    this.webscocket.addEventListener('error', this.startWebsocket.bind(this));

    this.webscocket.addEventListener('message', (event) => {
      var e = JSON.parse(event.data);

      switch (e.action) {
        case Action.Counter:
          this.counter.innerText = e.value;
          break;
        case Action.FontFamily:
          this.counter.style.fontFamily = e.value;
          break;
        
        case Action.Color:
          this.counter.style.color = e.value;
          break;
        
        case Action.Align:
          switch (e.value) {
            case CounterAlign.Left:
              this.counter.style.textAlign = 'left';
              break;
            
            case CounterAlign.Right:
              this.counter.style.textAlign = 'right';
              break;
          }
          break;
      }
    });
  }
}

new App();