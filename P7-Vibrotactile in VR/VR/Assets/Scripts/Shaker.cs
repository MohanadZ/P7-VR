using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [Header("Camera Shake Settings")]
    [SerializeField] float cameraShakeDuration = 2f;
    [SerializeField] float cameraShakeFrequency = 25f;
    [SerializeField] Vector3 maximumAngularShakeCamera = Vector3.one * 2;

    [Header("Object Shake Settings")]
    [SerializeField] float objectShakeDuration = 2f;
    [SerializeField] float objectShakeFrequency = 25f;
    [SerializeField] Vector3 maximumAngularShakeObject = Vector3.one * 2;

    [Header("Gameobjects")]
    [SerializeField] ObjectShaker shakeableObject;
    CameraShaker vrCamera;
    [SerializeField] RollCan can;

    // Start is called before the first frame update
    void Start()
    {
        vrCamera = FindObjectOfType<CameraShaker>();

        shakeableObject.GetComponent<ObjectShaker>();
        vrCamera.GetComponent<CameraShaker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //vrCamera.ShakeCamera(cameraShakeDuration, maximumAngularShakeCamera.x, maximumAngularShakeCamera.y, maximumAngularShakeCamera.z, cameraShakeFrequency);

            //shakeableObject.ShakeObject(objectShakeDuration, serverDelay, maximumTranslationShake.x, maximumTranslationShake.y, maximumTranslationShake.z, objectShakeFrequency);

        }
    }

    public void ShakeCamera(float duration)
    {
        vrCamera.ShakeCamera(duration, maximumAngularShakeCamera.x, 
            maximumAngularShakeCamera.y, maximumAngularShakeCamera.z, cameraShakeFrequency);
    }

    public void ShakeObject(float duration)
    {
        shakeableObject.ShakeObject(duration, maximumAngularShakeObject.x,
            maximumAngularShakeObject.y, maximumAngularShakeObject.z, objectShakeFrequency);

        can.RollTheDamnCan();
    }
}