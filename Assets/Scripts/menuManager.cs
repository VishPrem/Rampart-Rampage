using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class menuManager : MonoBehaviour
{
    public TextMeshProUGUI currentDay;
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI currentHealth;
    public TextMeshProUGUI enemiesDefeated;
    public rewardSystem rewardSystem;
    public gameManager gameManager;
    public castle castle;

    void Start()
    {
        
    }

    void Update()
    {
        currentDay.text = "Day: " + gameManager.dayCounter.ToString();
        coinCount.text = rewardSystem.coinCount.ToString();
        currentHealth.text = castle.current_health.ToString() + " / " + castle.castleStats.health.ToString();
        enemiesDefeated.text = rewardSystem.enemiesKilled.ToString();
    }
}
