using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPlayerStatIncPercent : AbilityPlayerStatInc
{
    public override void ApplyStatModifier(WeaponSO accumulateStat)
    {
        Player.Instance.playerStat = AddStatPercent(Player.Instance.playerStat,playerStatMod);
    }
    
    PlayerStatSO AddStatPercent(PlayerStatSO statL,PlayerStatSO statR){
        statL.hp = (int) Math.Floor( statL.hp * (1f + statR.hp/100f));
        statL.size *= 1 + statR.size/100;
        statL.iframeTime *= 1 + statR.iframeTime/100;
        statL.speed *= 1 + statR.speed/100;
        return statL;
    }
}
