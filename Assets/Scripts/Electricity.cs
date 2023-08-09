using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Electricity : MonoBehaviour
{
    [SerializeField] private Slider _electricityMeter;

    public void SetMaxEnergy(int fill)
    {
        _electricityMeter.maxValue = fill;
        _electricityMeter.value = fill;
    }

    public void SetEnergyMeter(int fill)
    {
        _electricityMeter.value = fill;
    }
}
