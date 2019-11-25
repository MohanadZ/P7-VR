using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement;


public class AudioFileOpener : MonoBehaviour
{
    //[SerializeField] AudioController audioController;

    ProcessStartInfo vlc1;
    ProcessStartInfo vlc2;
    ProcessStartInfo vlc3;
    ProcessStartInfo vlc4;
    
    // Shaker shaker;

    bool start = true;

    // Start is called before the first frame update
    void Start()
    {
        vlc1 = new ProcessStartInfo();
        vlc2 = new ProcessStartInfo();
        vlc3 = new ProcessStartInfo();
        vlc4 = new ProcessStartInfo();
        vlc1.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";
        vlc2.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";
        vlc3.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";
        vlc4.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";

        // shaker = GetComponent<Shaker>();
        //audioController.GetComponent<AudioController>();

        //SpikeTurbulence();

        print("I AM START");
    }

    private void Update()
    {
        //testFunc();
    }

    public void StartVibrations()
    {
        if(SceneManager.GetActiveScene().name == "Baseline Condition"){
            vlc1.Arguments = "D:\\P7-VR-Timeline\\VR\\Assets\\Audio\\TurbulenceNoise.wav";
            Process.Start(vlc1);
        }
        else if(SceneManager.GetActiveScene().name == "Camera Shake"){
            if(vlc2 == null){
                vlc2 = new ProcessStartInfo();
                vlc2.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";
            }
            vlc2.Arguments = "D:\\P7-VR-Timeline\\VR\\Assets\\Audio\\TurbulenceNoise.wav";
            Process.Start(vlc2);
        }
        
    }

    // public void testFunc(){
    //     if(Input.GetKeyDown(KeyCode.Return)){
    //         SpikeTurbulenceCamera();
    //     }
    // }
}
