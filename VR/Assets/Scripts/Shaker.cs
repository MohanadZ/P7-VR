using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [Header("Camera Shake Settings")]
    [SerializeField] float cameraShakeDuration = 2f;
    [SerializeField] float cameraShakeFrequency = 100f;
    [SerializeField] Vector3 maximumAngularShake = Vector3.one * 2;

    [Header("Object Shake Settings")]
    [SerializeField] float objectShakeDuration = 2f;
    [SerializeField] float objectShakeFrequency = 100f;
    [SerializeField] Vector3 maximumTranslationShake = Vector3.one * 0.5f;

    [Header("Audio Frequency / Synchronization")]

    [Range(1, 20000)]  //Creates a slider in the inspector
    [SerializeField] float audioFrequency = 100f;
    [SerializeField] float audioDuration = 2f;

    [Header("Gameobjects")]
    [SerializeField] ObjectShaker shakeableObject;
    [SerializeField] CameraShaker vrCamera;
    [SerializeField] FrequencySynchronization frequencyGenerator;

    // Start is called before the first frame update
    void Start()
    {
        shakeableObject.GetComponent<ObjectShaker>();
        vrCamera.GetComponent<CameraShaker>();
        frequencyGenerator.GetComponent<FrequencySynchronization>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //vrCamera.ShakeCamera(cameraShakeDuration, maximumAngularShake.x, maximumAngularShake.y, maximumAngularShake.z, cameraShakeFrequency);

            shakeableObject.ShakeObject(objectShakeDuration, maximumTranslationShake.x, maximumTranslationShake.y, maximumTranslationShake.z, objectShakeFrequency);

            frequencyGenerator.GenerateAudio(audioDuration, audioFrequency);

        }
    }
}
