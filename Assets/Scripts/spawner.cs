using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public List<waveStats> waveStats;
    public Transform castle;
    public List<GameObject> spawnPoints;


    public int spawnWave(int current_wave)
    {
        waveStats currentWaveStats = waveStats[current_wave % waveStats.Count];
        for(int i = 0; i < currentWaveStats.num_enemies; i++)
        {
            GameObject enemy = Instantiate(currentWaveStats.enemies[0]);
            enemy.GetComponent<enemy>().castle = castle;
            enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position;
            enemy.SetActive(true);
        }
        return currentWaveStats.num_enemies;
    }
}
