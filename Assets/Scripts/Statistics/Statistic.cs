using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Statistic
{
    public enum StatisticValueType
    {
        Int,
        Float,
        String
    }

    public abstract string Key { get; }

    public abstract StatisticValueType StatisticType { get; }

    public abstract object GetStatisticValue();

    public abstract string GetStatisticValueAsString();

    public virtual void SetValue(object value)
    {
        StatisticsManager.Instance.SetStatistic(this);
    }

    public virtual void AddValue(object value)
    {
        StatisticsManager.Instance.SetStatistic(this);
    }

    public Statistic()
    {
        StatisticsManager.RegisterStatistic(this);
    }
}
