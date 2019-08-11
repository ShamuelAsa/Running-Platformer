using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    //Lives Counter
    private Text _lives;
    Player _playerS;

    //Distance Counter
    public int _score;
    public float _currentDistance;
    public float _currentMilestone = 100.0f;
    private TextMeshProUGUI _counter;
    public bool stopGame = false;
    public Slider _progressBar;

    //Bolts Currency Counter
    private Text bolts_T;
    public int _currencyBolts;

    //Pause Menu
    public bool _isPaused = false;
    public GameObject _pausePanel;
    public GameObject _HowToPlayPanel;
    public AudioSource _gameMusic;
    
    //Circle Energy - Projectile shots
    private Image _circleEnergy;

    //How to Play Panel
    private Button _continue;
    private int Checked = 0;
    //Buttons
    public Button ResumeB, RestartB, ExitB, HowB;
    void Awake()
    {
        _currencyBolts = PlayerPrefs.GetInt("_Bolts");
        _gameMusic.volume = PlayerPrefs.GetFloat("_Music");
    }

    void Start ()
    {
        _continue = GameObject.Find("Continue_B").GetComponent<Button>();
        _circleEnergy = GameObject.Find("CircleEnergy").GetComponent<Image>();
        bolts_T = GameObject.Find("Bolts").GetComponent<Text>();
        _counter = GameObject.Find("Text_M").GetComponent<TextMeshProUGUI>();
        _progressBar = GameObject.Find("ProgressSlider_M").GetComponent<Slider>();
        _lives = GameObject.Find("Lives").GetComponent<Text>();
        _playerS = GameObject.Find("Player").GetComponent<Player>();

        _continue.onClick.AddListener(Continued);
        ResumeB.onClick.AddListener(Resume);
        RestartB.onClick.AddListener(Restart);
        ExitB.onClick.AddListener(Exit);
        HowB.onClick.AddListener(How);

        if (!PlayerPrefs.HasKey("Check"))
        {
            Time.timeScale = 0;
            _HowToPlayPanel.SetActive(true);
        }
        else if (PlayerPrefs.HasKey("Check"))
        {
            _HowToPlayPanel.SetActive(false);
        }
    }
	
	void Update ()
    {

        _lives.text = "Lives: " + _playerS._health;

        bolts_T.text = _currencyBolts + " Bolts";

        _circleEnergy.fillAmount = (_playerS.Energy) / 100;
        if (Input.GetKeyDown(KeyCode.Escape) && _isPaused == false)
        {
            _isPaused = true;
            Time.timeScale = 0;
            _gameMusic.Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        { 
            _isPaused = false;
            _gameMusic.UnPause();
            Time.timeScale = 1;
        }

        if(_isPaused)
        {
            _pausePanel.SetActive(true);
        }
        else if(!_isPaused)
        {
            _pausePanel.SetActive(false);
        }
        _progressBar.value += _score * Time.deltaTime;
        if (_playerS._gameOver == false)
        {
            _currentDistance = _score * Time.timeSinceLevelLoad;
            _progressBar.maxValue = 100;

            if (_currentDistance >= _currentMilestone)
            {
                Debug.Log("Works");
                _currentMilestone += 100.0f;
                _progressBar.value = 0;
            }
            _counter.text = Mathf.Round(_currentMilestone) + " M";
        }
        else if (_playerS._gameOver == true)
        {
            PlayerPrefs.SetInt("_Bolts", _currencyBolts);
            _currentDistance = 0;
        }
    }

    void Continued()
    {
        PlayerPrefs.SetInt("Check", Checked);
        Checked = 1;
        _HowToPlayPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Resume()
    {
        _isPaused = false;
        Time.timeScale = 1;
    }

    void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    void Exit()
    {
        SceneManager.LoadScene(0);
    }

    void How()
    {
        _isPaused = false;
        _HowToPlayPanel.SetActive(true);
    }
}
