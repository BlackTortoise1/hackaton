using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    // Use this for initialization
    
	public void Play (string SceneName) {
        SceneManager.LoadScene(SceneName);

    }

    public void Exit()
    {
        Application.Quit();   
    }

    // Update is called once per frame
    void Update () {
		
	}
}
