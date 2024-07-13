using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected bool hasAbilityAction;
    [SerializeField] protected WeaponSO statMod;
    [SerializeField] protected EAbilityTarget abilityTarget;
    public abstract void ApplyStatModifier(WeaponSO accumulateStat);
    public abstract void AbilityAction<T>(object sender,T args);
}
