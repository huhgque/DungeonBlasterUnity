using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    [SerializeField] EnemySO[] initEnemy;
    public static KillCounter Instance {get;private set;}
    Dictionary<string,int> killCounters = new();
    void Awake(){
        Instance = this;
        foreach(EnemySO enemySO in initEnemy){
            AddEntity(enemySO.enemyName);
        }
    }
    public void AddEntity(string name){
        killCounters[name] = 0;
    }
    public void CountEntity(string name,int value){
        killCounters[name] += value;
    }
    public Dictionary<string,int> GetKillCounter(){
        return killCounters;
    }
}
