using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddElectricity : MonoBehaviour
{
    [SerializeField] private ElectricityMeter _electricityMeter;
    [SerializeField] private float _addElectricity = 2.5f;

    public void ElectricityAddition()
    {
        _electricityMeter.ElectricityMeterAddition(_addElectricity);
    }
}
