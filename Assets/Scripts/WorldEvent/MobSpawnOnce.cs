using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnOnce : WorldEvent
{
    [SerializeField] SpawnPoolSO spawnPoolSO;
    protected override void EventBehaviorOnce(){
        GameManager.Instance.GetMobSpawnerManager().SpawnOne(spawnPoolSO);
    }
}
