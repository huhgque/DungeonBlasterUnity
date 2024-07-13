using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance {get;private set;}
    public event EventHandler OnLeftWeaponShot;
    public event EventHandler OnRightWeaponShot;
    public event EventHandler<OnAcumulateStatChangeArgs> OnAcumulateStatChange;
    public class OnAcumulateStatChangeArgs:EventArgs{
        public WeaponSO accumulateStatModifier;
    }
    [SerializeField] Weapon leftWeapon;
    [SerializeField] Weapon rightWeapon;
    [SerializeField] GameObject leftWeaponSpawnLocation;
    [SerializeField] GameObject rightWeaponSpawnLocation;
    public WeaponSO accumulateStatModifier {get;private set;}
    List<Ability> abilities = new();
    InputManager input;
    public float ProjectileTimeScale {get;private set;} = 1f;
    void Awake() {
        Instance = this;
        accumulateStatModifier = WeaponSO.CreateInstance<WeaponSO>();
        if (leftWeapon != null){
            InitWeaponLeft(leftWeapon);
        }
        if (rightWeapon != null){
            InitWeaponRight(rightWeapon);
        }
    }
    void HandleFaceMousePos()
    {
        Vector3 mousePos = input.GetMousePositionOnWorld();
        transform.up = mousePos - transform.position;
    }
    void InitWeaponRight(Weapon weapon,bool destroyCurrent = false){
        if (destroyCurrent) Destroy(rightWeapon.gameObject);
        rightWeapon = Instantiate(weapon,rightWeaponSpawnLocation.transform);
        rightWeapon.SetPosition(WeaponPostion.RIGHT);
        rightWeapon.SetEquipSide(WeaponPostion.RIGHT);
    }
    void InitWeaponLeft(Weapon weapon,bool destroyCurrent = false){
        if(destroyCurrent) Destroy(leftWeapon.gameObject);
        leftWeapon = Instantiate(weapon,leftWeaponSpawnLocation.transform);
        leftWeapon.SetPosition(WeaponPostion.LEFT);
        leftWeapon.SetEquipSide(WeaponPostion.LEFT);
    }
    void Start() {
        input = InputManager.Instance;
    }
    void Update() {
        if (Time.timeScale == 0) return;
        HandleFaceMousePos();
        bool leftShot = input.GetLeftFire();
        bool rightShot = input.GetRightFire();
        if (leftShot) OnLeftWeaponShot?.Invoke(this,EventArgs.Empty);
        if (rightShot) OnRightWeaponShot?.Invoke(this,EventArgs.Empty);
        if (input.GetFocusWeaponJustPressed()){
            rightWeapon?.ToggleLookAtMouse();
            leftWeapon?.ToggleLookAtMouse();
        }
    }
    public void EquipWeapon(Weapon weapon,WeaponPostion weaponPostion){
        if (weaponPostion == WeaponPostion.RIGHT){
            InitWeaponRight(weapon,true);
        }else{
            InitWeaponLeft(weapon,true);
        }
    }
    public void EquipAbility(AbilitySO abilitySO){
        foreach(var abi in abilitySO.abilityBase){
            abi.ApplyStatModifier(accumulateStatModifier);
        }
        OnAcumulateStatChange?.Invoke(this,new OnAcumulateStatChangeArgs{accumulateStatModifier = accumulateStatModifier});
    }
    public Weapon GetLeftWeapon(){
        return leftWeapon;
    }
    public Weapon GetRightWeapon(){
        return rightWeapon;
    }
}
