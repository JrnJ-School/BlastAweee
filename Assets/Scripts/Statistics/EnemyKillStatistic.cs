using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class EnemyKillStatistic : Statistic
{
    public override string Key => "EnemiesKilled";

    public override StatisticValueType StatisticType => StatisticValueType.Int;

    public int Value { get; set; }

    public override object GetStatisticValue()
    {
        return Value;
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
