using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LazerCanon : Weapon
{
    [SerializeField] float minChargeRate = 0.3f;
    public event EventHandler<OnChargeFillArgs> OnChargeFill;
    public class OnChargeFillArgs{
        public float maxCharge;
        public float currentCharge;
    }
    float chargeCounter;
    bool isCharging = false;
    void LateUpdate() {
        if (isCharging) isCharging = false;
        else {
            if (chargeCounter > minChargeRate){
                float currentPower = Math.Clamp(chargeCounter / shotColdown,0,1) ;
                chargeCounter = 0;
                OnChargeFill?.Invoke(this,new OnChargeFillArgs{maxCharge = shotColdown,currentCharge = chargeCounter});
                LazerbeamProjectile spawnProjectile = Instantiate(projectile).GetComponent<LazerbeamProjectile>();
                spawnProjectile.SetPower(currentPower);
                spawnProjectile.gameObject.transform.position = projectileSpawnLocation.transform.position;
                spawnProjectile.transform.rotation = transform.rotation;
                spawnProjectile.StartBeam();
                spawnProjectile.gameObject.SetActive(true);
                InvokeOnWeaponShot();
            }else{
                chargeCounter = 0;
                OnChargeFill?.Invoke(this,new OnChargeFillArgs{maxCharge = shotColdown,currentCharge = chargeCounter});
            }
        }
    }
    public override void Shot()
    {
        isCharging = true;
        chargeCounter += Time.deltaTime;
        OnChargeFill?.Invoke(this,new OnChargeFillArgs{maxCharge = shotColdown,currentCharge = chargeCounter});
    }
    public override void SetPosition(WeaponPostion postion)
    {
        
    }
}
