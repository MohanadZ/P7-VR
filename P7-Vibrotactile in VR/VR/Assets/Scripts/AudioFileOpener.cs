using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class AudioFileOpener : MonoBehaviour
{
    [SerializeField] AudioController audioController;

    ProcessStartInfo vlc;
    Shaker shaker;

    // Start is called before the first frame update
    void Start()
    {
        vlc = new ProcessStartInfo();
        vlc.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";

        shaker = GetComponent<Shaker>();
        audioController.GetComponent<AudioController>();

        //SpikeTurbulence();
    }

    private void Update()
    {
        //testFunc();
    }

    public void StartVibrations()
    {
        vlc.Arguments = "D:\\P7-VR-Timeline\\VR\\Assets\\Audio\\TurbulenceNoise.wav";
        Process.Start(vlc);
    }

    // public void testFunc(){
    //     if(Input.GetKeyDown(KeyCode.Return)){
    //         SpikeTurbulenceCamera();
    //     }
    // }
}
