using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using TMPro;

public class HelloClient : MonoBehaviour
{
    private HelloRequester _helloRequester;
    public bool SendPack = true;

    private void Start()
    {
        _helloRequester = new HelloRequester();
        _helloRequester.Start();
        _helloRequester.frequency = 200;
    }

    void Update()
    {
        if (SendPack)
        {
            _helloRequester.Continue();
        }
        else if (!SendPack)
        {
            _helloRequester.Pause();
        }
    }


    private void OnDestroy()
    {
        _helloRequester.Stop();
    }
}
