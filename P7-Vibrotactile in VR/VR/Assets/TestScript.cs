using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class TestScript : MonoBehaviour
{
    ProcessStartInfo vlc;

    // Start is called before the first frame update
    void Start()
    {
        vlc = new ProcessStartInfo();
        hi();
    }

    public ProcessStartInfo hi(){
        vlc.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";
        return vlc;
    }
}
