using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [SerializeField] private float _maxTime;
    private float _currentTime;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TimerSlider timerSlider;

    public GameObject TimerUI;

    public float CurrentTime { get { return _currentTime; } set { _currentTime = value; } }
    public float MaxTime { get { return _maxTime; } set { _maxTime = value; } }
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        SetMaxTime();
    }

    // Update is called once per frame
    void Update()
    {
        SetCurrentTimer();
        
        if (_currentTime <= 0)
        {
            YouWin();
        }

        if(GameManager.Instance.YouWinBool || GameManager.Instance.GameOverBool)
        {
            ResetTimer();
        }
    }

    void SetMaxTime()
    {
        timerSlider.SetMaxFill(_maxTime);
        timerText.text = _maxTime.ToString();
        _currentTime = _maxTime;
    }

    void SetCurrentTimer()
    {
        _currentTime -= 1 * Time.deltaTime;
        timerSlider.SetFill(_currentTime);
        timerText.text = _currentTime.ToString("0");
    }

    void YouWin()
    {
        _currentTime = 0;
        GameManager.Instance.YouWinBool = true;
    }

    void ResetTimer()
    {
        _currentTime = _maxTime;
    }
}
