
import pyaudio
import numpy as np


class AudioClass:

    isPlaying = False

    @staticmethod
    def playback(frequency, duration):

        p = pyaudio.PyAudio()

        volume = 0.5     # range [0.0, 1.0]
        fs = 44100       # sampling rate, Hz, must be integer

        # generate samples, note conversion to float32 array
        samples = (np.sin(2*np.pi*np.arange(fs*duration)*frequency/fs)).astype(np.float32)

        # for paFloat32 sample values must be in range [-1.0, 1.0]
        stream = p.open(format=pyaudio.paFloat32,
                        channels=2,
                        rate=fs,
                        output=True)

        # play. May repeat with different volume values (if done interactively)
        
        AudioClass.isPlaying = True
        stream.write((volume*samples).tobytes())
        # stream.write(volume*samples)

        stream.stop_stream()
        stream.close()
        
        AudioClass.isPlaying = False
        p.terminate()