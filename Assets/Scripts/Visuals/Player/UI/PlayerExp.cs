using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] Image expBar;
    [SerializeField] TextMeshProUGUI levelText;
    /// <summary>
    /// time to fill
    /// </summary>
    [SerializeField] float expFillSpeed = 2;
    SmoothBarUtil smoothBarUtil = new();
    void Start() {
        levelManager = Player.Instance.GetLevelManager();
        levelManager.OnPlayerExpChange += OnPlayerExpChange;
        levelManager.OnPlayerLevelUp += OnPlayerLevelUp;
        expBar.fillAmount = 0;
        levelText.text = "1";
        smoothBarUtil.FillSpeed = expFillSpeed;
    }
    void Update() {
        smoothBarUtil.Update();
        expBar.fillAmount = smoothBarUtil.CurrentFill;
    }
    void OnPlayerExpChange(object sender,LevelManager.OnPlayerLevelUpArgs args){
        smoothBarUtil.TargetFill = (float) args.currentExp/args.needExp;
    }
    void OnPlayerLevelUp(object sender,LevelManager.OnPlayerLevelUpArgs args){
        levelText.text = args.level.ToString();
    }
}
