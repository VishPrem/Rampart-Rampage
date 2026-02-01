using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "projectileStats", menuName = "projectileStats")]
public class projectileStats : stats
{
    public float maxSpeed;
    public float minChargeDuration;
    public float maxDamage;
}
