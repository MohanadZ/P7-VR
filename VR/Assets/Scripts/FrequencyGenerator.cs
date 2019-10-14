using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyGenerator : MonoBehaviour
{
    [Range(1, 500)]
    [SerializeField] float audioFrequency = 100f;
    [SerializeField] float audioDuration = 2f;
    [SerializeField] bool synchronizeWithObject = true;
    [SerializeField] bool synchronizeWithCamera = false;




    float sampleRate = 44100f;
    float waveLengthInSeconds = 2.0f;
    AudioSource audioSource;
    int timeIndex = 0;

    [SerializeField] Shaker shakeController;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0; //force 2D sound
        audioSource.Stop(); //avoids audiosource from starting to play automatically

        shakeController.GetComponent<Shaker>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayAudio();
        }
    }

    private void PlayAudio()
    {
        if (synchronizeWithObject && synchronizeWithCamera)
        {
            synchronizeWithObject = false;
            synchronizeWithCamera = false;
            StartCoroutine(GenerateAudio(audioDuration));
        }
        else if (synchronizeWithCamera)
        {
            audioFrequency = shakeController.CameraShakeFrequency;
            audioDuration = shakeController.CameraShakeDuration;
            StartCoroutine(GenerateAudio(audioDuration));
        }
        else if (synchronizeWithObject)
        {
            audioFrequency = shakeController.ObjectShakeFrequency;
            audioDuration = shakeController.ObjectShakeDuration;
            StartCoroutine(GenerateAudio(audioDuration));
        }
        else
        {
            StartCoroutine(GenerateAudio(audioDuration));
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
            }

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        audioSource.Stop();
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            data[i] = CreateSine(timeIndex, audioFrequency, sampleRate);

            if (channels == 2)
                data[i + 1] = CreateSine(timeIndex, audioFrequency, sampleRate);

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
