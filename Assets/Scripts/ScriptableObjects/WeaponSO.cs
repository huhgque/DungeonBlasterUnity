using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon stat", menuName = "SO/Weapon/Stat")]
public class WeaponSO : ItemInfoSO
{
    public int bulletPerShot; 
    public int damage;
    public int pierce;
    public float bulletSpeed;
    public float bulletTravelDistant;
    public float knockBack;
    public float size;
    public float bullet;
    public float perSecond;
    public float spreadAngle;
    public SpreadFunction spreadFunction;
    public WeaponType weaponType;
    public WeaponType bestMatch;
    public string descriptionBestMatch;
    public Weapon weaponObject;
    public static WeaponSO operator +(WeaponSO weaponL,WeaponSO weaponR){
        WeaponSO weap = null;
        weap |= weaponL;
        weap.bulletPerShot += weaponR.bulletPerShot;
        weap.damage += weaponR.damage;
        weap.pierce += weaponR.pierce;
        weap.bulletSpeed += weaponR.bulletSpeed;
        weap.bulletTravelDistant += weaponR.bulletTravelDistant;
        weap.knockBack += weaponR.knockBack;
        weap.size += weaponR.size;
        weap.bullet += weaponR.bullet;
        weap.perSecond += weaponR.perSecond;
        weap.spreadAngle += weaponR.spreadAngle;
        return weap;
    }
    public static WeaponSO operator *(WeaponSO weapon,float pow){
        weapon.bulletPerShot = (int) Math.Floor(weapon.bulletPerShot * pow);
        weapon.damage = (int) Math.Floor(weapon.damage * pow);
        weapon.pierce = (int) Math.Floor(weapon.pierce * pow) ;
        weapon.bulletSpeed *= pow;
        weapon.bulletTravelDistant *= pow;
        weapon.knockBack *= pow;
        weapon.size *= pow;
        weapon.bullet *= pow;
        weapon.perSecond *= pow;
        weapon.spreadAngle *= pow;
        return weapon;
    }
    public static WeaponSO operator *(WeaponSO weaponL,WeaponSO weaponR){
        WeaponSO weap = null;
        weap |= weaponL;
        weap.bulletPerShot =(int) Math.Floor(weaponL.bulletPerShot * ( 1f + weaponR.bulletPerShot/100f )) ;
        weap.damage = (int) Math.Floor (weaponL.damage * ( 1f + weaponR.damage/100f ));
        weap.pierce = (int) Math.Floor (weaponL.pierce * ( 1 + weaponR.pierce/100f ));
        weap.bulletSpeed = weaponL.bulletSpeed * ( 1f + weaponR.bulletSpeed/100f );
        weap.bulletTravelDistant = weaponL.bulletTravelDistant * ( 1f + weaponR.bulletTravelDistant/100f );
        weap.knockBack = weaponL.knockBack * ( 1f + weaponR.knockBack/100f );
        weap.size = weaponL.size * ( 1f + weaponR.size/100f );
        weap.bullet = weaponL.bullet * ( 1f + weaponR.bullet/100f );
        weap.perSecond = weaponL.perSecond * ( 1f + weaponR.perSecond/100f );
        weap.spreadAngle = weaponL.spreadAngle * ( 1f + weaponR.spreadAngle/100f );
        return weap;
    }
    public static WeaponSO operator |(WeaponSO weaponL,WeaponSO weaponR){
        WeaponSO weap = CreateInstance<WeaponSO>();
        weap.bulletPerShot = weaponR.bulletPerShot;
        weap.damage = weaponR.damage;
        weap.pierce = weaponR.pierce;
        weap.bulletSpeed = weaponR.bulletSpeed;
        weap.bulletTravelDistant = weaponR.bulletTravelDistant;
        weap.knockBack = weaponR.knockBack;
        weap.size = weaponR.size;
        weap.bullet = weaponR.bullet;
        weap.perSecond = weaponR.perSecond;
        weap.spreadAngle = weaponR.spreadAngle;
        weap.spreadFunction = weaponR.spreadFunction;
        weap.weaponType = weaponR.weaponType;
        weap.bestMatch = weaponR.bestMatch;
        weap.descriptionBestMatch = weaponR.descriptionBestMatch;
        weap.weaponObject = weaponR.weaponObject;
        return weap;
    }
    public static WeaponSO operator %(WeaponSO weaponL,WeaponSO weaponR){
        weaponL.bulletPerShot = weaponR.bulletPerShot;
        weaponL.damage = weaponR.damage;
        weaponL.pierce = weaponR.pierce;
        weaponL.bulletSpeed = weaponR.bulletSpeed;
        weaponL.bulletTravelDistant = weaponR.bulletTravelDistant;
        weaponL.knockBack = weaponR.knockBack;
        weaponL.size = weaponR.size;
        weaponL.bullet = weaponR.bullet;
        weaponL.perSecond = weaponR.perSecond;
        weaponL.spreadAngle = weaponR.spreadAngle;
        weaponL.spreadFunction = weaponR.spreadFunction;
        weaponL.weaponType = weaponR.weaponType;
        weaponL.bestMatch = weaponR.bestMatch;
        weaponL.descriptionBestMatch = weaponR.descriptionBestMatch;
        weaponL.weaponObject = weaponR.weaponObject;
        return weaponL;
    }
}
