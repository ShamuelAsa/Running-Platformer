using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class M_Count : MonoBehaviour
{
    public int _score;
    float _currentDistance;
    private Text _counter;
	void Start ()
    {
        _counter = GetComponent<Text>();
	}
	
	void Update ()
    {
        _currentDistance = _score * Time.time;

        _counter.text = Mathf.Round(_currentDistance) + " M";
	}
}
