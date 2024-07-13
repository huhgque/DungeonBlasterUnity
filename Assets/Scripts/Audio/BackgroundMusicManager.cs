using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    AudioSource audioSource;
    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }
    public void MainMenuMode(){
        audioSource.pitch = 1;
        audioSource.Play();
    }
    public void GameMode(){
        audioSource.pitch = 0.2f;
    }
}
