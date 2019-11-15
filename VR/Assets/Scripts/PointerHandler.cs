using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class PointerHandler : MonoBehaviour
{
    [SerializeField] SteamVR_LaserPointer laserPointer;
    [SerializeField] Image buttonImg;
    [SerializeField] Timeline timeline;
    [SerializeField] FrequencyGeneratorClient audioFreqGenerator;
    [SerializeField] Canvas canvas;
    Color initialColor;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    private void Start()
    {
        timeline.GetComponent<Timeline>();
        audioFreqGenerator.GetComponent<FrequencyGeneratorClient>();
        canvas.GetComponent<Canvas>();
        buttonImg.GetComponent<Image>();
        initialColor = buttonImg.color;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Start Button")
        {
            Debug.Log("Button was clicked");
        }
        buttonImg.color = Color.green;
        timeline.StartTimeline();
        audioFreqGenerator.StartInitalVibration();
        canvas.enabled = false;
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Start Button")
        {
            Debug.Log("Button was entered");
        }
        buttonImg.color = Color.red;
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Start Button")
        {
            Debug.Log("Button was exited");
        }
        buttonImg.color = initialColor;
    }
}
