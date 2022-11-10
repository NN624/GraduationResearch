'''
README

* [逆位相再生](https://qiita.com/usk81/items/8284ff74e79bdbd7dbae)
'''

from pydub import AudioSegment
from pydub.playback import play

#Load an audio file
myAudioFile = "sample.mp3"
sound1 = AudioSegment.from_mp3(myAudioFile)

# Invert phase of audio file
sound2 = sound1.invert_phase()

#Merge two audio files
combined = sound1.overlay(sound2)

# play audio data
print("play sound1")
play(sound1)
print("play sound2")
play(sound2)
print("play combined")
play(combined)