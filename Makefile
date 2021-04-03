install:
	install -D -m 644 microwitch.image /usr/share/microwitch/microwitch.image
	install -D -m 644 locale/ja.po /usr/share/microwitch/locale/ja.po
	install -D -m 644 locale/ja_HIRA.po /usr/share/microwitch/locale/ja_HIRA.po
	install -D -m 644 MicroPython/firmware.hex /usr/share/microwitch/MicroPython/firmware.hex
	install -m 755 microwitch /usr/bin/microwitch
	install -D -m 755 src/Plugins/armhf/so.MicrowitchPlugin /usr/lib/microwitch/plugins/so.MicrowitchPlugin
	install -m 644 microwitch.desktop /usr/share/raspi-ui-overrides/applications/

uninstall:
	-rm -f /usr/bin/microwitch
	-rm -rf /usr/share/microwitch
	-rm -rf /usr/lib/microwitch/plugins
	-rm -f /usr/share/raspi-ui-overrides/applications/microwitch.desktop
