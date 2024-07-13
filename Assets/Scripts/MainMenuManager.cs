using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    [SerializeField] LoadingScreenManager loadingScene;
    [SerializeField] GameObject bgMusic;
    public static MainMenuManager Instance;
    void Awake() {
        Instance = this;
        settingPanel.gameObject.SetActive(false);
        GameObject ddolBgMusic = DDOLManager.FindDDOLObject(bgMusic.name);
        if (ddolBgMusic == null){
            DDOLManager.AddDDOLObject(bgMusic);
        }else{
            bgMusic.SetActive(false);
            ddolBgMusic.GetComponent<BackgroundMusicManager>().MainMenuMode();
        }
        
    }
    public void StartGameScene(){
        loadingScene.LoadScene((int) SceneIndex.GAME);
    }
    public void OpenSetting(){
        settingPanel.SetActive(true);
    }
}
