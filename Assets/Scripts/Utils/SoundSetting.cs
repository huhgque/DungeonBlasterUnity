using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    public void Start(){
        GameSettingData data = GameSettingManager.Instance.GameSettingData;
        if (data.masterVolume == -80){
            masterSlider.value = 0;
        }else{
            masterSlider.value = (((data.masterVolume + 20)*100)/20)/100;
        }
        if (data.musicVolume == -80){
            musicSlider.value = 0;
        }else{
            musicSlider.value = (((data.musicVolume + 20)*100)/20)/100;
        }
        if (data.sfxVolume == -80){
            sfxSlider.value = 0;
        }else{
            sfxSlider.value = (((data.sfxVolume + 20)*100)/20)/100;
        }
    }
    public void SaveSetting(){
        GameSettingManager.Instance.GameSettingData.masterVolume = (masterSlider.value * 100 * 20 / 100) - 20;
        GameSettingManager.Instance.GameSettingData.musicVolume = (musicSlider.value * 100 * 20 / 100) - 20;
        GameSettingManager.Instance.GameSettingData.sfxVolume = (sfxSlider.value * 100 * 20 / 100) - 20;
        GameSettingManager.Instance.Save();
        SoundManager.Instance.RefreshSetting();
        gameObject.SetActive(false);
    }
}
