using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewardSystem : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public soEventWithVec3Args onEnemyDeath;
    public int coinCount;
    public castle castle;
    public int enemiesKilled;

    void Start()
    {
        onEnemyDeath.events.Add(spawnParticle);
        coinCount = PlayerPrefs.GetInt("Coin Count");
        enemiesKilled = PlayerPrefs.GetInt("Enemies Killed");
        coinCount = 100;
    }

    public void spawnParticle(Vector3 position)
    {
        particleSystem.transform.position = position;
        particleSystem.Play();
        coinCount += castle.coinMultiplier(1);
        enemiesKilled++;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("Coin Count", coinCount);
        PlayerPrefs.SetInt("Enemies Killed", enemiesKilled); 
    }
}
