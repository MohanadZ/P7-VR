﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [Header("Camera Shake Settings")]
    [SerializeField] float cameraShakeDuration = 2f;
    [SerializeField] float cameraShakeFrequency = 25f;
    [SerializeField] Vector3 maximumAngularShake = Vector3.one * 2;

    [Header("Object Shake Settings")]
    [SerializeField] float objectShakeDuration = 2f;
    [SerializeField] float objectShakeFrequency = 25f;
    [SerializeField] Vector3 maximumTranslationShake = Vector3.one * 0.5f;

    [Header("Audio Frequency Settings")]
    [Range(1, 400)]  //Creates a slider in the inspector
    [SerializeField] float frequency1 = 100f;
    [SerializeField] float duration = 2f;
    [SerializeField] bool synchronize = false;
    float sampleRate = 44100f;
    float waveLengthInSeconds = 2.0f;
    int timeIndex = 0;
    float oldFrequency;

    AudioSource audioSource;

    [Header("Gameobjects")]
    [SerializeField] ObjectShaker shakeableObject;
    [SerializeField] CameraShaker vrCamera;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0; //force 2D sound
        audioSource.Stop(); //avoids audiosource from starting to play automatically

        shakeableObject.GetComponent<ObjectShaker>();
        vrCamera.GetComponent<CameraShaker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //vrCamera.ShakeCamera(cameraShakeDuration, maximumAngularShake.x, maximumAngularShake.y, maximumAngularShake.z, cameraShakeFrequency);

            shakeableObject.ShakeObject(objectShakeDuration, maximumTranslationShake.x, maximumTranslationShake.y, maximumTranslationShake.z, objectShakeFrequency);

            if (synchronize)
            {
                StartCoroutine(GenerateAudio(objectShakeDuration));
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
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            if (synchronize)
            {
                frequency1 = objectShakeFrequency;
            }
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
