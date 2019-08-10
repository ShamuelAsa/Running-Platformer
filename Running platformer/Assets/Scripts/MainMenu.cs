using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private Button _play, _settings, _exit;
    public Button _back;

    public Slider _music;
    private GameObject _menu;
    public GameObject _gameSetting;
    void Start()
    {
        Screen.SetResolution(1024, 768, false);
        _menu = GameObject.FindGameObjectWithTag("Menu");

        _settings = GameObject.Find("Settings_Button").GetComponent<Button>();
        
        _play = GameObject.Find("Play").GetComponent<Button>();

        _exit = GameObject.Find("Exit").GetComponent<Button>();

        _exit.onClick.AddListener(exitGame);
        _back.onClick.AddListener(Back);
        _play.onClick.AddListener(Play);
        _settings.onClick.AddListener(Settings);
        if(!PlayerPrefs.HasKey("_Music"))
        {
            _music.value = 0.5f;
        }
    }

    void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    void Settings()
    {
        _menu.SetActive(false);
        _gameSetting.SetActive(true);
        _music.value = PlayerPrefs.GetFloat("_Music");
    }

    void Back()
    {
        _menu.SetActive(true);
        _gameSetting.SetActive(false);
        PlayerPrefs.SetFloat("_Music", _music.value);
    }

    void exitGame()
    {
        Application.Quit();
    }
}
