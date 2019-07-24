﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private Button _play, _settings;
    public Button _back;

    private GameObject _menu;
    public GameObject _gameSetting;
    void Start()
    {
        _menu = GameObject.FindGameObjectWithTag("Menu");

        _settings = GameObject.Find("Settings_Button").GetComponent<Button>();
        
        _play = GameObject.Find("Play").GetComponent<Button>();


        _back.onClick.AddListener(Back);
        _play.onClick.AddListener(Play);
        _settings.onClick.AddListener(Settings);
    }

    void Play()
    {
        SceneManager.LoadScene(1);
    }

    void Settings()
    {
        _menu.SetActive(false);
        _gameSetting.SetActive(true);
    }

    void Back()
    {
        _menu.SetActive(true);
        _gameSetting.SetActive(false);
    }
}