import pyaudio  #録音機能を使うためのライブラリ
import wave     #wavファイルを扱うためのライブラリ
 
RECORD_SECONDS = 20 #録音する時間の長さ（秒）
WAVE_OUTPUT_FILENAME = "sample.wav" #音声を保存するファイル名
#録音デバイスのインデックス番号（get_device_info.pyの結果を参照してね！！）
iDeviceIndex = 3
 
#基本情報の設定
FORMAT = pyaudio.paInt16 #音声のフォーマット
CHANNELS = 1             #モノラル
RATE = 44100             #サンプルレート
CHUNK = 2**11            #データ点数
audio = pyaudio.PyAudio() #pyaudio.PyAudio()

for i in range(audio.get_device_count()):
    dev = audio.get_device_info_by_index(i)
    # print(dev['name'])
    print((i,dev['name'],dev['maxInputChannels']))
    if dev['name'] == 'ステレオ ミキサー (Realtek High Definit':
        iDeviceIndex = i
        break
 
stream = audio.open(format=FORMAT, channels=CHANNELS,
        rate=RATE, input=True,
        input_device_index = iDeviceIndex, #録音デバイスのインデックス番号
        frames_per_buffer=CHUNK)
 
#--------------録音開始---------------
 
print ("recording...")
frames = []
for i in range(0, int(RATE / CHUNK * RECORD_SECONDS)):
    data = stream.read(CHUNK)
    frames.append(data)
 
 
print ("finished recording")
 
#--------------録音終了---------------
 
stream.stop_stream()
stream.close()
audio.terminate()
 
waveFile = wave.open(WAVE_OUTPUT_FILENAME, 'wb')
waveFile.setnchannels(CHANNELS)
waveFile.setsampwidth(audio.get_sample_size(FORMAT))
waveFile.setframerate(RATE)
waveFile.writeframes(b''.join(frames))
waveFile.close()
