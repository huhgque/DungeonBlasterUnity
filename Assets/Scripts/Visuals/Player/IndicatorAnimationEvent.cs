using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorAnimationEvent : MonoBehaviour
{
    public event EventHandler OnAnimationEnd;
    public void InvokeEvent(){
        OnAnimationEnd?.Invoke(this,EventArgs.Empty);
    }
}
