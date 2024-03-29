# micro:witch
micro:witch は、micro:bit のためのブロック型プログラミング環境です。（based on MIT Scratch）

![screenshot1](https://raw.githubusercontent.com/EiichiroIto/microwitch/master/doc/images/screenshot1.png)

## インストールと実行方法
### Raspberry OS
```bash
wget https://github.com/EiichiroIto/microwitch-linux/releases/download/v1.2.5/microwitch_1.2.5-1_armhf.deb
sudo apt install squeak-vm squeak-plugins-scratch
sudo dpkg -i microwitch_1.2.5-1_armhf.deb
```

メニューから プログラミング - micro:witch を選んで実行してください。

### Ubuntu OS (Intel/AMD 64bit)
```bash
wget https://github.com/EiichiroIto/microwitch-linux/releases/download/v1.2.5/microwitch_1.2.5-1_amd64.deb
sudo apt install squeak-vm squeak-plugins-scratch
sudo dpkg -i microwitch_1.2.5-1_amd64.deb
```

シェルなどで microwitch を実行してください。

## 使い方
1. micro:bit をパソコンに接続します。
1. micro:bit が適当なドライブとして認識されるのを待ちます。
1. 「緑旗がクリックされたとき」で始まるプログラムを作ります。
1. デバイスメニューから「micro:bitに送信する」を選びます。
1. micro:bit でプログラムが実行されます。

## ファームウェアのアップロード
micro:witch を使うには、以下の手順で micro:bit にファームウェアを転送しておく必要があります。

1. micro:bit をパソコンに接続します。
1. パソコンが micro:bit をストレージとして認識するまで待ちます。
1. デバイスメニューから「micro:bit を初期化する」を選びます。
1. 「micro:bit を初期化しますか？」で「はい」をクリックします。
1. ファームウェアが転送され、再度 micro:bit が認識されたら完了です。

micro:bit を認識していない場合、3番目の手順でファイル選択ダイアログが表示されることがあります。接続を確認してください。

## 使い方
1. micro:bit をパソコンに接続します。
1. デバイスメニューから「micro:bitに接続する」を選びます。
2. 自動的に micro:bit に接続され、ステータス表示が「接続」から「受付中」に変わります。
5. 作成したスクリプトをクリックすると、micro:bit に転送されて実行されます。

## スクリプトの転送
作成したスクリプトをクリックしただけでは、スクリプトが micro:bit に保存されないので、電源オフや再起動によって micro:bit 内のスクリプトは失われてしまいます。

スクリプトを保存しておいて、電源が入ったら自動的に実行されるようにするには以下の手順に従ってください。

1. 「緑旗がクリックされたとき」のブロックを出します。
1. そのブロックの下に、必要なスクリプトを作ります。
1. micro:bit をパソコンに接続したら、「micro:bit に送信する」を選びます。
1. スクリプトが転送されると、micro:bit が自動的にリセットされ、スクリプトが動き出します。

実行しているスクリプトを止めるには、micro:bit に接続した状態で画面右上の赤色のボタンを押してください。

## トラブルシューティング
### ファームウェアの転送に時間がかかる
USBメモリなど他のUSB装置を抜いてから試してください。

### ファームウェアの転送がうまくできない。
いったん micro:bit をパソコンから抜き、少し待って刺し直してから再度試してください。

micro:bit とパソコンを接続しているケーブルがデータ転送用のものであることを確認してください。

DAPLink ファームウェアのバージョンが古い可能性があります。「microbit ファームウェア DAPLink 更新」で検索して、DAPLink ファームウェアを更新してください。

### 「Traceback ...」などのメッセージが表示される。または、REPL実行できない。
ファームウェアのバージョンが古い可能性があります。再度、micro:bitにファームウェアを転送してください。

古い micro:bit で micro:bit v2 で追加されたコマンド（サウンドイベントなど）を使っている可能性があります。

### micro:bit でスクリプトを実行できない。
デバイスメニューで「micro:bit に接続する」を選び、ポートを選択します。

ストップボタンを押してから「受付中」の表示を確認してください。

### 超音波センサーや拡張ボードが使えない（反応しない）
超音波センサーや拡張ボードを使ったスクリプトを作成したら、一度、「micro:bit に送信する」を実行してください。

動作に必要なプログラムが自動的に転送されます。（少し時間がかかります）

## ライセンス
GNU GENERAL PUBLIC LICENSE Version 2
