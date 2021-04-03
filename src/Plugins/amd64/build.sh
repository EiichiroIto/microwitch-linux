#!/bin/sh
rm -f *.o MicrobitPlugin
gcc -fPIC -Wall -m32 -pedantic-errors -I ../src -c ../src/MicrowitchPlugin.c ../src/unixMicrowitchOps.c
gcc -m32 -shared *.o -o so.MicrowitchPlugin
rm -f *.o
