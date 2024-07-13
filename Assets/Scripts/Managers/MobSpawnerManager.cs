using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnerManager : MonoBehaviour
{
    
    [SerializeField] MobSpawner mobSpawnerPrefab;
    [SerializeField] SpawnPoolSO spawnPool;
    List<MobSpawner> currentMobSpawners = new();
    void Awake() {
        if (spawnPool) SetSpawnPool(spawnPool);
    }
    public void SetSpawnPool(SpawnPoolSO spawnPoolSO){
        spawnPool = spawnPoolSO;
        DestroyMobspawnerIns();
        foreach ( SpawnInfoSO spawnInfo in spawnPool.spawnInfos ){
            MobSpawner mobSpawner = Instantiate(mobSpawnerPrefab,transform);
            currentMobSpawners.Add(mobSpawner);
            mobSpawner.SetSpawnInfo(spawnInfo);
            mobSpawner.StartSpawn();
        }
    }
    void DestroyMobspawnerIns(){
        foreach(MobSpawner mobSpawner in currentMobSpawners){
            Destroy(mobSpawner.gameObject);
        }
        currentMobSpawners.Clear();
    }
    public void SpawnOne(SpawnPoolSO spawnPoolSO){
        spawnPool = spawnPoolSO;
        foreach ( SpawnInfoSO spawnInfo in spawnPool.spawnInfos ){
            MobSpawner mobSpawner = Instantiate(mobSpawnerPrefab,transform);
            mobSpawner.SetSpawnInfo(spawnInfo);
            mobSpawner.DestroyAtMaxSpawn = true;
            mobSpawner.StartSpawn();
        }
    }
    
}
