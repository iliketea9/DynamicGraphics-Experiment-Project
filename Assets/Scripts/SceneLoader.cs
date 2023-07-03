using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using OVRTouchSample;
using System;

public class SceneLoader : MonoBehaviour 
{
    
    private int NextSceneToLoad;
    private int PreviousSceneToLoad;

    // Start is called before the first frame update
    void Start() {
        NextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        PreviousSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
    }

    // Update is called once per frame
    void Update() {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            SceneManager.LoadScene(NextSceneToLoad);
        }
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            SceneManager.LoadScene(PreviousSceneToLoad);
        }
        
    }
}
