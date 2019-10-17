import pyaudio
import numpy as np


class Audio:

    frequency = ""
    duration = ""

    @staticmethod
    def playback():

        p = pyaudio.PyAudio()

        volume = 0.5     # range [0.0, 1.0]
        fs = 44100       # sampling rate, Hz, must be integer
        Audio.duration = 30.0   # in seconds, may be float
        Audio.frequency = 120.0        # sine frequency, Hz, may be float

        # generate samples, note conversion to float32 array
        samples = (np.sin(2*np.pi*np.arange(fs*duration)*Audio.frequency/fs)).astype(np.float32)

        # for paFloat32 sample values must be in range [-1.0, 1.0]
        stream = p.open(format=pyaudio.paFloat32,
                        channels=2,
                        rate=fs,
                        output=True)

        # play. May repeat with different volume values (if done interactively)
        stream.write(volume*samples)

        stream.stop_stream()
        stream.close()

        p.terminate()
