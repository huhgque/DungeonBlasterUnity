using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance{private set;get;}
    const string MASTER_VOLUME = "MasterVolume";
    const string MUSIC_VOLUME = "MusicVolume";
    const string SFX_VOLUME = "SfxVolume";
    [SerializeField] AudioMixerGroup master;
    [SerializeField] AudioMixerGroup music;
    [SerializeField] AudioMixerGroup sfx;
    void Awake() {
        if (!Instance)
            Instance = this;
    }
    void Start() {
        SetSoundSetting();
    }
    public void RefreshSetting(){
        SetSoundSetting();
    }
    void SetSoundSetting(){
        GameSettingData saveData = GameSettingManager.Instance.GameSettingData;
        master.audioMixer.SetFloat(MASTER_VOLUME,
            (saveData.masterVolume <= -20)?-80:saveData.masterVolume
        ); 
        master.audioMixer.SetFloat(MUSIC_VOLUME,
            (saveData.musicVolume <= -20)?-80:saveData.musicVolume
        );
        master.audioMixer.SetFloat(SFX_VOLUME,
            (saveData.sfxVolume <= -20)?-80:saveData.sfxVolume
        );
    }
}
