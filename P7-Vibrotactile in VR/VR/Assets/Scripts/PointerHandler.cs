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
    [SerializeField] Canvas canvas;
    [SerializeField] AudioFileOpener audioFileOpener;
    Color initialColor;
    [SerializeField] GameObject can, phone, bowl;
    Vector3 initialCanPosition, initialPhonePosition, initialBowlPosition;
    Quaternion initialCanRotation, initialPhoneRotation, initialBowlRotation;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    private void Start()
    {
        timeline.GetComponent<Timeline>();
        canvas.GetComponent<Canvas>();
        buttonImg.GetComponent<Image>();
        audioFileOpener.GetComponent<AudioFileOpener>();
        initialColor = buttonImg.color;
        ObjectsStartingTransform();
    }

    private void ObjectsStartingTransform()
    {
        initialCanPosition = can.transform.localPosition;
        initialCanRotation = can.transform.localRotation;
        initialBowlPosition = bowl.transform.localPosition;
        initialBowlRotation = bowl.transform.localRotation;
        initialPhonePosition = phone.transform.localPosition;
        initialPhoneRotation = phone.transform.localRotation;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Start Button")
        {
            //Debug.Log("Button was clicked");
            buttonImg.color = Color.green;
            audioFileOpener.StartVibrations();
            timeline.StartTimeline();
            canvas.gameObject.SetActive(false);
            laserPointer.active = false;
            ResetObjectsTransform();
        }
    }

    private void ResetObjectsTransform()
    {
        can.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        StartCoroutine(UnFreezeCan());
        can.transform.localRotation = initialCanRotation;
        can.transform.localPosition = initialCanPosition;
        phone.transform.localRotation = initialPhoneRotation;
        phone.transform.localPosition = initialPhonePosition;
        bowl.transform.localRotation = initialBowlRotation;
        bowl.transform.localPosition = initialBowlPosition;
    }

    IEnumerator UnFreezeCan(){
        yield return new WaitForSeconds(0.5f);
        can.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
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
}
