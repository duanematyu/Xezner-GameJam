using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGuard : MonoBehaviour
{
    [SerializeField] private float _sleepTime;
    [SerializeField] private float _wakeTime;
    private float _minsleepTimeHolder = 3f;
    private float _maxsleepTimeHolder = 5f;
    private float _minwakeTimeHolder = 1f;
    private float _maxwakeTimeHolder = 2f;

    [SerializeField] private bool _isAwake;

    [SerializeField] private Animator _humanAnim;

    public MouseDownAction MouseDownAction;

    private void Start()
    {
        _wakeTime = Random.Range(_minwakeTimeHolder, _maxwakeTimeHolder);
        _sleepTime = Random.Range(_minsleepTimeHolder, _maxsleepTimeHolder);
    }

    public void Update()
    {
       Sleep();
    }

    void Sleep()
    {
        _humanAnim.SetBool("isAwake", false);
        if (_sleepTime >= 0)
        {
            _isAwake = false;
            _sleepTime -= Time.deltaTime;
            Debug.Log("Sleep");
        }
        else 
        {
            WakeUp();
        } 
    }

    void WakeUp()
    {
        _humanAnim.SetBool("isAwake", true);
        _isAwake = true;
        if (_wakeTime >= 0)
        {
            _wakeTime -= Time.deltaTime;
        }
        else
        {
            ResetSleepTime();
            ResetWakeTime();
        }

        if (_isAwake)
        {
            if (!MouseDownAction.IsHoldingLMB)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        Debug.Log("game over");
        GameManager.Instance.GameOverBool = true;
        GameObject.Find("Guy").GetComponent<HumanGuard>().enabled = false;
    }

    void ResetSleepTime()
    {
        _sleepTime = Random.Range(_minsleepTimeHolder, _maxsleepTimeHolder);
    }

    void ResetWakeTime()
    {
        _wakeTime = Random.Range(_minwakeTimeHolder, _maxwakeTimeHolder);
    }
}
