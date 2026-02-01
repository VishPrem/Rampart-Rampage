using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "upgradeStats", menuName = "upgradeStats")]
public class upgradeStats : ScriptableObject
{
    public int cost;
    public Sprite icon;
    public UnityEvent action;
}
