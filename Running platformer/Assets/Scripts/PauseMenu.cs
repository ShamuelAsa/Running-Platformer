using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button ResumeB, RestartB, ExitB;
    public UIManager UIScript;
	void Start ()
    {
        ResumeB.onClick.AddListener(Resume);
        RestartB.onClick.AddListener(Restart);
        ExitB.onClick.AddListener(Exit);
	}
	
	void Update ()
    {
		
	}

    void Resume()
    {
        UIScript._isPaused = false;
        Time.timeScale = 1;
    }

    void Restart()
    {
        Application.LoadLevel(1);
        Time.timeScale = 1;
    }
    void Exit()
    {
        Application.LoadLevel(0);
    }
}
