using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ScalableHeight : MonoBehaviour
{
    [SerializeField] float initialHeight = 0.7f;
    [SerializeField] GameObject rightHand, leftHand;
    [SerializeField] Camera camera;
    //[SerializeField] float cameraSpeed = 2.0f;

    float currentHeight, scaleFactor;

    void Update()
    {
        AutoAdjustHeight();
        //PlayerAdjustHeight();
    }

    private void AutoAdjustHeight()
    {
        currentHeight = camera.transform.localPosition.y;
        scaleFactor = initialHeight / currentHeight;

        //Debug.Log("Camera Height is " + currentHeight);
        //Debug.Log("Scale is " + scaleFactor);

        transform.localScale = Vector3.one * scaleFactor;
        rightHand.transform.localScale = Vector3.one * scaleFactor;
        leftHand.transform.localScale = Vector3.one * scaleFactor;

        //Debug.Log("Scale Factor is " + scaleFactor);
        //Debug.Log("Right Hand is " + rightHand.transform.localScale);
        //Debug.Log("Camera position is " + transform.localScale);
    }

    //private void PlayerAdjustHeight()
    //{
    //    float height = 0.0f;

    //    //var playerControl = Input.GetAxis("Player Height");
    //    //print("..... " + playerControl);

    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        height += Vector3.up.y;
    //    }
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        height -= Vector3.up.y;
    //    }

    //    transform.position += new Vector3(0, height * cameraSpeed * Time.deltaTime, 0);
    //}
}
