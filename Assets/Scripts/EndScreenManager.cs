using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] AudioSource gameClearSound;
    [SerializeField] AudioSource gameOverSound;
    [SerializeField] TextMeshProUGUI gameoverText;
    [SerializeField] TextMeshProUGUI gameClearText;
    [SerializeField] LoadingScreenManager loadingScreen;
    [SerializeField] TextMeshProUGUI gameTime;
    [SerializeField] TextMeshProUGUI killCount;
    [SerializeField] Image weapon1;
    [SerializeField] Image weapon2;
    [SerializeField] TextMeshProUGUI skillGet;
    void Start()
    {
        HideScreen();
        GameManager.Instance.OnGameStateChange += OnGameEnd;
    }
    private void OnGameEnd(object sender, GameStateChangeArgs e)
    {
        if(e.gameState == GameState.GAME_OVER || e.gameState == GameState.GAME_CLEAR){
            if (e.gameState == GameState.GAME_OVER){
                gameOverSound.Play();
            }else{
                gameClearSound.Play();
            }
            gameClearText.GetComponent<LayoutElement>().ignoreLayout = e.gameState != GameState.GAME_CLEAR;
            gameoverText.GetComponent<LayoutElement>().ignoreLayout = e.gameState != GameState.GAME_OVER ; 
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            gameTime.text = "Time : " + (int) GameManager.Instance.PlayTimeCounter / 60 + ":" + (int) GameManager.Instance.PlayTimeCounter % 60 ;
            PrintKillCount();
            PrintUsedWeapon();
            PrintSkill();
        }
    }
    void PrintKillCount(){
        string killCountMsg = "";
        Dictionary<string,int> killList = KillCounter.Instance.GetKillCounter();
        foreach (var item in killList)
        {
            if (item.Value == 0) continue;
            killCountMsg += item.Key + ":" + item.Value + "\n";
        }
        killCount.text = killCountMsg;
    }
    void PrintUsedWeapon(){
        weapon1.sprite = WeaponManager.Instance.GetLeftWeapon().GetSprite().sprite;
        weapon2.sprite = WeaponManager.Instance.GetRightWeapon().GetSprite().sprite;
    }
    void PrintSkill(){
        WeaponSO stat = WeaponManager.Instance.accumulateStatModifier;
        string statMsg = "Stat : \n";
        statMsg += "Damage : +" + stat.damage + "%" + "\n";
        skillGet.text = statMsg;
    }
    public void Retry(){
        HideScreen();
        loadingScreen.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnToTitle(){
        HideScreen();
        loadingScreen.LoadScene((int) SceneIndex.TITLE);
    }
    void HideScreen(){
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
