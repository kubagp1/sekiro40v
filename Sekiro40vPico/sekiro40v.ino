// tx part copied from https://github.com/btlvr/pet998drb-arduino/blob/master/main.cpp

#define TX_PIN 22

#define BIT_DURATION 640
#define DELIMITER_DURATION 190
#define PREAMBLE_HIGH_DURATION 1500
#define PREAMBLE_LOW_DURATION 750

enum CHANNEL {CHANNEL_1, CHANNEL_2};
enum TYPE {SHOCK, BUZZ, BEEP, LIGHT};

void tx_delim() {
    digitalWrite(TX_PIN,LOW);
    delayMicroseconds(DELIMITER_DURATION);
    digitalWrite(TX_PIN,HIGH);
    delayMicroseconds(DELIMITER_DURATION);
}

void tx_bit(bool value) {
    digitalWrite(TX_PIN,value);
    delayMicroseconds(BIT_DURATION);
    tx_delim();
}

void tx_preamble() {
    digitalWrite(TX_PIN,HIGH);
    delayMicroseconds(PREAMBLE_HIGH_DURATION);
    digitalWrite(TX_PIN,LOW);
    delayMicroseconds(PREAMBLE_LOW_DURATION);
    tx_delim();
}

void tx_single_packet(CHANNEL channel,
                      TYPE type,
                      byte power,
                      byte ID1,
                      byte ID2) {
    byte bytes[5];    
    byte shift = 1;
    if (channel == CHANNEL::CHANNEL_1)
        bytes[0] = 0x80;
    if (channel == CHANNEL::CHANNEL_2)
        bytes[0] = 0xF0;
    switch(type) {
        case TYPE::SHOCK:
        bytes[0] += 0x01;
        break;
    case TYPE::BUZZ:
        bytes[0] += 0x02;
        break;
    case TYPE::BEEP:
        bytes[0] += 0x04;
        break;
    case TYPE::LIGHT:
        bytes[0] += 0x08;
        break;
    }
    bytes[1] = ID1;
    bytes[2] = ID2;
    bytes[3] = power%101;
    switch(type) {
        case TYPE::SHOCK:
            bytes[4] = 0x70;
            break;
        case TYPE::BUZZ:
            bytes[4] = 0xB0;
            break;
        case TYPE::BEEP:
            bytes[4] = 0xD0;
            break;
        case TYPE::LIGHT:
            bytes[4] = 0xE0;
            break;
    }
    if (channel == CHANNEL::CHANNEL_1)
        bytes[4] |= 0x0e;

    tx_preamble();
    for (byte b : bytes) {
        for (int i = 0; i < 8; i++) {   
            bool value = b & (1 << 7);
            b <<= shift;
            tx_bit(value);
        }
    }
    digitalWrite(TX_PIN,LOW);
    delayMicroseconds(BIT_DURATION*2);
}

void tx_packet(CHANNEL channel,
               TYPE type,
               byte power,
               byte ID1,
               byte ID2) {
    for (int i = 0; i < 8; i++)
        tx_single_packet(channel, type, power, ID1, ID2);
}

// end tx

int strength_now = 0;
int duration_now = 0;

void setup() {
  Serial.begin(115200);

  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, HIGH);
}

static char message[33];
static unsigned int message_pos = 0;

bool transmitting = false;

void loop() {
  unsigned long time_start = micros();
  
  bool message_received = false;

  while (Serial.available() > 0)
  {
    char inByte = Serial.read();

    if (inByte != '\n')
    {
      message[message_pos] = inByte;
      message_pos++;
    }
    else
    {
      message[message_pos] = '\0';

      message_pos = 0;

      message_received = true;
    }
  }

  if (message_received)
  {
    Serial.print("Received message: ");
    Serial.println(message);

    char command_str[32];
    char strength_str[32];
    char duration_str[32];
    
    strcpy(command_str, strtok(message, " "));
    strcpy(strength_str, strtok(NULL, " "));
    strcpy(duration_str, strtok(NULL, " "));

    int command = atoi(command_str);
    int strength = atoi(strength_str);
    int duration = atoi(duration_str);

    if (command == 1)
    {
      if (duration > duration_now)
      {
        duration_now = duration*1000;
        strength_now = strength;
      }
    }
  }

  if (duration_now > 0)
  {
    transmitting = true;
    digitalWrite(LED_BUILTIN, LOW);
    
    tx_packet(CHANNEL::CHANNEL_1, TYPE::SHOCK, strength_now, 0x20, 0x89);
    Serial.print(".");

    unsigned long time_now = micros();
    if (time_now > time_start) // In case there is time overflow and it resets to zero
    {
      duration_now -= time_now - time_start;
    }
    else
    {
      duration_now -= 0xFFFFFFFF - time_start + time_now;
    }
  }
  else
  {
    if(transmitting)
    {
      transmitting = false;
      digitalWrite(LED_BUILTIN, HIGH);
      Serial.print('\n');
    }
  }
}
