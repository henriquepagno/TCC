using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void ButtonPlay()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ButtonAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene("Level1");
    }
}
