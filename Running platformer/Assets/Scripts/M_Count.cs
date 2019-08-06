using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class M_Count : MonoBehaviour
{
    public int _score;
    float _currentDistance;
    private Text _counter;
    public Player playerS;
    public bool stopGame = false; 
    void Awake()
    {
        _currentDistance = 0;
    }
	void Start ()
    {
        _counter = GetComponent<Text>();
	}
	
	void Update ()
    {
        if(playerS._gameOver == false)
        {
            _currentDistance = _score * Time.timeSinceLevelLoad;

            _counter.text = Mathf.Round(_currentDistance) + " M";
        }
        else if(playerS._gameOver == true)
        {
            _currentDistance = 0;
            _counter.text = Mathf.Round(_currentDistance) + " M";
        }
	}
}
