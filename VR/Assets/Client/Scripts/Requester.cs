using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using UnityEngine;


///     You can copy this class and modify Run() to suits your needs.
///     To use this class, you just instantiate, call Start() when you want to start and Stop() when you want to stop.


public class Requester : RunAbleThread
{
    ///     Stop requesting when Running=false.

    public float requesterfrequency;
    public float requesterDuration;
    public float requesterPlayAudio;

    // make public getter and setter for these two variables

    public static string[] errorFeedback;

    protected override void Run()
    {
        ForceDotNet.Force(); 

        using (RequestSocket client = new RequestSocket())
        {
            client.Connect("tcp://localhost:5555");

            while(Running)
            {
                if (Send)
                {
                    // Send both frequency and duration together here and split them in Python afterwards.
                    client.SendFrame(requesterfrequency.ToString() + "," + requesterDuration.ToString() + "," + requesterPlayAudio.ToString());

                    string message = null;
                    bool gotMessage = false;

                    while (Running)
                    {
                        gotMessage = client.TryReceiveFrameString(out message); // this returns true if it's successful
                        if (gotMessage) break;
                    }
                    if (gotMessage)
                    {
                        //Debug.Log("Received " + message);
                    }
                }       
            }
        }

        NetMQConfig.Cleanup();
    }
}