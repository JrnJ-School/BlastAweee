using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatistic
{
    public string Key { get; }

    public string GetStatisticValue();
}
