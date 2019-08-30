using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Deathscreen : MonoBehaviour
{
    Button ExitB;
    Button ContinueB;
    public GameObject deathScreen;
    public Player _playerScript;
    public UIManager _uiScript;
    public AudioSource _deathMusic, _gameMusic;
	void Start ()
    {
        _deathMusic.volume = PlayerPrefs.GetFloat("_Music");
        _deathMusic.Pause();
        ExitB = GameObject.Find("Exit").GetComponent<Button>();
        ContinueB = GameObject.Find("Retry").GetComponent<Button>();
        _deathMusic.volume = PlayerPrefs.GetFloat("_Music");
        deathScreen.SetActive(false);
        ExitB.onClick.AddListener(Quit);
        ContinueB.onClick.AddListener(Continue);
	}
	
	void Update ()
    {
		if(_playerScript._gameOver == true)
        {
            _gameMusic.Pause();
            _deathMusic.UnPause();
            Time.timeScale = 0;
            _uiScript.enabled = false;
            deathScreen.SetActive(true);
        }
	}

    void Continue()
    {
        _gameMusic.UnPause();
        SceneManager.LoadScene(1);
        _deathMusic.Pause();
        Time.timeScale = 1;
        _playerScript._gameOver = false;
        _uiScript.enabled = true;
    }

    private void Quit()
    {
        _gameMusic.UnPause();
        Time.timeScale = 1;
        _deathMusic.Pause();
        SceneManager.LoadScene(0);
        _playerScript._gameOver = false;
        _uiScript.enabled = true;
    }
}
