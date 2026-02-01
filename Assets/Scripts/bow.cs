using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : weapon
{
    void Update()
    {
        
    }

    public override void fire()
    {
        projectile spawnedProjectile = Instantiate(projectile);
        spawnedProjectile.transform.position = firePoint.position;
        spawnedProjectile.transform.up = firePoint.up;
        spawnedProjectile.init(firePoint.up, currentChargeDuration, stats.maxChargeDuration, pstats);
        currentChargeDuration = 0;
    }
}
