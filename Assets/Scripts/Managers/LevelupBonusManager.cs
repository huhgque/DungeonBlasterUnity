using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelupBonusManager : MonoBehaviour
{
    public event EventHandler OnLevelupBonusFinish;
    [SerializeField] List<UpgradeOptionSO> upgradepool = new();
    
    List<UpgradeOptionSO> weaponUpgradeOptions = new();
    List<UpgradeOptionSO> abilityUpgradeOptions = new();
    List<UpgradeOptionSO> healthUpgradeOptions = new();
    List<UpgradeOptionSO> upgradeOptions = new();
    EUpgradePath currentUpgradePath;
    void Awake() {
        foreach (var item in upgradepool)
        {
            switch (item.UpgradePath)
            {
                case EUpgradePath.WEAPON:
                    weaponUpgradeOptions.Add(item);
                    break;
                case EUpgradePath.ABILITY:
                    abilityUpgradeOptions.Add(item);
                    break;
                case EUpgradePath.HEALTH:
                    healthUpgradeOptions.Add(item);
                    break;
                default:
                    break;
            }
        }
    }
    public List<UpgradeOptionSO> FetchUpgradeOption(EUpgradePath upgradePath){
        currentUpgradePath = upgradePath;
        switch (upgradePath)
        {
            case EUpgradePath.WEAPON:
                return RandomizeOptionPool(weaponUpgradeOptions);
            case EUpgradePath.ABILITY:
                return RandomizeOptionPool(abilityUpgradeOptions);
            case EUpgradePath.HEALTH:
                return RandomizeOptionPool(healthUpgradeOptions);
            default:
                return null;
        }
    }
    List<UpgradeOptionSO> RandomizeOptionPool(List<UpgradeOptionSO> pool){
        System.Random rng = new();
        int count = pool.Count;
        while (count > 1){
            count--;
            int randomIndex = rng.Next(count+1);
            UpgradeOptionSO tmp = pool[randomIndex];
            pool[randomIndex] = pool[count];
            pool[count] = tmp;
        }
        return pool;
    }
    void FinishLevelup(){
        GameManager.Instance.ContinueGame();
        OnLevelupBonusFinish?.Invoke(this,EventArgs.Empty);
    }
    public void ConfirmLevelUp(){
        FinishLevelup();
    }
    public void SelectedOption(int optionValue){
        switch (currentUpgradePath){
            case EUpgradePath.ABILITY:
                WeaponManager.Instance.EquipAbility(abilityUpgradeOptions[optionValue].upgradeInfo as AbilitySO);
                FinishLevelup();
                break;
            default :
                Debug.Log("Error");
                break;
        }
    }
    public void SelectedOption(int optionValue,WeaponPostion postion){
        Weapon weapon = (weaponUpgradeOptions[optionValue].upgradeInfo as WeaponSO).weaponObject;
        WeaponManager.Instance.EquipWeapon(weapon,postion);
        FinishLevelup();
    }
}
