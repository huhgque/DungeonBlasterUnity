using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectOption : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] Button confirmButton;
    [SerializeField] LevelupBonusUI levelupBonusUI;
    int optionValue;
    public void SetOptionData(int indexValue,UpgradeOptionSO upgradeOption){
        ItemInfoSO upgradeInfo = upgradeOption.upgradeInfo as ItemInfoSO;
        icon.sprite = upgradeInfo.image;
        infoText.text = upgradeInfo.description;
        optionValue = indexValue;
        confirmButton.onClick.AddListener(SelectedOption);
    }
    void SelectedOption(){
        levelupBonusUI.SelectedOption(optionValue);
    }
}
