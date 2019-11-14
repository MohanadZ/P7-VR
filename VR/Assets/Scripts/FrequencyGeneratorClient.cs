using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyGeneratorClient : MonoBehaviour
{
    private Requester _requester;
    public bool SendPack = true;

    [Range(1, 500)]
    [SerializeField] float audioFrequency = 75f;
    [SerializeField] float audioDuration = 12f;
    [SerializeField] bool synchronizeWithObject = false;
    [SerializeField] bool synchronizeWithCamera = false;

    //float sampleRate = 44100f;
    //float waveLengthInSeconds = 2.0f;
    //AudioSource audioSource;
    //int timeIndex = 0;

    [SerializeField] Shaker shakeController;
    [SerializeField] AudioController audioController;

    void Start()
    {
        _requester = new Requester();
        _requester.Start();

        //audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.playOnAwake = false;
        //audioSource.spatialBlend = 0; //force 2D sound
        //audioSource.Stop(); //avoids audiosource from starting to play automatically

        shakeController.GetComponent<Shaker>();
        audioController.GetComponent<AudioController>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    SetAudioValues();
        //    StartCoroutine(StopPlayback(audioDuration));
        //}

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

    public void StartInitalVibration()
    {
        _requester.requesterfrequency = audioFrequency;
        _requester.requesterDuration = audioDuration;
        _requester.requesterPlayAudio = 1;
        StartCoroutine(StopPlayback(audioDuration));
    }

    public void ReduceToBaseTurbulence()
    {
        audioController.ChangeVolume(0.2f);
        audioFrequency = 40f;
        audioDuration = 1f;
        _requester.requesterfrequency = audioFrequency;
        _requester.requesterDuration = audioDuration;
        _requester.requesterPlayAudio = 1;
        StartCoroutine(StopPlayback(audioDuration));
    }

    public void FirstCameraShake()
    {
        shakeController.CameraShakeDuration = 2f;
        shakeController.CameraShakeFrequency = 30f;
        _requester.requesterDuration = shakeController.CameraShakeDuration;
        _requester.requesterfrequency = shakeController.CameraShakeFrequency;
        shakeController.ShakeCamera();
        audioController.ChangeVolume(0.5f);
        _requester.requesterPlayAudio = 1;
        StartCoroutine(StopPlayback(shakeController.CameraShakeDuration));
    }

    public void SecondCameraShake()
    {
        shakeController.CameraShakeDuration = 2f;
        shakeController.CameraShakeFrequency = 30f;
        _requester.requesterDuration = shakeController.CameraShakeDuration;
        _requester.requesterfrequency = shakeController.CameraShakeFrequency;
        shakeController.ShakeCamera();
        audioController.ChangeVolume(0.5f);
        _requester.requesterPlayAudio = 1;
        StartCoroutine(StopPlayback(shakeController.CameraShakeDuration));
    }

    public void ThirdCameraShake()
    {
        shakeController.CameraShakeDuration = 2f;
        shakeController.CameraShakeFrequency = 30f;
        _requester.requesterDuration = shakeController.CameraShakeDuration;
        _requester.requesterfrequency = shakeController.CameraShakeFrequency;
        shakeController.ShakeCamera();
        audioController.ChangeVolume(0.5f);
        _requester.requesterPlayAudio = 1;
        StartCoroutine(StopPlayback(shakeController.CameraShakeDuration));
    }

    public void FirstObjectShake()
    {
        shakeController.ObjectShakeDuration = 2f;
        shakeController.ObjectShakeFrequency = 30f;
        _requester.requesterDuration = shakeController.ObjectShakeDuration;
        _requester.requesterfrequency = shakeController.ObjectShakeFrequency;
        shakeController.ShakeObject();
        audioController.ChangeVolume(0.5f);
        _requester.requesterPlayAudio = 1;
        StartCoroutine(StopPlayback(shakeController.ObjectShakeDuration));
    }

    public void SecondObjectShake()
    {
        shakeController.ObjectShakeDuration = 2f;
        shakeController.ObjectShakeFrequency = 30f;
        _requester.requesterDuration = shakeController.ObjectShakeDuration;
        _requester.requesterfrequency = shakeController.ObjectShakeFrequency;
        shakeController.ShakeObject();
        audioController.ChangeVolume(0.5f);
        _requester.requesterPlayAudio = 1;
        StartCoroutine(StopPlayback(shakeController.ObjectShakeDuration));
    }

    public void ThirdObjectShake()
    {
        shakeController.ObjectShakeDuration = 2f;
        shakeController.ObjectShakeFrequency = 30f;
        _requester.requesterDuration = shakeController.ObjectShakeDuration;
        _requester.requesterfrequency = shakeController.ObjectShakeFrequency;
        shakeController.ShakeObject();
        audioController.ChangeVolume(0.5f);
        _requester.requesterPlayAudio = 1;
        StartCoroutine(StopPlayback(shakeController.ObjectShakeDuration));
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
