using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : HamsterRest, IFillDeduction, IFillMeterDeduction<float>, IFillMeterAddition<float>
{
    [SerializeField] private int _maxEnergy = 50;
    [SerializeField] private float _currentEnergy;
    [SerializeField] private float _minusEnergy = 5;
    [SerializeField] private float _dizzyDuration = 1;
    [SerializeField] private Slider _energySlider;
    [SerializeField] private Energy _energy;
    [SerializeField] private MouseDownAction _mouseDownAction;
   
    // Start is called before the first frame update
    void Start()
    {
        _currentEnergy = _maxEnergy;
        _energy.SetMaxFill(_maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        if (_mouseDownAction.IsHoldingLMB)
        {
            FillDeduction();
        }

        if(!_mouseDownAction.IsHoldingLMB && _currentEnergy < _maxEnergy)
        {
            EnergyAddition();
        }

        if(_currentEnergy <= 0)
        {
            StartCoroutine(Dizzy(_dizzyDuration));
        }

        _energySlider.value = _currentEnergy;
    }

   
    public void FillMeterDeduction(float energyDeduct)
    {
        _currentEnergy -= energyDeduct * Time.deltaTime;
    }

    public void FillMeterAddition(float energyAdd)
    {
        _currentEnergy += energyAdd * Time.deltaTime;
    }

    public void FillDeduction()
    {
        FillMeterDeduction(_minusEnergy);
    }

    IEnumerator Dizzy(float duration)
    {
        _mouseDownAction.CanPerformAction = false;
        yield return new WaitForSeconds(duration);
        _mouseDownAction.Hamster.SetBool("isTired", false);
        _mouseDownAction.CanPerformAction = true;
    }
}
