using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadFunctionUtil
{
    static SpreadFunctionUtil spreadUtil;
    public static SpreadFunctionUtil SpreadUtil{
        get{
            if (spreadUtil == null){
                spreadUtil = new();
            }
            return spreadUtil;
        }}
    public static void DoSpread(SpreadFunction spreadType,List<Projectile> projectiles ){
        switch (spreadType){
            case SpreadFunction.BURST:
                SpreadUtil.Burst(projectiles);
                break;
            case SpreadFunction.FAN:
                SpreadUtil.Fan(projectiles);
                break;
            case SpreadFunction.RANDOM:
                SpreadUtil.Random(projectiles);
                break;
        }
    }
    void Burst(List<Projectile> projectiles){

    }
    void Fan(List<Projectile> projectiles){

    }
    void Random(List<Projectile> projectiles){
        foreach(Projectile projectile in projectiles){
            float speedMin = projectile.WeaponStat.bulletSpeed/2f;
            float speedMax = projectile.WeaponStat.bulletSpeed;
            projectile.Speed = UnityEngine.Random.Range(speedMin,speedMax);
            projectile.transform.Rotate(Vector3.forward, UnityEngine.Random.Range(-projectile.WeaponStat.spreadAngle/2,projectile.WeaponStat.spreadAngle/2));
        }
    }
}
