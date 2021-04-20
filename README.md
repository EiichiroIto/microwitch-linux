# microwitch-linux
micro:witch is a block-style programming environment for micro:bit based on MIT Scratch.

[Japanese documents](https://github.com/EiichiroIto/microwitch-linux/blob/master/README.ja.md)

[for Windows](https://github.com/EiichiroIto/microwitch)

![screenshot1](https://raw.githubusercontent.com/EiichiroIto/microwitch/master/doc/images/screenshot1.png)

## Getting started
### Raspberry OS
```bash
wget https://github.com/EiichiroIto/microwitch-linux/releases/download/v1.2.5/microwitch_1.2.5-1_armhf.deb
sudo apt install squeak-vm squeak-plugins-scratch
sudo dpkg -i microwitch_1.2.5-1_armhf.deb
```

Select micro:witch from Programming menu.

### Ubuntu OS (Intel/AMD 64bit)
```bash
wget https://github.com/EiichiroIto/microwitch-linux/releases/download/v1.2.5/microwitch_1.2.5-1_amd64.deb
sudo apt install squeak-vm squeak-plugins-scratch
sudo dpkg -i microwitch_1.2.5-1_amd64.deb
```

Run microwitch from any shells.

## Upload firmware
To use the micro:witch, you need to upload the firmware to the micro:bit by following the steps below.

1. Connect a micro:bit to your PC.
1. Wait until the computer recognizes the micro:bit as storage device.
1. Select "initialize micro:bit" from Device menu.
1. Click Yes on "initialize micro:bit?" dialog.
1. When the firmware has been transferred and the micro:bit is recognized again, you are done.

If the file selection dialog is displayed in the third step, micro:bit may not be recognized properly. Please check the connection.

## Usage
1. Connect a micro:bit to your PC.
1. Select "Connect to micro:bit" from Device menu.
1. Select a port connecting to the micro:bit. (ex. COM3)
1. Wait "status: ready" for a few seconds.
1. When you click on the script you have created, it will be transferred to the micro:bit and executed.

## Transferring a script
Just clicking on the script you have created will not save the script
in the micro:bit, so the script in the micro:bit will be lost when you
power off or reboot.

To save the script and have it run automatically when power is turned
on, follow the steps below.

1. Put up a block for "When the green flag is clicked".
1. Create the scripts you need.
1. After connecting micro:bit to the computer, select "Send to micro:bit".
1. Once the script has been transferred, the micro:bit will automatically reset and the script will start running.

To stop the running script, press the red button in the upper right corner of the screen.

## Trouble shooting
### Cannot transfer firmware properly.
Unplug the micro:bit from the computer, wait a moment, stick it back in, and try again.

Make sure that the cable connecting the micro:bit to the PC is for data transfer.

The DAPLink firmware version may be out of date. Please search for
"microbit firmware DAPLink update" and update the DAPLink firmware.

### "Traceback ... and other messages are displayed. Or, the script cannot be executed.
The firmware version may be old. Please transfer the firmware to the micro:bit again.

You may be using commands (such as sound events) added in micro:bit v2 on an older micro:bit.

### The script cannot be executed on micro:bit.
In the device menu, select "Connect to micro:bit" and choose a port.

Press the Stop button to confirm the "satus: ready" message is displayed.

### Ultrasonic sensor or expansion boards cannot be used , or they do not respond
Create a script that uses the ultrasonic sensor or expansion board, and then do "Send to micro:bit" afterwards.

The program required for the operation will be transferred automatically. (It may take some time.)

## License
GNU GENERAL PUBLIC LICENSE Version 2
