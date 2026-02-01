using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineGun : weapon
{
    private bool isFiring = false;
    public override void fire()
    {
        StartCoroutine(Fire());
    }

    public IEnumerator Fire()
    {
        isFiring = !isFiring;
        Debug.Log(isFiring);
        while (isFiring)
        {
            projectile spawnedProjectile = Instantiate(projectile);
            spawnedProjectile.transform.position = firePoint.position;
            spawnedProjectile.transform.up = firePoint.up;
            spawnedProjectile.init(firePoint.up, 1, 1, pstats);
            yield return new WaitForSeconds(stats.chargeSpeed);
        }
    }
}
