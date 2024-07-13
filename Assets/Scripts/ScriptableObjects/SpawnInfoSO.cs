using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawn Info",menuName = "SO/Spawn/SpawnInfo")]
public class SpawnInfoSO : ScriptableObject
{
    public bool DestroyWhenMaxSpawn = false;
    public Enemy enemy;
    public float numberOfSpawn;
    public float perSecond;
    public int spawnNumber = 0;
}
