using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStatistic : Statistic
{
    public override string Key => "Deaths";

    public override StatisticValueType StatisticType => StatisticValueType.Int;

    public int Value { get; set; }

    public DeathStatistic()
    {
        Value = PlayerPrefs.GetInt(Key);
    }

    public override object GetStatisticValue()
    {
        return Value;
    }

    public override string GetStatisticValueAsString()
    {
        return Value.ToString();
    }

    public override void AddValue(object value)
    {
        Value += (int)value;
        base.AddValue(value);
    }

    public override void SetValue(object value)
    {
        Value = (int)value;
        base.SetValue(value);
    }
}
