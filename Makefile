install:
	install -D -m 644 microwitch.image /usr/local/share/microwitch/microwitch.image
	install -D -m 644 locale/ja.po /usr/local/share/microwitch/locale/ja.po
	install -D -m 644 locale/ja_HIRA.po /usr/local/share/microwitch/locale/ja_HIRA.po
	install -D -m 644 MicroPython/firmware.hex /usr/local/share/microwitch/MicroPython/firmware.hex
	install -m 755 microwitch /usr/local/bin/microwitch

uninstall:
	rm -f /usr/local/bin/microwitch
	rm -rf /usr/local/share/microwitch

