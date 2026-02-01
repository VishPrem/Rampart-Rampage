using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "waveStats", menuName = "waveStats")]
public class waveStats : ScriptableObject
{
    public List<GameObject> enemies;
    public int num_enemies;
}
