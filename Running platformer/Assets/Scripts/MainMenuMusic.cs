using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    AudioSource _mainMusic;
	void Start ()
    {
        _mainMusic = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        _mainMusic.volume = PlayerPrefs.GetFloat("_Music");
	}
}
