import pyaudio

# 文字化け対処法
import io, sys
sys.stdout = io.TextIOWrapper(sys.stdout.buffer, encoding='utf-8')
sys.stderr = io.TextIOWrapper(sys.stderr.buffer, encoding='utf-8')

audio = pyaudio.PyAudio()
for i in range(audio.get_device_count()):
    dev = audio.get_device_info_by_index(i)
    print((i,dev['name'],dev['maxInputChannels']))