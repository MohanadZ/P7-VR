using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            SceneManager.LoadScene("Baseline Condition");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            SceneManager.LoadScene("Camera Shake");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){
            SceneManager.LoadScene("Object Shake");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4)){
            SceneManager.LoadScene("Combined Shake");
        }
    }
}
