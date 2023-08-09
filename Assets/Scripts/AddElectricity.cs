using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddElectricity : MonoBehaviour
{
    [SerializeField] private MouseDownAction _mouseDownAction;
    [SerializeField] private ElectricityMeter _electricityMeter;
    [SerializeField] private float _addElectricity = 2.5f;

    // Update is called once per frame
    void Update()
    {
        if(_mouseDownAction.IsHoldingLMB)
        {
            ElectricityAddition();
        }
    }

    void ElectricityAddition()
    {
        _electricityMeter.ElectricityMeterAddition(_addElectricity);
    }
}
