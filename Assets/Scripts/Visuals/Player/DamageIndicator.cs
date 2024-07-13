using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    public static DamageIndicator Instance;
    [SerializeField] TextIndicatorContainer containerTemplate;
    void Awake() {
        Instance = this;
        containerTemplate.gameObject.SetActive(false);
    }
    public static void AddPlayerDamageIndicator(Vector3 position,int value){
        Instance.AddPlayerDamage(position,value);
    }
    void AddPlayerDamage(Vector3 position,int value){
        TextIndicatorContainer dmg = Instantiate(containerTemplate);
        dmg.transform.position = position;
        dmg.SetMessage(value.ToString());
        dmg.gameObject.SetActive(true);
    }
}
