using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencySynchronization : MonoBehaviour
{
    public void GenerateAudio(float duration, float frequency)
    {


        int timeIndex = 0;
        float sampleRate = 44100;
        float waveLengthInSeconds = 2.0f;

        AudioSource audioSource;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.Stop();

        StartCoroutine(CreateAudio(duration));

        void OnAudioFilterRead(float[] data, int channels)
        {
            for (int i = 0; i < data.Length; i += channels)
            {
                data[i] = CreateSine(timeIndex, frequency, sampleRate);

                if (channels == 2)
                    data[i + 1] = CreateSine(timeIndex, frequency, sampleRate);

                timeIndex++;

                //if timeIndex gets too big, reset it to 0
                if (timeIndex >= (sampleRate * waveLengthInSeconds))
                {
                    timeIndex = 0;
                }
            }

        }

        float CreateSine(int timeIndex1, float frequency1, float sampleRate1)
        {
            return Mathf.Sin(2 * Mathf.PI * timeIndex1 * frequency1 / sampleRate1);
        }

        IEnumerator CreateAudio(float duration1)
        {

            float timeElapsed = 0f;

            while (timeElapsed < duration1)
            {
                Debug.Log("Here");

                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

                timeElapsed += Time.deltaTime;
            }
            Debug.Log("Now Here");
            audioSource.Stop();
            yield return null;
        }
    }
}