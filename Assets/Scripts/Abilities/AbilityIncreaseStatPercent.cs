using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityIncreaseStatPercent : Ability
{
    public override void AbilityAction<T>(object sender, T args)
    {
        
    }

    public override void ApplyStatModifier(WeaponSO accumulateStat)
    {
        accumulateStat %= accumulateStat + statMod;
    }
}
