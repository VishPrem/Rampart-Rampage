using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public Rigidbody rigidbody;
    private bool hasHit = true;
    private float currentCharge;
    public soEvent projectileFired;
    public soEvent stoneHit;
    public projectileStats pstats;
    public soEventWithStatsArgs action;

    public void Start()
    {
        action.events.Add((stats p_stats) => { this.pstats = (projectileStats)p_stats; Debug.Log("Projectile Upgraded"); });
    }

    public void init(Vector3 direction, float currentChargeDuration, float maxChargeDuration, projectileStats stats)
    {
        pstats = stats;
        projectileFired.invoke();
        float speed = (currentChargeDuration / maxChargeDuration) * pstats.maxSpeed;
        if(currentChargeDuration < pstats.minChargeDuration)
        {
            Destroy(gameObject);
            return;
        }
        rigidbody.AddForce(direction * speed); 
        currentCharge = currentChargeDuration / maxChargeDuration;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(hasHit == false)
        {
            return;
        }
        Idamageable damageable = collision.transform.GetComponent<Idamageable>();
        if(damageable != null)
        {
            damageable.takeDamage(currentCharge * pstats.maxDamage);
        }
        else
        {
            stoneHit.invoke();
        }
        hasHit = false;
    }
}
