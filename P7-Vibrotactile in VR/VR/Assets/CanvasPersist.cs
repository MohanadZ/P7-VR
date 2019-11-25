using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPersist : MonoBehaviour
{
    private void Awake() {
        int numOfCanvas = FindObjectsOfType<Canvas>().Length;
        
        if(numOfCanvas > 1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
