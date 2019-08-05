﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesCounter : MonoBehaviour
{
    Text _lives;
    Player _playerS;
	void Start ()
    {
        _lives = GetComponent<Text>();
        _playerS = GameObject.Find("Player").GetComponent<Player>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        _lives.text = "Lives: " + _playerS._health;
	}
}
