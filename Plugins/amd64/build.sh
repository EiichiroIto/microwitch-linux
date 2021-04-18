#!/bin/sh
rm -f *.o MicrobitPlugin
gcc -fPIC -Wall -m64 -pedantic-errors -I ../src -c ../src/MicrowitchPlugin.c ../src/unixMicrowitchOps.c
gcc -m64 -shared *.o -o so.MicrowitchPlugin
gcc -fPIC -Wall -m64 -pedantic-errors -I ../src -DMAIN -c ../src/unixMicrowitchOps.c
gcc -m64 -o checkmicrobit unixMicrowitchOps.o
rm -f *.o
