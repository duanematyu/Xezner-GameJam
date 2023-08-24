using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterRest : MonoBehaviour
{
    [SerializeField] private EnergyMeter _energyMeter;
    [SerializeField] private float _addEnergy = .5f;

 
    public void EnergyAddition()
    {
        _energyMeter.FillMeterAddition(_addEnergy);
    }
}
