using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterRest : MonoBehaviour
{
    [SerializeField] private MouseDownAction mouseDownAction;
    [SerializeField] private EnergyMeter energyMeter;
    [SerializeField] private float addEnergy = .5f;

    // Update is called once per frame
    void Update()
    {
        if (!mouseDownAction.IsHoldingLMB && energyMeter.CurrentEnergy < energyMeter.MaxEnergy)
        {
            EnergyAddition();
        }
    }

    void EnergyAddition()
    {
        energyMeter.EnergyMeterAddition(addEnergy);
    }
}
