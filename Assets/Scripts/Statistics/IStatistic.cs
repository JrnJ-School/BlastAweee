using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatistic
{
    public enum StatisticValueType
    {
        Int,
        Float,
        String
    }

    public string Key { get; }

    public StatisticValueType StatisticType { get; }

    public object GetStatisticValue();
}
