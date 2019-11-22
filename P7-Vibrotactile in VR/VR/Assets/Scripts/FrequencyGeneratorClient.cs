// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Diagnostics;

// public class FrequencyGeneratorClient : MonoBehaviour
// {
//     private Requester _requester;
//     private Requester2 _requester2;
//     public bool SendPack = true;

//     [Range(1, 500)]
//     [SerializeField] float audioFrequency = 75f;
//     [SerializeField] float audioDuration = 3f;
//     [SerializeField] bool synchronizeWithObject = false;
//     [SerializeField] bool synchronizeWithCamera = false;

//     //float sampleRate = 44100f;
//     //float waveLengthInSeconds = 2.0f;
//     //AudioSource audioSource;
//     //int timeIndex = 0;

//     [SerializeField] Shaker shakeController;
//     [SerializeField] AudioController audioController;

//     ProcessStartInfo someProgram;


//     void Start()
//     {
//         someProgram = new ProcessStartInfo();
//         someProgram.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";

//         _requester = new Requester();
//         _requester2 = new Requester2();
//         _requester.Start();
//         _requester2.Start();

//         //audioSource = gameObject.AddComponent<AudioSource>();
//         //audioSource.playOnAwake = false;
//         //audioSource.spatialBlend = 0; //force 2D sound
//         //audioSource.Stop(); //avoids audiosource from starting to play automatically

//         shakeController.GetComponent<Shaker>();
//         audioController.GetComponent<AudioController>();
//     }

//     void Update()
//     {
//         //if (Input.GetKeyDown(KeyCode.Mouse0))
//         //{
//         //    SetAudioValues();
//         //    StartCoroutine(StopPlayback(audioDuration));
//         //}

//         if (SendPack)
//         {
//             _requester.Continue();
//             _requester2.Continue();
//         }
//         else if (!SendPack)
//         {
//             _requester.Pause();
//             _requester2.Pause();
//         }
//     }

//     private void SetAudioValues()
//     {
//         if (synchronizeWithObject && synchronizeWithCamera)
//         {
//             synchronizeWithObject = false;
//             synchronizeWithCamera = false;
//             _requester.requesterfrequency = audioFrequency;
//             _requester.requesterDuration = audioDuration;
//             _requester.requesterPlayAudio = 1;
//             //_requester.requesterPlayAudio = 0;
//         }
//         else if (synchronizeWithCamera)
//         {
//             audioFrequency = shakeController.CameraShakeFrequency;
//             audioDuration = shakeController.CameraShakeDuration;
//             _requester.requesterfrequency = audioFrequency;
//             _requester.requesterDuration = audioDuration;
//             _requester.requesterPlayAudio = 1;
//             //_requester.requesterPlayAudio = 0;
//         }
//         else if (synchronizeWithObject)
//         {
//             audioFrequency = shakeController.ObjectShakeFrequency;
//             audioDuration = shakeController.ObjectShakeDuration;
//             _requester.requesterfrequency = audioFrequency;
//             _requester.requesterDuration = audioDuration;
//             _requester.requesterPlayAudio = 1;
//             //_requester.requesterPlayAudio = 0;
//         }
//         else
//         {
//             _requester.requesterfrequency = audioFrequency;
//             _requester.requesterDuration = audioDuration;
//             _requester.requesterPlayAudio = 1;
//             //_requester.requesterPlayAudio = 0;
//         }
//     }

//     IEnumerator StopPlayback(float duration)
//     {
//         float timeElapsed = 0f;

//         while (timeElapsed < duration)
//         {
//             print(timeElapsed);
//             timeElapsed += Time.deltaTime;
//             yield return null;
//         }
//         print("Done");
//         _requester.requesterPlayAudio = 0;

//     }

//     IEnumerator StopPlayback2(float duration)
//     {
//         float timeElapsed = 0f;

//         while (timeElapsed < duration)
//         {
//             print(timeElapsed);
//             timeElapsed += Time.deltaTime;
//             yield return null;
//         }
//         print("Done");
//         _requester2.requesterPlayAudio = 0;

//     }

//     public void StartInitalVibration()
//     {
//         _requester.requesterfrequency = audioFrequency;
//         _requester.requesterDuration = audioDuration;
//         _requester.requesterPlayAudio = 1;
//         StartCoroutine(StopPlayback(audioDuration));
//     }


//     public void RunExternalFile()
//     {
//         someProgram.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";
//         someProgram.Arguments = "D:\\P7-VR-Timeline\\VR\\Assets\\Audio\\SeatBeltChime.wav";
//         Process.Start(someProgram);
//     }
//     public void StartEndVibration()
//     {
//         audioController.StopTurbulenceAudio();
//         audioFrequency = 75f;
//         audioDuration = 7f;
//         _requester.requesterfrequency = audioFrequency;
//         _requester.requesterDuration = audioDuration;
//         _requester.requesterPlayAudio = 1;
//         StartCoroutine(StopPlayback(audioDuration));
//     }

//     public void CreateBaseTurbulence()
//     {
//         audioController.ChangeVolume(0.8f);
//         audioFrequency = 35f;
//         audioDuration = 4f;
//         _requester.requesterfrequency = audioFrequency;
//         _requester.requesterDuration = audioDuration;
//         _requester.requesterPlayAudio = 1;
//         StartCoroutine(StopPlayback(audioDuration));
//     }

