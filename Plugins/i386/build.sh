#!/bin/sh
rm -f *.o MicrobitPlugin
gcc -fPIC -Wall -m32 -pedantic-errors -I ../src -c ../src/MicrowitchPlugin.c ../src/unixMicrowitchOps.c
gcc -m32 -shared *.o -o so.MicrowitchPlugin
gcc -fPIC -Wall -m32 -pedantic-errors -I ../src -DMAIN -c ../src/unixMicrowitchOps.c
gcc -m32 -o checkmicrobit unixMicrowitchOps.o
rm -f *.o
