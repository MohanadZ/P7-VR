using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShaker : MonoBehaviour
{
    public void ShakeObject(float duration, float xMagnitude, float yMagnitude, float zMagnitude, float frequency)
    {
        StartCoroutine(Shake(duration, xMagnitude, yMagnitude, zMagnitude, frequency));
    }

    IEnumerator Shake(float duration, float xMagnitude, float yMagnitude, float zMagnitude, float frequency)
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            if(timeElapsed > 0)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(
                transform.localRotation.x,
                transform.localRotation.y,
                zMagnitude * (Mathf.PerlinNoise(2, Time.time * frequency) * 2 - 1)));
            }

            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
}
