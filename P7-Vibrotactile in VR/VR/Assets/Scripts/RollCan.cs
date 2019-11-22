using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCan : MonoBehaviour
{
    bool hasFallenOver = false;
    private void OnTriggerEnter(Collider other) {
        hasFallenOver = true;
    }

    public void RollTheDamnCan(){
        int[] value = {-1, 1};
        int randomNum = Random.Range(0, value.Length);

        if(hasFallenOver){
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, value[randomNum] * (- 0.02f));
        }
    }
}