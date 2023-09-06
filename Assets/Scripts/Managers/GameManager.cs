using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum Scenes
    {
        GameScene,
        MainMenu
    }

    public static GameManager Instance;

    Tutorial tutorial;

    [SerializeField] private bool _gameOver;
    [SerializeField] private bool _youWin;
    [SerializeField] private GameObject _youWinUI;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _mainMenuUI;
    [SerializeField] private GameObject _tutorialPopUp;

    [SerializeField] private int _timesPlayed;

    public bool GameOverBool  {get { return _gameOver; } set { _gameOver = value; } }
    public bool YouWinBool { get { return _youWin; } set { _youWin = value; } }
    public GameObject MainMenuUI { get { return _mainMenuUI; } set { _mainMenuUI = value; } }
    public GameObject GameOverUI { get { return _gameOverUI; } set { _gameOverUI = value; } }
    public GameObject YouWinUI { get { return _youWinUI; } set { _youWinUI = value; } }

    public int TimesPlayed { get { return _timesPlayed; } set { _timesPlayed = value; } }
    private void Awake()
    {
        LoadData();
        DontDestroyOnLoad(this.gameObject);
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        tutorial = _tutorialPopUp.GetComponent<Tutorial>();
    }

    private void Update()
    {
        if(_gameOver)
        {
            GameOver();
        }

        if(_youWin)
        {
            Win();
        }

        if (tutorial.IsTutorialClosed)
        {
            Time.timeScale = 1f;
        }

        SaveData();
        LoadData();
    }



    public void Play()
    {
        if (_timesPlayed == 0)
        {
            _tutorialPopUp.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        MainMenuUI.SetActive(false);
        SceneManager.LoadScene(Scenes.GameScene.ToString(), LoadSceneMode.Additive);
        _timesPlayed++;
        SoundManager.Instance.PlayMusic(0);
    }

    public void Win()
    {
        TimeManager.Instance.TimerUI.SetActive(false);
        GameObject.Find("Guy").GetComponent<HumanGuard>().enabled = false;
        _youWinUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReturnToMainMenu()
    {
        SoundManager.Instance.StopMusic(0);
        SceneManager.UnloadSceneAsync(Scenes.GameScene.ToString());
        _gameOver = false;
        _youWinUI.SetActive(false);
        _gameOverUI.SetActive(false);
        _mainMenuUI.SetActive(true);
    }

    public void GameOver()
    {
        SoundManager.Instance.StopMusic(0);
        TimeManager.Instance.TimerUI.SetActive(false);
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        SoundManager.Instance.PlayMusic(0);
        SceneManager.UnloadSceneAsync(Scenes.GameScene.ToString());
        SceneManager.LoadScene(Scenes.GameScene.ToString(), LoadSceneMode.Additive);
        Time.timeScale = 1f;
        _gameOver = false;
        _youWin = false;
        TimeManager.Instance.TimerUI.SetActive(true);
        _gameOverUI.SetActive(false);
        _youWinUI.SetActive(false);
    }

    public void Tutorial()
    {
        _tutorialPopUp.SetActive(true);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("TimesPlayed", _timesPlayed);
    }

    public void LoadData()
    {
        _timesPlayed = PlayerPrefs.GetInt("TimesPlayed");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
