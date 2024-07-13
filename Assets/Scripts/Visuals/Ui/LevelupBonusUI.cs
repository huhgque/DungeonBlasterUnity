using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelupBonusUI : MonoBehaviour
{
    [SerializeField] GameObject upgradePathSelector;
    [SerializeField] UpgradeSelector upgradeOptionSelector;
    [SerializeField] GameObject weaponSlotSelector;
    [SerializeField] GameObject[] uiComponents;
    GameObject currentActiveUi;
    LevelManager levelManager;
    LevelupBonusManager levelupBonusManager;
    EUpgradePath currentUpgradePath;
    WeaponPostion selectedWeaponPosition;
    int selectedOptionIndex;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = Player.Instance.GetLevelManager();
        levelupBonusManager = GameManager.Instance.GetLevelupBonusManager();
        levelManager.OnPlayerLevelUp += OnPlayerLevelUp;
        levelupBonusManager.OnLevelupBonusFinish += OnPlayerFinishLevelupBonus;
        SetUiActivate(false);
    }

    void OnPlayerLevelUp(object sender, LevelManager.OnPlayerLevelUpArgs args)
    {
        // SetUiActivate(true);
        upgradePathSelector.SetActive(true);
        currentActiveUi = upgradePathSelector;
    }
    void OnPlayerFinishLevelupBonus(object sender, EventArgs args)
    {
        SetUiActivate(false);
    }
    void SetUiActivate(bool value)
    {
        foreach (GameObject uiComp in uiComponents)
        {
            uiComp.SetActive(value);
        }
    }

    public void SelectedUpgradePath(EUpgradePath upgradePath)
    {
        currentUpgradePath = upgradePath;
        upgradePathSelector.SetActive(false);
        upgradeOptionSelector.GenerateOption(
            levelupBonusManager.FetchUpgradeOption(upgradePath)
        );
        upgradeOptionSelector.gameObject.SetActive(true);
        currentActiveUi = upgradeOptionSelector.gameObject;
    }
    public void SelectWeaponPath() => SelectedUpgradePath(EUpgradePath.WEAPON);
    public void SelectAbilityPath() => SelectedUpgradePath(EUpgradePath.ABILITY);
    public void SelectHealthPath() => SelectedUpgradePath(EUpgradePath.HEALTH);
    public void SelectGoldPath() => SelectedUpgradePath(EUpgradePath.GOLD);

    public void SelectedOption(int optionValue)
    {
        selectedOptionIndex = optionValue;
        if (currentUpgradePath == EUpgradePath.WEAPON){
            currentActiveUi.SetActive(false);
            weaponSlotSelector.SetActive(true);
        }else{
            levelupBonusManager.SelectedOption(optionValue);
        }
    }

    void SelectWeaponSlot(WeaponPostion weaponPostion){
        levelupBonusManager.SelectedOption(selectedOptionIndex,weaponPostion);
    }
    public void SelectWeaponSlotLeft() => SelectWeaponSlot(WeaponPostion.LEFT);
    public void SelectWeaponSlotRight() => SelectWeaponSlot(WeaponPostion.RIGHT);
}
