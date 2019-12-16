using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Timeline : MonoBehaviour
{
    PlayableDirector timeline;

    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        timeline.Play();
    }
}
