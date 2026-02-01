using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "weaponStats", menuName = "weaponStats")]
public class weaponStats : stats
{
    public float chargeSpeed;
    public float maxChargeDuration;
    public float maxHoldTime;
}