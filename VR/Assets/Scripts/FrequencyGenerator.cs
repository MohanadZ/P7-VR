using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyGenerator : MonoBehaviour
{
    [Range(1, 20000)]  //Creates a slider in the inspector
    [SerializeField] float frequency1 = 100f;

    [SerializeField] float duration = 2f;
    [SerializeField] bool synchronize = false;

    [SerializeField] Shaker cameraAndObjectShaker;



    float sampleRate = 44100f;
    float waveLengthInSeconds = 2.0f;

    AudioSource audioSource;
    int timeIndex = 0;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0; //force 2D sound
        audioSource.Stop(); //avoids audiosource from starting to play automatically

        cameraAndObjectShaker.GetComponent<Shaker>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (synchronize)
            {
                StartCoroutine(GenerateAudio(duration));
            }
            else
            {
                StartCoroutine(GenerateAudio(duration));
            }
        }
    }

    IEnumerator GenerateAudio(float duration)
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            if (!audioSource.isPlaying)
            {
                timeIndex = 0;  //resets timer before playing sound
                audioSource.Play();
                Debug.Log("In If");
            }

            timeElapsed += Time.deltaTime;
            yield return null;
        }
        audioSource.Stop();
        Debug.Log(timeElapsed);
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            data[i] = CreateSine(timeIndex, frequency1, sampleRate);

            if (channels == 2)
                data[i + 1] = CreateSine(timeIndex, frequency1, sampleRate);

            timeIndex++;

            //if timeIndex gets too big, reset it to 0
            if (timeIndex >= (sampleRate * waveLengthInSeconds))
            {
                timeIndex = 0;
            }
        }
    }

    //Creates a sinewave
    public float CreateSine(int timeIndex, float frequency, float sampleRate)
    {
        return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate);
    }
}
