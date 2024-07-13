using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    [SerializeField] LoadingScreenManager loadingScreen;
    [SerializeField] GameObject mainPauseMenu;
    [SerializeField] GameObject settingMenu;
    [SerializeField] GameObject[] pausemenuComponent;
    GameObject currentMenu;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameStateChange += OnGameStateChange; 
        DeactiveComponent();
    }
    void OnGameStateChange(object sender,GameStateChangeArgs args){
        if (args.gameState == GameState.PAUSE_MENU){
            mainPauseMenu.SetActive(true);
            currentMenu = mainPauseMenu;
        }else if (args.gameState == GameState.PLAY) {
            DeactiveComponent();
        }
    }
    void DeactiveComponent(){
        foreach (GameObject component in pausemenuComponent){
            component.SetActive(false);
        }
    }
    public void ResumeGame(){
        GameManager.Instance.ContinueGame();
    }
    public void SettingMenu(){
        currentMenu.SetActive(false);
        settingMenu.SetActive(true);
        currentMenu = settingMenu;
    }
    public void Quit(){
        loadingScreen.LoadScene((int)SceneIndex.TITLE);
    }
    
}
