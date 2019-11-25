using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPersist : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake() {
        int numOfAudio = FindObjectsOfType<Shaker>().Length;
        
        if(numOfAudio > 1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
