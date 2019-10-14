using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [Header("Camera Shake Settings")]
    [SerializeField] float cameraShakeDuration = 2f;
    [SerializeField] float cameraShakeFrequency = 25f;
    [SerializeField] Vector3 maximumAngularShake = Vector3.one * 2;

    public float CameraShakeDuration
    {
        get
        {
            return cameraShakeDuration;
        }
        set
        {
            cameraShakeDuration = value;
        }
    }

    public float CameraShakeFrequency
    {
        get
        {
            return cameraShakeFrequency;
        }
        set
        {
            cameraShakeFrequency = value;
        }
    }

    [Header("Object Shake Settings")]
    [SerializeField] float objectShakeDuration = 2f;
    [SerializeField] float objectShakeFrequency = 25f;
    [SerializeField] Vector3 maximumTranslationShake = Vector3.one * 0.5f;

    public float ObjectShakeDuration
    {
        get
        {
            return objectShakeDuration;
        }
        set
        {
            objectShakeDuration = value;
        }
    }

    public float ObjectShakeFrequency
    {
        get
        {
            return objectShakeFrequency;
        }
        set
        {
            objectShakeFrequency = value;
        }
    }

    [Header("Gameobjects")]
    [SerializeField] ObjectShaker shakeableObject;
    [SerializeField] CameraShaker vrCamera;

    // Start is called before the first frame update
    void Start()
    {
        shakeableObject.GetComponent<ObjectShaker>();
        vrCamera.GetComponent<CameraShaker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //vrCamera.ShakeCamera(cameraShakeDuration, maximumAngularShake.x, maximumAngularShake.y, maximumAngularShake.z, cameraShakeFrequency);

            shakeableObject.ShakeObject(objectShakeDuration, maximumTranslationShake.x, maximumTranslationShake.y, maximumTranslationShake.z, objectShakeFrequency);

        }
    }
}