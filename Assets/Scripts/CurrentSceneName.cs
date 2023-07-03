using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrentSceneName : MonoBehaviour
{
    public Scene currentscene;
    public Text currentscenename;

    // Start is called before the first frame update
    void Start()
    {
        currentscene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        currentscenename.text = currentscene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
