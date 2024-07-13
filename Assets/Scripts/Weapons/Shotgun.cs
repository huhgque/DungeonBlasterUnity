using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    
    public override void Shot()
    {
        if (!canShot) return;
        InvokeOnWeaponShot();
        canShot = false;
        List<Projectile> projectiles = new();
        for (int i = 0; i < ModifiedStat.bulletPerShot;i++){
            Projectile bullet = Instantiate(projectile);
            bullet.WeaponStat = ModifiedStat;
            bullet.transform.position = projectileSpawnLocation.transform.position;
            bullet.transform.rotation = transform.rotation;
            projectiles.Add(bullet);
        }
        SpreadFunctionUtil.DoSpread(ModifiedStat.spreadFunction,projectiles);
        foreach (var item in projectiles)
        {
            item.gameObject.SetActive(true);
        }
    }
}
