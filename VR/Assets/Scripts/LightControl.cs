using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    Light light;
    [SerializeField] float rotationSpeed = 0.2f;

    void Start()
    {
        light = GetComponent<Light>();
    }
    
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
