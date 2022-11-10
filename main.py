'''
 README

 * マイクの入力をそのまま出力するだけのプログラム
'''

import pyaudio
import time
import numpy as np

from pydub import AudioSegment
from pydub.playback import play

class AudioFilter():
    def __init__(self):
        # オーディオに関する設定
        self.p = pyaudio.PyAudio()
        self.channels = 2 # マイクがモノラルの場合は1にしないといけない
        self.rate = 48000 # DVDレベルなので重かったら16000にする
        self.format = pyaudio.paInt16
        self.stream = self.p.open(
                        format=self.format,
                        channels=self.channels,
                        rate=self.rate,
                        output=True,
                        input=True,
                        stream_callback=self.callback)

    # コールバック関数（再生が必要なときに呼び出される）
    def callback(self, in_data, frame_count, time_info, status):
        # out_data = in_data
        # print(np.fromstring(in_data, dtype="int16"))

        # in_dataをndarrayに変換
        in_data = np.fromstring(in_data, dtype="int16")
        # in_dataの符号を逆にする
        in_data = -in_data
        # ndarrayをバイナリに変換
        out_data = in_data.astype(np.int16).tostring()
        return (out_data, pyaudio.paContinue)

    def close(self):
        self.p.terminate()

if __name__ == "__main__":
    # AudioFilterのインスタンスを作る場所
    af = AudioFilter()

    # ストリーミングを始める場所
    af.stream.start_stream()

    # ノンブロッキングなので好きなことをしていていい場所
    while af.stream.is_active():
        time.sleep(0.1)

    # ストリーミングを止める場所
    af.stream.stop_stream()
    af.stream.close()
    af.close()