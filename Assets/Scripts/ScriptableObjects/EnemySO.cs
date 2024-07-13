using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy stat", menuName = "SO/Enemy/Stat")]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public int hp;
    public int damage;
    [Range(0,1)]
    public float knockbackResistant;
    public float speed;
    public int exp;
    public Enemy enemyObject;
}
