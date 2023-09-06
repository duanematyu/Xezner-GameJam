using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Electricity : MonoBehaviour
{
    [SerializeField] private Slider _electricityMeter;

    public virtual void SetMaxFill(int fill)
    {
        _electricityMeter.maxValue = fill;
        _electricityMeter.value = fill;
    }

    public virtual void SetFill(int fill)
    {
        _electricityMeter.value = fill;
    }
}