//     public void FirstCameraShake()
//     {
//         shakeController.CameraShakeDuration = 2f;
//         shakeController.CameraShakeFrequency = 30f;
//         _requester.requesterDuration = shakeController.CameraShakeDuration;
//         _requester.requesterfrequency = shakeController.CameraShakeFrequency;
//         shakeController.ShakeCamera();
//         audioController.ChangeVolume(0.5f);
//         _requester.requesterPlayAudio = 1;
//         StartCoroutine(StopPlayback(shakeController.CameraShakeDuration));
//     }

//     public void FirstCameraShakeServer2()
//     {
//         shakeController.CameraShakeDuration = 2f;
//         shakeController.CameraShakeFrequency = 20f;
//         _requester2.requesterDuration = shakeController.CameraShakeDuration;
//         _requester2.requesterfrequency = shakeController.CameraShakeFrequency;
//         shakeController.ShakeCamera();
//         audioController.ChangeVolume(0.5f);
//         _requester2.requesterPlayAudio = 1;
//         StartCoroutine(StopPlayback2(shakeController.CameraShakeDuration));
//     }

//     public void SecondCameraShake()
//     {
//         shakeController.CameraShakeDuration = 2f;
//         shakeController.CameraShakeFrequency = 30f;
//         _requester.requesterDuration = shakeController.CameraShakeDuration;
//         _requester.requesterfrequency = shakeController.CameraShakeFrequency;
//         shakeController.ShakeCamera();
//         audioController.ChangeVolume(0.5f);
//         _requester.requesterPlayAudio = 1;
//         StartCoroutine(StopPlayback(shakeController.CameraShakeDuration));
//     }

//     public void ThirdCameraShake()
//     {
//         shakeController.CameraShakeDuration = 2f;
//         shakeController.CameraShakeFrequency = 30f;
//         _requester.requesterDuration = shakeController.CameraShakeDuration;
//         _requester.requesterfrequency = shakeController.CameraShakeFrequency;
//         shakeController.ShakeCamera();
//         audioController.ChangeVolume(0.5f);
//         _requester.requesterPlayAudio = 1;
//         StartCoroutine(StopPlayback(shakeController.CameraShakeDuration));
//     }

//     public void FirstObjectShake()
//     {
//         shakeController.ObjectShakeDuration = 2f;
//         shakeController.ObjectShakeFrequency = 30f;
//         _requester.requesterDuration = shakeController.ObjectShakeDuration;
//         _requester.requesterfrequency = shakeController.ObjectShakeFrequency;
//         shakeController.ShakeObject();
//         audioController.ChangeVolume(0.5f);
//         _requester.requesterPlayAudio = 1;
//         StartCoroutine(StopPlayback(shakeController.ObjectShakeDuration));
//     }

//     public void SecondObjectShake()
//     {
//         shakeController.ObjectShakeDuration = 2f;
//         shakeController.ObjectShakeFrequency = 30f;
//         _requester.requesterDuration = shakeController.ObjectShakeDuration;
//         _requester.requesterfrequency = shakeController.ObjectShakeFrequency;
//         shakeController.ShakeObject();
//         audioController.ChangeVolume(0.5f);
//         _requester.requesterPlayAudio = 1;
//         StartCoroutine(StopPlayback(shakeController.ObjectShakeDuration));
//     }

//     public void ThirdObjectShake()
//     {
//         shakeController.ObjectShakeDuration = 2f;
//         shakeController.ObjectShakeFrequency = 30f;
//         _requester.requesterDuration = shakeController.ObjectShakeDuration;
//         _requester.requesterfrequency = shakeController.ObjectShakeFrequency;
//         shakeController.ShakeObject();
//         audioController.ChangeVolume(0.5f);
//         _requester.requesterPlayAudio = 1;
//         StartCoroutine(StopPlayback(shakeController.ObjectShakeDuration));
//     }

//     //IEnumerator PlayAudio(float duration)
//     //{
//     //    float timeElapsed = 0f;

//     //    while (timeElapsed < duration)
//     //    {
//     //        {
//     //            _requester.requesterPlayAudio = 1;
//     //        }

//     //        timeElapsed += Time.deltaTime;
//     //        yield return null;
//     //    }

//     //    _requester.requesterPlayAudio = 0;
//     //}

//     //void OnAudioFilterRead(float[] data, int channels)
//     //{
//     //    for (int i = 0; i < data.Length; i += channels)
//     //    {
//     //        data[i] = CreateSine(timeIndex, audioFrequency, sampleRate);

//     //        if (channels == 2)
//     //            data[i + 1] = CreateSine(timeIndex, audioFrequency, sampleRate);

//     //        timeIndex++;

//     //        //if timeIndex gets too big, reset it to 0
//     //        if (timeIndex >= (sampleRate * waveLengthInSeconds))
//     //        {
//     //            timeIndex = 0;
//     //        }
//     //    }
//     //}

//     ////Creates a sinewave
//     //public float CreateSine(int timeIndex, float frequency, float sampleRate)
//     //{
//     //    return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate);
//     //}
// }
