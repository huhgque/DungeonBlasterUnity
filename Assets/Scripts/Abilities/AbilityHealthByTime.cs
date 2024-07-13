using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHealthByTime : Ability
{
    [SerializeField] float healthColdown;
    [SerializeField] int healthAmount;
    float coldownCounter = 0;
    void Update() {
        coldownCounter+= Time.deltaTime;
        if (coldownCounter < healthColdown) return;
        coldownCounter = 0;
        Player.Instance.Heal(healthAmount);
    }
    public override void AbilityAction<T>(object sender, T args)
    {
        throw new System.NotImplementedException();
    }

    public override void ApplyStatModifier(WeaponSO accumulateStat)
    {
        AbilityHealthByTime heal = Instantiate(this,Player.Instance.transform);
    }
}
