using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    enum Direction
    {
        TOP,
        LEFT,
        RIGHT,
        BOTTOM
    }
    [SerializeField] bool isSpawning = false;
    [SerializeField] SpawnInfoSO spawnInfo;
    public bool DestroyAtMaxSpawn {get;set;} = false;
    int spawnLimit = 0;
    int numberOfMob = 0;
    float spawnColdown;
    float spawnColdownCounter = 0;
    GameManager.ScreenPosition screenPosition;
    void Awake()
    {
        if (spawnInfo) SetSpawnInfo(spawnInfo);
        
    }
    void Start() {
        screenPosition = GameManager.Instance.ScreenPos; 
    }
    public void SetSpawnInfo(SpawnInfoSO spawnInfoSO)
    {
        spawnInfo = spawnInfoSO;
        spawnColdown = 1f / spawnInfo.numberOfSpawn / spawnInfo.perSecond;
        spawnLimit = spawnInfo.spawnNumber;
    }
    public void StartSpawn()
    {
        isSpawning = true;
    }
    public void StopSpawn()
    {
        isSpawning = false;
    }

    void Update()
    {
        if (!isSpawning) return;
        spawnColdownCounter += Time.deltaTime;
        if (spawnColdownCounter < spawnColdown) return;
        if (numberOfMob >= spawnLimit && spawnLimit > 0) return;
        numberOfMob++;
        spawnColdownCounter = 0;
        Vector3 spawnLocation = GetSpawnLocation();
        Enemy e = Instantiate(spawnInfo.enemy,GameManager.Instance.GetMobSpawnerManager().transform);
        e.transform.position = spawnLocation;
        e.OnEnemyDie += OnEnemyDie;
        if (numberOfMob >= spawnLimit && spawnInfo.DestroyWhenMaxSpawn){
            Destroy(gameObject);
        }
    }

    Vector3 GetSpawnLocation()
    {
        Direction randDirection = (Direction)UnityEngine.Random.Range(1, 5);
        switch (randDirection)
        {
            case Direction.TOP:
                return RandomSpawnLocation(screenPosition.bottomLeft.x, screenPosition.topRight.x, screenPosition.topRight.y, screenPosition.topRight.y);
            case Direction.BOTTOM:
                return RandomSpawnLocation(screenPosition.bottomLeft.x, screenPosition.topRight.x, screenPosition.bottomLeft.y, screenPosition.bottomLeft.y);
            case Direction.LEFT:
                return RandomSpawnLocation(screenPosition.bottomLeft.x, screenPosition.bottomLeft.x, screenPosition.bottomLeft.y, screenPosition.topRight.y);
            case Direction.RIGHT:
                return RandomSpawnLocation(screenPosition.topRight.x, screenPosition.topRight.x, screenPosition.bottomLeft.y, screenPosition.topRight.y);
            default:
                return screenPosition.bottomLeft;
        }
    }
    Vector3 RandomSpawnLocation(float minX, float maxX, float minY, float maxY)
    {
        float randX = UnityEngine.Random.Range(minX, maxX);
        float randY = UnityEngine.Random.Range(minY, maxY);
        return new Vector3(randX, randY);
    }
    void OnEnemyDie(object sender, EventArgs args)
    {
        numberOfMob--;
    }
    
}
