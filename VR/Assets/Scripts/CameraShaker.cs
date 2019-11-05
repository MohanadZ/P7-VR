using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public void ShakeCamera(float duration, float serverDelay, float xMagnitude, float yMagnitude, float zMagnitude, float frequency)
    {
        StartCoroutine(Shake(duration, serverDelay, xMagnitude, yMagnitude, zMagnitude, frequency));
    }

    IEnumerator Shake(float duration, float serverDelay, float xMagnitude, float yMagnitude, float zMagnitude, float frequency)
    {
        Quaternion originalRotation = transform.localRotation;
        float timeElapsed = 0f - serverDelay;

        while(timeElapsed < duration)
        {
            if(timeElapsed > 0)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(
                xMagnitude * (Mathf.PerlinNoise(3, Time.time * frequency) * 2 - 1),
                yMagnitude * (Mathf.PerlinNoise(4, Time.time * frequency) * 2 - 1),
                zMagnitude * (Mathf.PerlinNoise(5, Time.time * frequency) * 2 - 1)));
            }

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.localRotation = originalRotation;
    }
}
