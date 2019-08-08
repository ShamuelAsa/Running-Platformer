using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class M_Count : MonoBehaviour
{
    public int _score;
    public float _currentDistance;
    public float _currentMilestone = 100.0f;
    private TextMeshProUGUI _counter;
    public Player playerS;
    public bool stopGame = false;
    public Slider _progressBar;
    float Timer;
    void Awake()
    {
        _currentDistance = 0;
    }
	void Start ()
    {
        _counter = GameObject.Find("Text_M").GetComponent<TextMeshProUGUI>();
        _progressBar = GetComponentInChildren<Slider>();
    }
	
	void Update ()
    {

        _progressBar.value += _score * Time.deltaTime;
        if (playerS._gameOver == false)
        {
            _currentDistance = _score * Time.timeSinceLevelLoad;
            _progressBar.maxValue = 100;

            if(_currentDistance >= _currentMilestone)
            {
                Debug.Log("Works");
                _currentMilestone += 100.0f;
                _progressBar.value = 0;
            }
            _counter.text = Mathf.Round(_currentMilestone) + " M";
        }
        else if(playerS._gameOver == true)
        {
            _currentDistance = 0;
            //_counter.text = Mathf.Round(_currentDistance) + " M";
        }
	}
}
