using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IFillDeduction
{
    void FillDeduction();
}

public interface IFillMeterDeduction<T>
{
    void FillMeterDeduction(T amountToDeduct);
}

public interface IFillMeterAddition<T>
{
    void FillMeterAddition(T amountToAdd);
}

public interface IFillMeterAddition
{
    void FillMeterAddition();
}
