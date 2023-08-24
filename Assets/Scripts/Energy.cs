using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : Electricity
{
    [SerializeField] private Slider _energyMeter;

    public override void SetMaxFill(int fill)
    {
        _energyMeter.maxValue = fill;
        _energyMeter.value = fill;
    }

    public override void SetFill(int fill)
    {
        _energyMeter.value = fill;
    }

}
