using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityIncreaseStatRaw : Ability
{
    public override void AbilityAction<T>(object sender, T args)
    {
        
    }

    public override void ApplyStatModifier(WeaponSO accumulateStat)
    {
        accumulateStat += statMod * 100;
    }
}
