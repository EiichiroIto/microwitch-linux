# microwitch-linux
micro:witch is a block-style programming environment for micro:bit based on MIT Scratch.

![screenshot1](https://raw.githubusercontent.com/EiichiroIto/microwitch/master/doc/images/screenshot1.png)

## Getting started
### Raspberry OS
```bash
wget https://github.com/EiichiroIto/microwitch-linux/releases/download/v1.2.3/microwitch_1.2.3-1_armhf.deb
sudo apt install squeak-vm squeak-plugins-scratch
sudo dpkg -i microwitch_1.2.3-1_armhf.deb
```

Select micro:witch from Programming menu.

### Intel PC (ex. Ubuntu 64bit)
```bash
wget https://github.com/EiichiroIto/microwitch-linux/releases/download/v1.2.3/microwitch_1.2.3-1_amd64.deb
sudo apt install squeak-vm squeak-plugins-scratch
sudo dpkg -i microwitch_1.2.3-1_amd64.deb
```

Run microwitch from any shells.

## Usage
1. Connect a micro:bit to your PC.
1. Wait until recoginizing the micro:bit as a USB drive.
1. Create a program starting from "When green flag clicked" block.
1. Select "send to micro:bit" from Device menu.
1. The program runs on micro:bit.

## REPL Execution
1. Connect a micro:bit to your PC.
1. Select "Connect to micro:bit" from Device menu.
1. Select a port connecting to the micro:bit.
1. Wait "status: ready" for several seconds.
1. When you click some block, the code is transfered to the micro:bit then executed.
1. You can send a program quickly while the micro:bit is connecting.

## Trouble shooting
### I cannot send a firmware to my micro:bit.
It is very likely to fail sending a firmware in Linux system.
You may send a firmware just after connecting micro:bit to your PC, then it's highly recommended using REPL Execution.

### I cannot connect to my micro:bit or transfer a program on REPL Execution.
Firmware on your micro:bit may be old version. You can upgrage newer firmware. Please check following site.

[Updating your micro:bit firmware](https://microbit.org/ja/guide/firmware/)

### REPL Program does not start on reset.
1. If already running in REPL mode, select "Disconnect from micro:bit" from Device menu.
1. Select "New" from File menu to clear programs.
1. Select "send to micro:bit" from Device menu to send empty firmware.
1. Then you may do "REPL Execution" again.

## License
MIT License
