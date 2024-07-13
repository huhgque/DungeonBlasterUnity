using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    AudioSource audioSource;
    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }
    public void Play(){
        audioSource.Play();
    }
    public void Loop(){
        if (audioSource.isPlaying){
            audioSource.Stop();
        }else{
            audioSource.Play();
        }
    }
}
