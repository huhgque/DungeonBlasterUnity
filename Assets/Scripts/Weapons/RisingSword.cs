using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingSword : Weapon
{
    Vector3 startAngle;
    Vector3 lastAngle;
    protected override void Update() {
        if (!canShot) Slashing();
        if(coldownCounter >= shotColdown) {
            canShot = true;
            coldownCounter = 0;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }
    public override void Shot(){
        if (!canShot) return;
        canShot = false;
        Quaternion rots = Quaternion.AngleAxis(-ModifiedStat.spreadAngle/2,Vector3.forward);
        Quaternion rotl = Quaternion.AngleAxis(ModifiedStat.spreadAngle/2,Vector3.forward);
        startAngle = rots * transform.up;
        lastAngle = rotl * transform.up ; 
    }
    public override void SetPosition(WeaponPostion postion)
    {
        if (postion == WeaponPostion.RIGHT){
            sprite.flipX = true;
        }
    }
    void Slashing(){
        float slashProgress = coldownCounter / shotColdown;
        transform.up = Vector3.Lerp(startAngle,lastAngle,slashProgress);
        coldownCounter += Time.deltaTime;
    }
}
