using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player stat", menuName = "SO/Player/Stat")]
public class PlayerStatSO : ScriptableObject
{
    public int hp;
    public float speed;
    public float size;
    public float iframeTime;
    public static PlayerStatSO operator +(PlayerStatSO statL,PlayerStatSO statR){
        statL.hp += statR.hp;
        statL.size += statR.size;
        statL.iframeTime += statR.iframeTime;
        statL.speed += statR.speed;
        return statL;
    }
    public static PlayerStatSO operator *(PlayerStatSO statL,PlayerStatSO statR){
        statL.hp = (int) Math.Floor( statL.hp * (1f + statR.hp/100f));
        statL.size *= 1 + statR.size/100;
        statL.iframeTime *= 1 + statR.iframeTime/100;
        statL.speed *= 1 + statR.speed/100;
        return statL;
    }
    public static PlayerStatSO operator |(PlayerStatSO statL, PlayerStatSO statR){
        PlayerStatSO stat = PlayerStatSO.CreateInstance<PlayerStatSO>();
        stat.hp = statR.hp;
        stat.size = statR.size;
        stat.speed = statR.speed;
        stat.iframeTime = statR.iframeTime;
        return stat;
    }
}
