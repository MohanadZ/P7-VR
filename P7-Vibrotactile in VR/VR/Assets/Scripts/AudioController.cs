using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void PlayTurbulenceAudio()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void StopTurbulenceAudio(){
        audioSource.Stop();
    }
}
