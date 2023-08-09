using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : MonoBehaviour
{
    [SerializeField] private int _maxEnergy = 50;
    [SerializeField] private float _currentEnergy;
    [SerializeField] private float _minusEnergy = 5;
    [SerializeField] private Slider _energySlider;
    [SerializeField] private Energy _energy;
    [SerializeField] private MouseDownAction _mouseDownAction;
    public float CurrentEnergy { get { return _currentEnergy; } set { _currentEnergy = value; } }
    public int MaxEnergy { get { return _maxEnergy; } set { _maxEnergy = value; } }
    // Start is called before the first frame update
    void Start()
    {
        _currentEnergy = _maxEnergy;
        _energy.SetMaxEnergy(_maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        if (_mouseDownAction.IsHoldingLMB)
        {
            EnergyDeduction();
        }
        _energySlider.value = _currentEnergy;
    }

    void EnergyMeterDeduction(float energyDeduct)
    {
        _currentEnergy -= energyDeduct * Time.deltaTime;
    }

    public void EnergyMeterAddition(float energyAdd)
    {
        _currentEnergy += energyAdd * Time.deltaTime;
    }

    void EnergyDeduction()
    {
        EnergyMeterDeduction(_minusEnergy);
    }
}
