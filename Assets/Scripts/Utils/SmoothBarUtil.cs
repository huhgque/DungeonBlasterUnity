using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothBarUtil
{
    /// <summary>
    /// 0 - 1
    /// </summary>
    public float CurrentFill = 0;
    float targetFill = 0;
    public float TargetFill
    {
        get
        {
            return targetFill;
        }
        set
        {
            targetFill = value;
            CurrentFillTime = 0;
        }
    }
    public float CurrentFillTime = 0;
    /// <summary>
    /// Default is 1
    /// </summary>
    public float FillSpeed = 1;
    public float delta;
    public void Update()
    {
        CurrentFillTime += Time.deltaTime;
        float t = CurrentFillTime / FillSpeed;
        delta = Math.Min(t, 1);
        CurrentFill = Mathf.SmoothStep(CurrentFill, TargetFill, t);
    }
}
