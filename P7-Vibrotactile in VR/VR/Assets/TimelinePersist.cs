using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelinePersist : MonoBehaviour
{
    
    private void Awake() {
        int numOfTimeline = FindObjectsOfType<Timeline>().Length;
        
        if(numOfTimeline > 1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
