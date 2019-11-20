using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using TMPro;

public class Client2 : MonoBehaviour
{
    private Requester2 _requester2;
    public bool SendPack = true;

    private void Start()
    {
        _requester2 = new Requester2();
        _requester2.Start();
    }

    void Update()
    {
        if (SendPack)
        {
            _requester2.Continue();
        }
        else if (!SendPack)
        {
            _requester2.Pause();
        }
    }


    private void OnDestroy()
    {
        _requester2.Stop();
    }
}
