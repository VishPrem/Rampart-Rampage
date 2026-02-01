using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy : MonoBehaviour, Idamageable
{
    public enemyStats enemyStats;
    [System.NonSerialized]public Transform castle;
    public NavMeshAgent agent;
    public soEventWithVec3Args enemyDied;
    public enemyDeath enemyDeath;
    private float health;
    public soEvent onRoundEnd;
    private bool isAlive;
    public soEvent enemyDiedWithoutReward;
    public Slider healthBar;

    void Start()
    {
        isAlive = true;
        health = enemyStats.max_health;
        onRoundEnd.events.Add(() => { dieWithoutReward(); });
        agent.enabled = true;
    }

    void Update()
    {
        healthBar.value = health / enemyStats.max_health;
        if (agent.enabled)
        {
            agent.SetDestination(castle.position);
            agent.speed = enemyStats.speed;
            if ((agent.transform.position - castle.transform.position).magnitude <= enemyStats.attack_distance)
            {
                castle.GetComponent<castle>().takeDamage(enemyStats.damage);
                dieWithoutReward();
            }
        }
    }

    public void takeDamage(float damage)
    {
        if (isAlive != true) return;
        health -= damage;
        if(health <= 0) {
            enemyDied.invoke(gameObject.transform.position);
            Destroy(gameObject, 10);
            enemyDeath.ragdoll();
            isAlive = false;
        }
    }

    public void dieWithoutReward()
    {
        if (isAlive != true) return;
        Destroy(gameObject, 10);
        enemyDeath.ragdoll();
        isAlive = false;
        enemyDiedWithoutReward.invoke();
    }
}