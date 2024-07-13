using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCanonSfxController : MonoBehaviour
{
    [SerializeField] SfxPlayer shotSfx;
    [SerializeField] SfxPlayer chargeSfx;
    [SerializeField] LazerCanon lazer;
    [SerializeField] bool loop;
    float lastChargeAmout = 0;
    bool isLooping = false;
    void Start(){
        lazer.OnWeaponShot += OnWeaponShot;
        lazer.OnChargeFill += OnChargeFill;
    }

    private void OnChargeFill(object sender, LazerCanon.OnChargeFillArgs e)
    {
        if (e.currentCharge > 0){
            lastChargeAmout = e.currentCharge;
            if (!isLooping){
                chargeSfx.Loop();
                isLooping = true;
            }
        }else if (e.currentCharge == 0){
            if (isLooping){
                chargeSfx.Loop();
                isLooping = false;
            }
        }
    }

    void OnWeaponShot(object sender,EventArgs args){
        if (isLooping) {
            chargeSfx.Loop();
            isLooping = false;
        }
        shotSfx.Play();
    }
}
