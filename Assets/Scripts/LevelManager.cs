using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public event EventHandler<OnPlayerLevelUpArgs> OnPlayerExpChange;
    public event EventHandler<OnPlayerLevelUpArgs> OnPlayerLevelUp;
    public class OnPlayerLevelUpArgs:EventArgs{
        public int level;
        public int currentExp;
        public int needExp;
    }
    [SerializeField] float pickupRadius = 2f;
    int level = 1;
    int currentExp = 0;
    int needExp = 8;
    CircleCollider2D sphereCollider;
    void Awake() {
        sphereCollider = GetComponent<CircleCollider2D>();
        sphereCollider.radius = pickupRadius;
    }
    void OnValidate() {
        GetComponent<CircleCollider2D>().radius = pickupRadius;
    }
    void LevelUp(){
        level++;
        currentExp -= needExp;
        needExp *= 2;
        OnPlayerLevelUp?.Invoke(this,new OnPlayerLevelUpArgs { level = level,currentExp = currentExp,needExp = needExp });
        StartLevelUpRewardEvent();
    }
    public void TakeExp(int value){
        currentExp+=value;
        OnPlayerExpChange?.Invoke(this,new OnPlayerLevelUpArgs { level = level,currentExp = currentExp,needExp = needExp });
        if (currentExp >= needExp){
            LevelUp();
        }
    }
    void StartLevelUpRewardEvent(){
        GameManager.Instance.PauseGame();
    }
}
