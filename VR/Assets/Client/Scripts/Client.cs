using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using TMPro;

public class Client : MonoBehaviour
{
    private Requester _requester;
    public bool SendPack = true;

    private void Start()
    {
        _requester = new Requester();
        _requester.Start();
    }

    void Update()
    {
        if (SendPack)
        {
            _requester.Continue();
        }
        else if (!SendPack)
        {
            _requester.Pause();
        }
    }


    private void OnDestroy()
    {
        _requester.Stop();
    }
}
