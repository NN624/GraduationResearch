#!/usr/local/bin/python3
# -*- coding:utf-8 -*-

import numpy as np
import sys

import pyqtgraph as pg
from pyqtgraph.Qt import QtCore, QtGui

import pyaudio

sample_rate = 16000
frame_length = 1024
frame_shift = 80


class PlotWindow:
    def __init__(self):

        self.win = pg.GraphicsLayoutWidget(show=True)
        self.win.setWindowTitle(u"波形のリアルタイムプロット")
        self.win.resize(1100, 800)
        self.plt = self.win.addPlot()  # プロットのビジュアル関係
        self.ymin = -100
        self.ymax = 80
        self.plt.setYRange(-1.0, 1.0)  # y軸の上限、下限の設定
        self.curve = self.plt.plot(pen='b')  # プロットデータを入れる場所
        self.curve2 = self.plt.plot(pen='r')  # プロットデータを入れる場所
        self.curve3 = self.plt.plot()

        # マイク設定
        self.CHUNK = frame_length  # 1度に読み取る音声のデータ幅
        self.RATE = sample_rate  # サンプリング周波数
        self.audio = pyaudio.PyAudio()
        self.stream = self.audio.open(format=pyaudio.paInt16,
                                      channels=1,
                                      rate=self.RATE,
                                      input=True,
                                      output=True,
                                      frames_per_buffer=self.CHUNK)

        # アップデート時間設定
        self.timer = QtCore.QTimer()
        self.timer.timeout.connect(self.update)
        self.timer.start(5) 

        self.data = np.zeros(self.CHUNK)

    def update(self):
        # self.data = self.AudioInput()
        # self.sound = self.data
        # self.stream.write(self.data)
        # self.sound = np.frombuffer(self.data, dtype=np.int16)
        # self.sound = self.sound * -1
        # self.sound = np.zeros((1, self.CHUNK))
        # self.sound[0] = np.frombuffer(self.data, dtype=np.int16)
        # self.sound = np.reshape(self.sound.T, (self.CHUNK * 1))
        # self.sound = self.sound.astype(np.int16).tostring()

        # self.stream.write(self.sound)
        # self.stream.write(self.sound.astype(np.int16).tobytes() * 32768)
        # self.sound = np.frombuffer(self.stream.read(self.CHUNK), dtype="int16") / 32768
        # print(self.data)
        # file = open("output.json", "w")
        # file.write(str(self.data))
        # file.close()
        # print(type(self.data))
        
        # self.sound_inverted = self.sound * -1
        # self.stream.write(self.sound.astype(np.int16).tobytes(), self.CHUNK)
        # self.stream.write(self.sound_inverted.astype(np.int16).tobytes(), self.CHUNK)
        # マイクのデータを取得
        self.data = self.stream.read(self.CHUNK)
        self.sound = self.data
        # 音データを逆にした
        self.sound_inverted = self.sound * -1
        # 音データを合成した
        self.combined = self.sound + self.sound_inverted
        # 音の出力
        self.stream.write(self.sound)
        self.stream.write(self.sound_inverted)
        self.stream.write(self.combined)
        # 波形のデータをセット
        self.curve.setData(np.frombuffer(self.sound, dtype=np.int16)/32768)
        self.curve2.setData(np.frombuffer(self.sound_inverted, dtype=np.int16)/32768)
        self.curve3.setData(np.frombuffer(self.combined, dtype=np.int16)/32768)


    # def AudioInput(self):
    #     ret = self.stream.read(self.CHUNK)
    #     self.stream.write(ret)
    #     ret = np.frombuffer(ret, dtype="int16") / 32768
    #     return ret


if __name__ == "__main__":
    plotwin = PlotWindow()

    if (sys.flags.interactive != 1) or not hasattr(QtCore, 'PYQT_VERSION'):
        QtGui.QApplication.instance().exec_()