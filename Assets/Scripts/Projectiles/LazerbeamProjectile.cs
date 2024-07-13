using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerbeamProjectile : Projectile
{
    [SerializeField] GameObject beam;
    [SerializeField] float beamMaxScaleTime = 2f;
    float beamWidth;
    float power;
    float targetSize;
    float targetLength;
    SmoothBarUtil beamScale = new();
    public void SetPower(float p) {power = p;}
    public void StartBeam(){
        targetLength = (WeaponStat.bulletTravelDistant > 0)?WeaponStat.bulletTravelDistant:1;
        targetSize = (WeaponStat.size > 0)?WeaponStat.size:1;
        beam.transform.localScale = new Vector3(0,0,0);
        beamScale.TargetFill = beamMaxScaleTime;
    }
    void Update() {
        beamScale.Update();
        float wid = Mathf.SmoothStep(0, targetSize, beamScale.delta);
        float length = Mathf.SmoothStep(0, targetLength, beamScale.delta);
        beam.transform.localScale = new Vector3(wid,length,1);
        if (beamScale.delta >= 1){
            Destroy(gameObject);
        }
    }
    public override int WeaponDamage()
    {
        return (int) Math.Floor(WeaponStat.damage * power);
    }
}
