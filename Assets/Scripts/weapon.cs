using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class weapon : MonoBehaviour
{
    public weaponStats stats;
    public projectile projectile;
    public Transform firePoint;
    protected float currentChargeDuration;
    public soEvent startFireEvent;
    public soEvent stopFireEvent;
    public projectileStats pstats;
    public soEventWithStatsArgs action;
    public GameObject parent;
    public soEvent destroyWeapon;

    void Start()
    {
        Debug.Log("Test");
        action.events.Add((stats w_stats) => { this.stats = (weaponStats)w_stats; Debug.Log("Weapon Upgraded"); });
        destroyWeapon.events.Add(() => { Destroy(parent); }) ;
        startFireEvent.events.Add(() => { if (this == null) return; StartCoroutine(fireTimer()); });
        stopFireEvent.events.Add(() => { if(this == null) return; stopFire(); });
    }

    public void stopFire()
    {
        StopCoroutine(fireTimer());
        currentChargeDuration -= 1;
        fire();
    }

    IEnumerator fireTimer()
    {
        currentChargeDuration = 0;
        while (currentChargeDuration < stats.maxChargeDuration)
        {
            currentChargeDuration++;
            yield return new WaitForSeconds(1);
        } 
        yield return new WaitForSeconds(stats.maxHoldTime);
        fire();
    }

    public abstract void fire();

    private void OnDestroy()
    {
        Debug.Log("weapon destroyed");
    }
}
