using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStatistic : IStatistic
{
    public string Key => "Deaths";

    public int Value { get; set; }

    public string GetStatisticValue()
    {
        return Value.ToString();
    }
}
