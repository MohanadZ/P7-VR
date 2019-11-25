using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class PointerHandler : MonoBehaviour
{
    SteamVR_LaserPointer laserPointer;
    [SerializeField] Image buttonImg;
    [SerializeField] Timeline timeline;
    [SerializeField] Canvas canvas;
    [SerializeField] AudioFileOpener audioFileOpener;
    Color initialColor;

    void Awake()
    {
        canvas.gameObject.SetActive(true);
    }

    private void Start()
    {
        laserPointer = FindObjectOfType<SteamVR_LaserPointer>();
        // timeline.GetComponent<Timeline>();
        // canvas.GetComponent<Canvas>();
        // buttonImg.GetComponent<Image>();
        // audioFileOpener.GetComponent<AudioFileOpener>();

        timeline = FindObjectOfType<Timeline>();
        canvas = FindObjectOfType<Canvas>();
        buttonImg = FindObjectOfType<Image>();
        audioFileOpener = FindObjectOfType<AudioFileOpener>();

        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;

        laserPointer.active = true;
        initialColor = buttonImg.color;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Start Button")
        {
            //Debug.Log("Button was clicked");
            buttonImg.color = Color.green;
            timeline.StartTimeline();
            audioFileOpener.StartVibrations();
            canvas.gameObject.SetActive(false);
            laserPointer.active = false;
        }

        //Debug.Log("laser is " + laserPointer.active);
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Start Button")
        {
            //Debug.Log("Button was entered");
            buttonImg.color = Color.red;
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Start Button")
        {
            //Debug.Log("Button was exited");
            buttonImg.color = initialColor;
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            timeline.StartTimeline();
            audioFileOpener.StartVibrations();
            canvas.gameObject.SetActive(false);
            laserPointer.active = false;
        }
    }
}
