using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStatistic : IStatistic
{
    public string Key => "Deaths";

    public IStatistic.StatisticValueType StatisticType => IStatistic.StatisticValueType.Int;

    public int Value { get; set; }

    public object GetStatisticValue()
    {
        return Value.ToString();
    }
}
