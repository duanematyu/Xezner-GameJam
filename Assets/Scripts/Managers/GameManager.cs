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
    [SerializeField] private bool _gameOver;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _mainMenuUI;
    public bool GameOverBool  {get { return _gameOver; } set { _gameOver = value; } }
    public GameObject MainMenuUI { get { return _mainMenuUI; } set { _mainMenuUI = value; } }
    public GameObject GameOverUI { get { return _gameOverUI; } set { _gameOverUI = value; } }
    private void Awake()
    {
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

    private void Update()
    {
        if(_gameOver)
        {
            GameOver();
        }
    }



    public void Play()
    {
        MainMenuUI.SetActive(false);
        SceneManager.LoadScene(Scenes.GameScene.ToString(),LoadSceneMode.Additive);
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        SceneManager.UnloadSceneAsync(Scenes.GameScene.ToString());
        SceneManager.LoadScene(Scenes.GameScene.ToString(), LoadSceneMode.Additive);
        Time.timeScale = 1f;
        _gameOver = false;
        GameOverUI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
