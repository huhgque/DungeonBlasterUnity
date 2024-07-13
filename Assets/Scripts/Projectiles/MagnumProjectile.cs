using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnumProjectile : Projectile
{
    protected override void DespawnBehevior()
    {
        base.DespawnBehevior();
        float distantTraveled = (transform.position - startPos).magnitude;
        if (distantTraveled >= WeaponStat.bulletTravelDistant){
            Destroy(gameObject);
        }
    }
    
}
