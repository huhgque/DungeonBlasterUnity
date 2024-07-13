using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public event EventHandler OnWeaponShot;
    [SerializeField] protected SpriteRenderer sprite;
    public SpriteRenderer GetSprite(){return sprite;}
    [SerializeField] protected Projectile projectile;
    [SerializeField] protected GameObject projectileSpawnLocation;
    [SerializeField] protected WeaponSO weaponStat;
    public WeaponSO GetBaseStat(){return weaponStat;}
    public WeaponSO ModifiedStat {get;set;}
    protected WeaponPostion weaponPostion;
    protected float shotColdown = 0;
    protected float coldownCounter = 0;
    protected bool canShot = true;
    protected bool isLookAtMouse = false;
    void Start() {
        ModifiedStat |= weaponStat;
        shotColdown = 1 / (ModifiedStat.bullet / ModifiedStat.perSecond);
        projectile.WeaponStat = ModifiedStat;
        GameManager.Instance.OnGameStateChange += OnGameStateChange;
        projectile.gameObject.SetActive(false);
        WeaponManager.Instance.OnAcumulateStatChange += OnAcumulateStatChange;
    }
    protected virtual void Update(){
        CheckCanShot();
    }
    void FixedUpdate(){
        if (isLookAtMouse) LookAtMouse();
    }
    protected virtual void CheckCanShot(){
        if (canShot) return;
        coldownCounter += Time.deltaTime;
        if (coldownCounter >= shotColdown){
            canShot = true;
            coldownCounter = 0;
        }
    }
    void LookAtMouse(){
        Vector3 mousePos = InputManager.Instance.GetMousePositionOnWorld();
        transform.up = mousePos - transform.position;
    }
    public virtual void OnWeaponAction(object sender,EventArgs args){
        Shot();
    }
    protected virtual void InvokeOnWeaponShot(){
        OnWeaponShot?.Invoke(this,EventArgs.Empty);
    }
    public virtual void Shot(){
        if ( !canShot ) return;
        InvokeOnWeaponShot();
        canShot = false;
        Projectile bullet = Instantiate(projectile).GetComponent<Projectile>();
        bullet.transform.position = projectileSpawnLocation.transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.Speed = ModifiedStat.bulletSpeed;
        bullet.gameObject.SetActive(true);
    }
    public virtual void SetPosition(WeaponPostion postion){
        if (postion == WeaponPostion.LEFT){
            sprite.flipY = true;
        }
    }
    public void ToggleLookAtMouse(){
        isLookAtMouse = !isLookAtMouse;
    }
    public void OnGameStateChange(object sender , GameStateChangeArgs args){
        enabled = !args.isGamePause;
    }
    void OnDestroy() {
        GameManager.Instance.OnGameStateChange -= OnGameStateChange;
        WeaponManager.Instance.OnAcumulateStatChange -= OnAcumulateStatChange;
        if (weaponPostion == WeaponPostion.LEFT){
            WeaponManager.Instance.OnLeftWeaponShot -= OnWeaponAction;
        }else{
            WeaponManager.Instance.OnRightWeaponShot -= OnWeaponAction;
        }
    }
    void OnAcumulateStatChange(object sender,WeaponManager.OnAcumulateStatChangeArgs args){
        ModifiedStat %= weaponStat * args.accumulateStatModifier;
    }
    public virtual void SetEquipSide(WeaponPostion postion){
        weaponPostion = postion;
        if (postion == WeaponPostion.LEFT){
            WeaponManager.Instance.OnLeftWeaponShot += OnWeaponAction;
        }else{
            WeaponManager.Instance.OnRightWeaponShot += OnWeaponAction;
        }
    }
}
