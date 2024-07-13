using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Spawn Pool",menuName = "SO/Spawn/SpawnPool")]
public class SpawnPoolSO : ScriptableObject
{
    public float multiplierStat = 1;
    public List<SpawnInfoSO> spawnInfos;
}
