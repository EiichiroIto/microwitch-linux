#!/bin/sh
rm -f *.o MicrobitPlugin
gcc -fPIC -Wall -pedantic-errors -I../src -c ../src/MicrowitchPlugin.c ../src/unixMicrowitchOps.c
gcc -shared *.o -o so.MicrowitchPlugin
rm -f *.o
