using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectile : Projectile
{
    protected override void DespawnBehevior()
    {
        base.DespawnBehevior();
        float distantSpeedRatio = Speed / WeaponStat.bulletSpeed;
        float distantShouldTravel = WeaponStat.bulletTravelDistant * distantSpeedRatio;
        float traveledDistant = (transform.position - startPos).magnitude;
        if (traveledDistant >= distantShouldTravel){
            Destroy(gameObject);
        }
    }
}
