using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShaker : MonoBehaviour
{
    public void ShakeObject(float duration, float serverDelay, float xMagnitude, float yMagnitude, float zMagnitude, float frequency)
    {
        StartCoroutine(Shake(duration, serverDelay, xMagnitude, yMagnitude, zMagnitude, frequency));
    }

    IEnumerator Shake(float duration, float serverDelay, float xMagnitude, float yMagnitude, float zMagnitude, float frequency)
    {
        float timeElapsed = 0f - serverDelay;

        while (timeElapsed < duration)
        {
            if(timeElapsed > 0)
            {
                transform.localPosition = new Vector3(
                xMagnitude * (Mathf.PerlinNoise(0, Time.time * frequency) * 2 - 1),
                yMagnitude * (Mathf.PerlinNoise(1, Time.time * frequency) * 2 - 1),
                zMagnitude * (Mathf.PerlinNoise(2, Time.time * frequency) * 2 - 1));
            }

            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
}
