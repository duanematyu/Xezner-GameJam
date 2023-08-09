using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseDownAction : MonoBehaviour
{
    private bool _isHoldingLMB;
    [SerializeField] private Animator _hamster;
    [SerializeField] private Animator _hamsterWheel;
    [SerializeField] private ElectricityMeter _electricityMeter;
    public bool IsHoldingLMB { get { return _isHoldingLMB; } set { _isHoldingLMB = value; } }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _isHoldingLMB = true;
            Debug.Log("Play");
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isHoldingLMB = false;
        }

        HamsterRun();
    }

    void HamsterRun()
    {
        if (_isHoldingLMB)
        {
            PlayRunAnimation();
        }

        else
        {
            StopAnimation();
        }
    }

    void PlayRunAnimation()
    {
        _hamster.SetTrigger("Run");
        _hamster.SetBool("isResting", false);
        _hamsterWheel.SetBool("hamsterIsRunning", true);
    }

    void StopAnimation()
    {
        _hamster.ResetTrigger("Run");
        _hamsterWheel.SetBool("hamsterIsRunning", false);
        _hamster.SetBool("isResting", true);
    }

    void FillMeter()
    {

    }
}
