using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricityMeter : AddElectricity
{
    [SerializeField] private int _maxElectricity = 100;
    [SerializeField] private float _currentElectricity;
    [SerializeField] private float _minusElectricity= 5;
    [SerializeField] private Slider _electricitySlider;
    [SerializeField] private Electricity _electricity;
    [SerializeField] private MouseDownAction _mouseDownAction;

    // Start is called before the first frame update
    void Start()
    {
        _currentElectricity = _maxElectricity;
        _electricity.SetMaxFill(_maxElectricity);
    }

    // Update is called once per frame
    void Update()
    {
        if(!_mouseDownAction.IsHoldingLMB)
        {
            ElectricityDeduction();
        }

        else
        {
            ElectricityAddition();
        }
        _electricitySlider.value = _currentElectricity;

        if(_currentElectricity <= 0)
        {
            GameManager.Instance.GameOverBool = true;
            GameObject.Find("Electricity").GetComponent<ElectricityMeter>().enabled = false;
        }
    }

    void ElectricityMeterDeduction (float energyDeduct)
    {
        _currentElectricity -= energyDeduct * Time.deltaTime;
    }

    public void ElectricityMeterAddition(float energyAdd)
    {
        _currentElectricity += energyAdd * Time.deltaTime;
    }

    void ElectricityDeduction()
    {
        ElectricityMeterDeduction(_minusElectricity);
    }
}
