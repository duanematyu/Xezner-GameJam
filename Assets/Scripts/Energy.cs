using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [SerializeField] private Slider energyMeter;

    public void SetMaxEnergy(int fill)
    {
        energyMeter.maxValue = fill;
        energyMeter.value = fill;
    }

    public void SetEnergyMeter(int fill)
    {
        energyMeter.value = fill;
    }
}
