using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnumSfxController : MonoBehaviour
{
    [SerializeField] SfxPlayer shotSfx;
    [SerializeField] Weapon magnum;
    [SerializeField] bool loop;
    void Start(){
        magnum.OnWeaponShot += OnWeaponShot;
    }
    void OnWeaponShot(object sender,EventArgs args){
        if (loop){
            shotSfx.Loop();
        }else{
            shotSfx.Play();
        }
    }
}
