<!-- In comments are my original words. I ran the readme through an LLM to improve it. -->

# Sekiro40v

<!-- Sekiro40v is a tool for zapping yourself with electricity while playing games (oh, and counting how many times you died in-game). Originally made for [Sekiro™: Shadows Die Twice](https://store.steampowered.com/app/814380/Sekiro_Shadows_Die_Twice__GOTY_Edition/) (hence the name). It consists of 2 parts, one is installed on your computer, the other one sits on Arduino-like device (I used Raspberry Pi Pico). Local software is written in C#. It's responsible for detecting damage and deaths in your game. From GUI it you can change every setting you like. Settings are also saved in JSON files if you want to edit them manually. Program also keeps track of various statistics. Other piece of software is responsible for receiving commands from PC and sending them to shock collar. -->

Sekiro40v is a tool with two components. One part is a C# program installed on your computer, which detects in-game damage and deaths. It has a GUI for adjusting settings, which are saved in JSON files. It also tracks various statistics. The other part is on an Arduino-like device, such as a Raspberry Pi Pico, and it receives commands from the PC to control a shock collar. The tool was initially created for [Sekiro™: Shadows Die Twice](https://store.steampowered.com/app/814380/Sekiro_Shadows_Die_Twice__GOTY_Edition/), hence its name.

<!-- ## I just want to make it work.

1.  Download latest version from [here](https://github.com/kubagp1/sekiro40v/releases/latest). Make sure you download file named `Sekiro40v.zip`
2.  Unpack it somewhere safe. It's important to copy all files from the zip file.
3.  Launch `Sekiro40v.exe`. It should ask you for administrator rights. You HAVE to agree.
4.  If you want to use it with [Sekiro™: Shadows Die Twice](https://store.steampowered.com/app/814380/Sekiro_Shadows_Die_Twice__GOTY_Edition/) you are pretty much done. If not, then you have to go to `MemoryHook` tab and change `Process name` to your game's process name. You also have to change `Memory offset`. Default one works for Sekiro. Check below for more information.
5.  If you want to use Death Counter, go to Death Counter tab, press `Copy URL` button and paste it into OBS or whatever. More info below.
6.  Now, you need to set up your Arduino-like device. Since I own a Raspberry Pi Pico, I'm gonna assume you do too.
7.  Install [Arduino IDE](https://www.arduino.cc/en/software). Launch it. Go to Tools -> Board -> Boards Manager. Search and install your board.
8.  Go [here](https://github.com/kubagp1/sekiro40v/blob/main/Sekiro40vPico/Sekiro40vPico.ino) and click highlighted button (`Copy raw contents`). Or just copy entire file however you like. -->

Here's a more streamlined version of the instructions:

## Getting Started

1.  Download the latest version of Sekiro40v from the [official repository](https://github.com/kubagp1/sekiro40v/releases/latest). Ensure you download the `Sekiro40v.zip` file.
2.  Extract the zip file to a secure location, ensuring all files are copied.
3.  Run `Sekiro40v.exe`. It will request administrator rights, which you must grant.
4.  If you're using it with [Sekiro™: Shadows Die Twice](https://store.steampowered.com/app/814380/Sekiro_Shadows_Die_Twice__GOTY_Edition/), no further setup is required. For other games, navigate to the `MemoryHook` tab and update the `Process name` and `Memory offset` (more instructions below).
5.  To use the Death Counter, navigate to the Death Counter tab, click `Copy URL`, and paste it into your streaming software.
6.  Set up your Arduino-like device. This guide assumes you're using a Raspberry Pi Pico.
7.  Install the [Arduino IDE](https://www.arduino.cc/en/software). Open it and navigate to Tools -> Board -> Boards Manager. Search for and install your board.
8.  Visit [this page](https://github.com/kubagp1/sekiro40v/blob/main/Sekiro40vPico/Sekiro40vPico.ino) and click the highlighted button to copy the raw contents of the file. Alternatively, you can manually copy the entire file.

![Github screenshot](https://i.imgur.com/occQj1K.png)

<!-- 9. Paste what you just copied into Arduino IDE.
10. Change `TX_PIN` if you need and then press `Upload` button (looks like an arrow facing right).

![Arduino IDE screenshot](https://i.imgur.com/ULb0cbN.png)

11. Wait for it to upload, it may take a while.
12. Connect your RF transmitter to device using some cables. GND to GND. VCC to VBUS, ATAD(DATA) to whatever you set TX_PIN to. The default is 22.

If you got lost, or something went wrong please [open an issue](https://github.com/kubagp1/sekiro40v/issues/new). We can figure it out together :) -->

Continuing from the previous steps:

9.  Paste the copied content into the Arduino IDE.
10. If necessary, modify the `TX_PIN` value. Then, click the `Upload` button (represented by a right-facing arrow).

![Arduino IDE screenshot](https://i.imgur.com/ULb0cbN.png)

11. Wait some time for the upload to complete.
12. Connect your RF transmitter to the device using appropriate cables. Connect GND to GND, VCC to VBUS, and ATAD(DATA) to the pin you set as `TX_PIN`. The default pin is 22.

If you encounter any issues or need further assistance, please [open an issue](https://github.com/kubagp1/sekiro40v/issues/new). We can figure it out together :)

<!-- ## What are these options?

### General

![General view of Sekiro40v](https://i.imgur.com/YEUvNSl.png)

**WebServer port** - this is the port on which the local web server used to serve _DeathCounter_ is listening. Remember to change it everywhere you are displaying counter (eg. OBS) after changing this setting.

![MemoryHook and PainSender integration section](https://i.imgur.com/uO1nud8.png)

These settings decide what shock settings (if any) should be used when damage or death is detected in game.

- **Scale strength** - duration of shock doesn't change. Strength is calculated like this `(damage taken / max HP) * max strength`. For
  example if you had full HP (**320 points**) and you got hit for **32
  points** while having your max shock strength set to **50**, and your
  shock duration set to **1000 ms**, you would be shocked with **5**
  strength for **1 second**.
- **Scale duration** - opposite of **scale strength** option. Strength of a shock doesn't change, but duration does.

- **Scale both** - both strength and duration of a shock depend on how much damage you received.

- **Static both** - both strength and duration of a shock stay the same always. No matter how hard you get hit.

You can disable shocking on damage completely by unchecking the **Shock on damage** checkbox. The same goes for getting shocked on death, you can disable it by unchecking **Shock on death** checkbox.

The rest of buttons and options are pretty self-explanatory, but feel free to [open an issue](https://github.com/kubagp1/sekiro40v/issues/new) if you can't understand something. -->

## Understanding the options

### General

The **WebServer port** is the port that the local web server uses to serve the _DeathCounter_. If you change this setting, remember to update it wherever you're displaying the counter (e.g. OBS).

![MemoryHook and PainSender integration section](https://i.imgur.com/uO1nud8.png)

The settings under the **MemoryHook and PainSender integration** section determine the shock settings (if any) to be used when in-game damage or death is detected.

- **Scale strength**: The shock duration remains constant, but the strength varies based on the formula `(damage taken / max HP) * max strength`. For instance, if you have full HP (**320** points) and take **32** points of damage, with a max shock strength set to **50** and a shock duration of **1000** ms, you would receive a shock of strength **5** for **1** second.
- **Scale duration**: The shock strength remains constant, but the duration varies based on the damage received.
- **Scale both**: Both the strength and duration of the shock vary based on the damage received.
- **Static both**: Both the strength and duration of the shock remain constant, regardless of the damage received.

You can disable the shock on damage entirely by unchecking the **Shock on damage** checkbox. Similarly, you can disable the shock on death by unchecking the **Shock on death** checkbox.

The remaining buttons and options are fairly self-explanatory. However, if you have any questions or need further clarification, feel free to [open an issue](https://github.com/kubagp1/sekiro40v/issues/new). I'm here to help! :)

<!-- ### MemoryHook

![MemoryHook view of Sekiro40v](https://i.imgur.com/AbfMnJq.png)

In here, is everything related to reading game's memory.

- **Process name** - name of the process of the game, you can find it in the Task Manager. It doesn't need extension however so just throw ".exe" away.
- **Max. reads per second** - How many times _MemoryHook_ should read game's memory to figure out if you took damage. Lowest value is **1**.
- **Memory offset** - where exactly in game's memory is your HP stored. You can figure it out by using software like [Cheat Engine](https://www.cheatengine.org/). This is "relative" address, which means that base address is added automatically. Feel free to [open an issue](https://github.com/kubagp1/sekiro40v/issues/new) if you need help finding this for your game.

Here is some tutorial for Cheat Engine https://book.hacktricks.xyz/reversing/reversing-tools-basic-methods/cheat-engine

What different statuses mean:

- **Searching** - Program looks for process with name you specified.
- **Ready** - MemoryHook is attached to the process and scanning.
- **Starting** - if you see this, something doesn't work, please [open an issue](https://github.com/kubagp1/sekiro40v/issues/new).

Notice that you can change **Max. HP** manually, _MemoryHook_ itself will update it if it goes higher, but not lower.

If you die, only death event is fired, not the damage event.

The rest of statistics and statuses are pretty self-explanatory, but feel free to [open an issue](https://github.com/kubagp1/sekiro40v/issues/new) if you can't understand something. -->

### MemoryHook

![MemoryHook view of Sekiro40v](https://i.imgur.com/AbfMnJq.png)

The MemoryHook section is dedicated to the settings related to reading the game's memory.

- **Process name**: This is the name of the game process, which can be found in the Task Manager. The ".exe" extension is not required.
- **Max. reads per second**: This setting determines how often MemoryHook should read the game's memory to detect damage. The minimum value is 1.
- **Memory offset**: This is the location in the game's memory where your HP is stored. You can determine this using software like [Cheat Engine](https://www.cheatengine.org/). This is a "relative" address, meaning the base address is added automatically. If you need help finding this for your game, feel free to [open an issue](https://github.com/kubagp1/sekiro40v/issues/new).

Here is a tutorial for Cheat Engine: https://book.hacktricks.xyz/reversing/reversing-tools-basic-methods/cheat-engine

The different statuses are as follows:

- **Searching**: The program is looking for the process with the name you specified.
- **Ready**: MemoryHook is attached to the process and scanning.
- **Starting**: If you see this status, something isn't working. Please [open an issue](https://github.com/kubagp1/sekiro40v/issues/new).

Note that you can manually change the **Max. HP**. MemoryHook will update it if it goes higher, but not lower.

If you die in the game, only the death event is triggered, not the damage event.

The rest of the statistics and statuses are fairly self-explanatory. However, if you have any questions or need further clarification, feel free to [open an issue](https://github.com/kubagp1/sekiro40v/issues/new).
I'm here to help! :)

<!-- ### DeathCounter

![DeathCounter view of Sekiro40v](https://i.imgur.com/QCk5ckk.png)

You can modify counter value by clicking **Decrement** and **Increment** buttons, but also just typing a number in the box in the middle. It also auto-increments itself every time _MemoryHook_ detects a death.

Use it by first copying URL using button in right-bottom corner, then paste it in your browser or OBS (or anything really). For OBS I recommend to make it a lot wider than taller because numbers try to fill all vertical space. Then, if you don't like default look, you can modify it directly on this tab and view results in browser or OBS without any refreshing or saving.

I think that all the options here are pretty self-explanatory, but feel free to [open an issue](https://github.com/kubagp1/sekiro40v/issues/new) if you can't understand something.

One more thing, if you want to replace displayed image, you have to replace `webserver_static/counter/image.png`. The `webserver_static` folder is located next to `sekiro40v.exe` file. The file has to be this exact name and extension (at least if you don't want to edit .html files that are also located there). Last step is to restart Sekiro40v and refresh your browser or OBS widget. -->

### DeathCounter

![DeathCounter view of Sekiro40v](https://i.imgur.com/QCk5ckk.png)

The DeathCounter allows you to modify the counter value by clicking the **Decrement** and **Increment** buttons, or by typing a number directly into the box. The counter also auto-increments each time _MemoryHook_ detects a death.

To use it, copy the URL using the button in the bottom-right corner, then paste it into your browser or OBS. For OBS, it's recommended to make the display wider than it is tall, as the numbers try to fill all vertical space. If you want to change the default look, you can modify it directly on this tab and view the results in your browser or OBS without needing to refresh or save.

If you want to replace the displayed image, you need to replace the `webserver_static/counter/image.png` file. The `webserver_static` folder is located next to the `sekiro40v.exe` file. The file must have the exact name and extension (unless you want to edit the .html files also located there). The final step is to restart Sekiro40v and refresh your browser or OBS widget.

If you have any questions or need further clarification, feel free to [open an issue](https://github.com/kubagp1/sekiro40v/issues/new). I'm here to help! :)

<!-- ### PainSender

![PainSender view of Sekiro40v](https://i.imgur.com/a6UQDtd.png)

**PainSender** is responsible for connecting to your Arduino-like device and sending it simple commands.

#### How do I know which one is my Arduino-like device?

You have three options:

1.  Disconnect your Arduino-like device. Click `Refresh list`. See what devices are listed. Connect your device. Click `Refresh List`. There should be one more device now, it is the one.
2.  (for tryhards) Go to Device Manager -> Ports (LPT and COM) -> USB Serial Device -> Properties -> Details -> Device description as reported by the bus. Check if the name matches your device, repeat for every device. (I doubt anyone really would go to this much effort).
3.  Try randomly, what's the worst that could happen?

**Pair with collar** button will send to device request to send shock with strength 0, and duration 1000 ms.
You can test if shocking works in **Testing** section.

I think that just about covers it all, but if there is something else you want me to explain please feel free to [open an issue](https://github.com/kubagp1/sekiro40v/issues/new). -->

### PainSender

![PainSender view of Sekiro40v](https://i.imgur.com/a6UQDtd.png)

The **PainSender** is tasked with establishing a connection to your Arduino-like device and transmitting simple commands.

#### Identifying Your Arduino-like Device

You have three options:

1.  (Recomended) Disconnect your Arduino-like device, click `Refresh list`, and note the listed devices. Reconnect your device, click `Refresh List` again, and identify the newly listed device.
2.  Navigate to Device Manager -> Ports (LPT and COM) -> USB Serial Device -> Properties -> Details -> Device description as reported by the bus. Check if the name matches your device and repeat for each device.
3.  Try each device randomly.

The **Pair with collar** button sends a request to the device to deliver a shock with a strength of 0 and a duration of 1000 ms. You can test the shocking functionality in the **Testing** section.

If there's anything else you'd like me to explain, feel free to [open an issue](https://github.com/kubagp1/sekiro40v/issues/new). I'm here to help! :)

<!-- ## What do I do if it doesn't work?

- Make sure to launch application as Administrator.
- I tested it on Windows 11 if that helps.
- Remove `settings.json` and/or `statistics.json` files.
- Download latest version.
- Reflash your Arduino like-device.
- Reconnect your Arduino-like device.
- Reconnect RF transmitter to your Arduino-like device.
- Make sure you have charged batteries in collar (seriously check!).
- Connect Arduino-like device to different USB port (preferably the one with the highest power output).
- Change WebServer port.
- Restart your PC.
- Restart your game.
- Restart Sekiro40v.
- RESTART EVERYTHING!

If any of above didn't help please [open an issue](https://github.com/kubagp1/sekiro40v/issues/new)!

## Electric collar

![Picture of Petrainer shock collar](https://i00.eu/img/403/250x250f/6ohlz2eh/1086.jpg)

I'm using Petrainer PET998D. The script for Arduino-like device is made for it. I copied the actual communucating with the collar part from [here](https://github.com/btlvr/pet998drb-arduino/blob/master/main.cpp). [http://brettleaver.com/collar/](Here) is a pretty cool article about how it works.
[https://stpihkal.docs.buttplug.io/protocols/petrainer.html](Here) is another nice source for "toys" communication protocols.
Feel free to fork this project or make a pull request for another collars and things.

## Somewhat hidden features

- Clicking on a label in bottom-left corner opens this site.
- If you send shock request before the last one has finished, the new one is prioritized if it's longer than what's left of the old one.

## Do you want help?

Yes, if you know how to generate .ef2 files for RP2040 (Pico) from Arduino IDE, please contact me.
Also any suggestions, bug reports, corrections are welcome.

It's my first C# project btw. -->

## Troubleshooting

If Sekiro40v isn't working as expected, here are some steps you can take:

- Ensure the application is launched as Administrator.
- Try removing the `settings.json` and/or `statistics.json` files.
- Download the latest version of the software.
- Reflash your Arduino-like device.
- Reconnect your Arduino-like device and RF transmitter.
- Check that the batteries in the collar are charged.
- Connect the Arduino-like device to a different USB port, preferably one with the highest power output.
- Change the WebServer port.
- Restart your PC, game, and Sekiro40v. In fact, try restarting everything!

If these steps don't resolve the issue, please [open an issue](https://github.com/kubagp1/sekiro40v/issues/new).

## Electric Collar

The script for the Arduino-like device is designed for the Petrainer PET998D collar. The communication part of the script was adapted from [this source](https://github.com/btlvr/pet998drb-arduino/blob/master/main.cpp). You can find more information about how it works [here](http://brettleaver.com/collar/). Another useful resource for "toy" communication protocols can be found [here](https://stpihkal.docs.buttplug.io/protocols/petrainer.html). Feel free to fork this project or make a pull request for other collars and devices.

## Hidden Features

- Clicking on the label in the bottom-left corner opens this site.
- If you send a shock request before the last one has finished, the new one takes priority if it's longer than what's left of the old one.

## Contributions

If you know how to generate .ef2 files for RP2040 (Pico) from Arduino IDE, your help would be appreciated. Suggestions, bug reports, and corrections are also welcome. This is my first C# project.
