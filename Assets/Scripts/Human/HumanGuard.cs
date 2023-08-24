using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGuard : MonoBehaviour
{
    [SerializeField] private float _sleepTime;
    [SerializeField] private float _wakeTime;
    private float _timeHolder;

    [SerializeField] private bool _isAwake;

    [SerializeField] private Animator _humanAnim;

    public MouseDownAction MouseDownAction;

    //[SerializeField] private float _timer = Time.deltaTime;

    private void Start()
    {
      _timeHolder = _sleepTime;
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
            _wakeTime = _timeHolder;
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
            ResetTime();
        }

        if (_isAwake)
        {
            if (!MouseDownAction.IsHoldingLMB)
            {
                Debug.Log("game over");
                GameManager.Instance.GameOverBool = true;
                GameObject.Find("Guy").GetComponent<HumanGuard>().enabled = false;
            }
        }
    }

    void ResetTime()
    {
        _sleepTime = _timeHolder;
    }

   /* public void WakeUp()
    {
        if(_sleepTime < 0)
        {
            _sleepTime -= Time.deltaTime;
            if (_sleepTime <= 0)
            {
                _isAwake = true;
            }
            Debug.Log("Wake Up");
            if(_isAwake)
            {
                if (!MouseDownAction.IsHoldingLMB)
                {
                    Debug.Log("game over");
                }
            }
        }*/
}
