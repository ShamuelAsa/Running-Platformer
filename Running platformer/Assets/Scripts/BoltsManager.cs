using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoltsManager : MonoBehaviour
{
    private Text bolts_T;
    public int _currencyBolts;
	void Start ()
    {
        bolts_T = GetComponent<Text>();
	}
	
	void Update ()
    {
        bolts_T.text = _currencyBolts + " Bolts";
	}
}
