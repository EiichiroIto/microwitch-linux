'From MIT Squeak 0.9.4 (June 1, 2003) [No updates present.] on 29 March 2021 at 4:45:32 pm'!!MicroPythonBoard methodsFor: 'serial port'!portNames	Smalltalk isUnix ifTrue: [^ self unixPortNames].	Smalltalk isWindows ifTrue: [^ self winPortNames].	ScratchPlugin serialPortOpsAvailable ifFalse: [^ (1 to: 32)			collect: [:i | 'COM' , i printString]].	^ SerialPort2 portNames		reject: [:n | (n asLowercase includesSubString: 'modem')				or: [n asLowercase includesSubString: 'pda-sync']]! !!MicroPythonBoard methodsFor: 'serial port'!winPortNames	| str |	str := MicrowitchPlugin enumerateComPorts.	str ifNil: [^ #()].	^ str lines! !