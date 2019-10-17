using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyGeneratorClient : MonoBehaviour
{
    private Requester _requester;
    public bool SendPack = true;

    [Range(1, 500)]
    [SerializeField] float audioFrequency = 100f;
    [SerializeField] float audioDuration = 2f;
    [SerializeField] bool synchronizeWithObject = true;
    [SerializeField] bool synchronizeWithCamera = false;

    //float sampleRate = 44100f;
    //float waveLengthInSeconds = 2.0f;
    //AudioSource audioSource;
    //int timeIndex = 0;

    [SerializeField] Shaker shakeController;

    void Start()
    {
        _requester = new Requester();
        _requester.Start();

        //audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.playOnAwake = false;
        //audioSource.spatialBlend = 0; //force 2D sound
        //audioSource.Stop(); //avoids audiosource from starting to play automatically

        shakeController.GetComponent<Shaker>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SetAudioValues();
            StartCoroutine(StopPlayback(audioDuration));
        }

        if (SendPack)
        {
            _requester.Continue();
        }
        else if (!SendPack)
        {
            _requester.Pause();
        }
    }

    private void SetAudioValues()
    {
        if (synchronizeWithObject && synchronizeWithCamera)
        {
            synchronizeWithObject = false;
            synchronizeWithCamera = false;
            _requester.requesterfrequency = audioFrequency;
            _requester.requesterDuration = audioDuration;
            _requester.requesterPlayAudio = 1;
          //_requester.requesterPlayAudio = 0;
        }
        else if (synchronizeWithCamera)
        {
            audioFrequency = shakeController.CameraShakeFrequency;
            audioDuration = shakeController.CameraShakeDuration;
            _requester.requesterfrequency = audioFrequency;
            _requester.requesterDuration = audioDuration;
            _requester.requesterPlayAudio = 1;
            //_requester.requesterPlayAudio = 0;
        }
        else if (synchronizeWithObject)
        {
            audioFrequency = shakeController.ObjectShakeFrequency;
            audioDuration = shakeController.ObjectShakeDuration;
            _requester.requesterfrequency = audioFrequency;
            _requester.requesterDuration = audioDuration;
            _requester.requesterPlayAudio = 1;
           //_requester.requesterPlayAudio = 0;
        }
        else
        {
            _requester.requesterfrequency = audioFrequency;
            _requester.requesterDuration = audioDuration;
            _requester.requesterPlayAudio = 1;
            //_requester.requesterPlayAudio = 0;
        }
    }

    IEnumerator StopPlayback(float duration)
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            Debug.Log(timeElapsed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Done");
        _requester.requesterPlayAudio = 0;
 
    }

    //IEnumerator PlayAudio(float duration)
    //{
    //    float timeElapsed = 0f;

    //    while (timeElapsed < duration)
    //    {
    //        {
    //            _requester.requesterPlayAudio = 1;
    //        }

    //        timeElapsed += Time.deltaTime;
    //        yield return null;
    //    }

    //    _requester.requesterPlayAudio = 0;
    //}

    //void OnAudioFilterRead(float[] data, int channels)
    //{
    //    for (int i = 0; i < data.Length; i += channels)
    //    {
    //        data[i] = CreateSine(timeIndex, audioFrequency, sampleRate);

    //        if (channels == 2)
    //            data[i + 1] = CreateSine(timeIndex, audioFrequency, sampleRate);

    //        timeIndex++;

    //        //if timeIndex gets too big, reset it to 0
    //        if (timeIndex >= (sampleRate * waveLengthInSeconds))
    //        {
    //            timeIndex = 0;
    //        }
    //    }
    //}

    ////Creates a sinewave
    //public float CreateSine(int timeIndex, float frequency, float sampleRate)
    //{
    //    return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate);
    //}
}
