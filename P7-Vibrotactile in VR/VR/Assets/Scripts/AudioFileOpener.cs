using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class AudioFileOpener : MonoBehaviour
{
    [SerializeField] AudioController audioController;

    ProcessStartInfo vlc;
    Shaker shaker;

    void Start()
    {
        vlc = new ProcessStartInfo();
        vlc.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";

        shaker = GetComponent<Shaker>();
        audioController.GetComponent<AudioController>();
    }

    public void StartVibrations()
    {
        vlc.Arguments = "D:\\P7-VR-Timeline\\VR\\Assets\\Audio\\TurbulenceNoise.wav";
        Process.Start(vlc);
    }
}
