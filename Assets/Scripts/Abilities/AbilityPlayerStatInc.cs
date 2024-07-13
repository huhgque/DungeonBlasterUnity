using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPlayerStatInc : Ability
{
    [SerializeField] protected PlayerStatSO playerStatMod;
    public override void AbilityAction<T>(object sender, T args)
    {
        throw new System.NotImplementedException();
    }

    public override void ApplyStatModifier(WeaponSO accumulateStat)
    {
        Player.Instance.playerStat = AddStat(Player.Instance.playerStat,playerStatMod);
    }
    PlayerStatSO AddStat(PlayerStatSO statL,PlayerStatSO statR){
        statL.hp += statR.hp;
        statL.size += statR.size;
        statL.iframeTime += statR.iframeTime;
        statL.speed += statR.speed;
        return statL;
    }
}
