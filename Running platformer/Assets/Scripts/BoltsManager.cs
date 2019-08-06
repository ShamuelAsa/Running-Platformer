using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoltsManager : MonoBehaviour
{
    private Text bolts_T;
    public int _currencyBolts;
    public Player playerS;
    void Awake()
    {
        {
            _currencyBolts = PlayerPrefs.GetInt("_Bolts");
            Debug.Log("Loaded!");
        }
    }
    void Start()
    {
        bolts_T = GetComponent<Text>();
    }

    void Update()
    {
        bolts_T.text = _currencyBolts + " Bolts";
        if (playerS._gameOver == true)
        {
            PlayerPrefs.SetInt("_Bolts", _currencyBolts);
            Debug.Log("Got _Bolts!");
        }
    }
}
