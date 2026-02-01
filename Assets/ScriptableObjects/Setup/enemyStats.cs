using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemyStats", menuName = "enemyStats")]
public class enemyStats : ScriptableObject
{
    public float speed;
    public int damage;
    public float max_health;
    public float attack_distance;
}
