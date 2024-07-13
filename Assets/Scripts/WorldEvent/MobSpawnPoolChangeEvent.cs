using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnPoolChangeEvent : WorldEvent
{
    [SerializeField] SpawnPoolSO spawnPool;
    protected override void EventBehaviorOnce(){
        GameManager.Instance.GetMobSpawnerManager().SetSpawnPool(spawnPool);
    }
}
