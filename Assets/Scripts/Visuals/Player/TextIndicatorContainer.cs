using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextIndicatorContainer : MonoBehaviour
{
    [SerializeField] TextMeshPro playerDmgTemplate;
    void Awake() {
        IndicatorAnimationEvent indicatorAnimationEvent = playerDmgTemplate.GetComponent<IndicatorAnimationEvent>();
        indicatorAnimationEvent.OnAnimationEnd += OnAnimationEnd;
    }
    public void SetMessage(string message){
        playerDmgTemplate.text = message;
    }
    void OnAnimationEnd(object sender,EventArgs args){
        Destroy(gameObject);
    }

}
