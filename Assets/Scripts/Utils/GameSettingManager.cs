using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingManager : MonoBehaviour
{
    public static GameSettingManager Instance {private set;get;}
    public GameSettingData GameSettingData {private set;get;} = new();
    public void Awake(){
        if ( DDOLManager.FindDDOLObject("GameSetting") == null){
            Instance = this;
            Load();
            DDOLManager.AddDDOLObject(gameObject);
        }else{
            gameObject.SetActive(false);
        }
    }
    public void Load(){
        GameSettingData.masterVolume    = PlayerPrefs.GetFloat("MasterVolume");
        GameSettingData.musicVolume     = PlayerPrefs.GetFloat("MusicVolume");
        GameSettingData.sfxVolume       = PlayerPrefs.GetFloat("SfxVolume");
    }
    public void Save(){
        PlayerPrefs.SetFloat("MasterVolume",GameSettingData.masterVolume);
        PlayerPrefs.SetFloat("MusicVolume",GameSettingData.musicVolume);
        PlayerPrefs.SetFloat("SfxVolume",GameSettingData.sfxVolume);
        PlayerPrefs.Save();
    }
    
}
