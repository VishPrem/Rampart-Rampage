using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class castle : MonoBehaviour
{
    public float current_health;
    public castleStats castleStats;
    public soEvent onCastleDeath;
    public Slider castleSlider;
    public CinemachineImpulseSource source;
    public soEventWithStatsArgs action;

    void Start()
    {
        action.events.Add((stats castleStats) => { this.castleStats = (castleStats) castleStats; current_health = this.castleStats.health;  Debug.Log("Castle Upgraded"); });
        current_health = castleStats.health;
        if(PlayerPrefs.GetFloat("Current Health") > 0)
        {
            current_health = PlayerPrefs.GetFloat("Current Health");
        }
    }

    private void Update()
    {
        castleSlider.value = current_health / castleStats.health;
    }

    public void takeDamage(float damage)
    {
        current_health -= damage;
        source.GenerateImpulseWithForce(1);
        if(current_health <= 0) 
        {
            onCastleDeath.invoke();
        }
        Debug.Log(current_health);
    }

    public int coinMultiplier(int current_coins)
    {
        return current_coins * castleStats.coinMultiplier;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("Health", current_health);
    }
}
