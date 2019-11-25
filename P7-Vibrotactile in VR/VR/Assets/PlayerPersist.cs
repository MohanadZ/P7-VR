using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayerPersist : MonoBehaviour
{
    // private void Awake() {
    //     int numOfPassenger = FindObjectsOfType<Player>().Length;

    //     if(numOfPassenger > 1){
    //         Destroy(gameObject);
    //     }
    //     else{
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }

    // private void Start() {
        
    // }

    // private void Update() {
    //     HandCollider obj = FindObjectOfType<HandCollider>();
    //     int numHandCollider = FindObjectsOfType<HandCollider>().Length;

    //     if(numHandCollider > 2){
    //         Destroy(FindObjectOfType<HandCollider>().gameObject);
    //     }
    //     else{
    //          DontDestroyOnLoad(FindObjectOfType<HandCollider>().gameObject);
    //     } 

    //     Debug.Log("Hand Collider is: " + numHandCollider);
    //     Debug.Log("Hash code is " + FindObjectOfType<HandCollider>().gameObject.GetHashCode());
    // }
}