using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    [SerializeField] private Slider _timeSlider;
    // Start is called before the first frame update
    public virtual void SetMaxFill(float fill)
    {
        _timeSlider.maxValue = fill;
        _timeSlider.value = fill;
    }

    public virtual void SetFill(float fill)
    {
        _timeSlider.value = fill;
    }
}
