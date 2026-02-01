using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public AudioClip bowRelease;
    public AudioClip bowPulledBack;
    public soEvent startFire;
    public soEvent stopFire;
    public AudioSource source;
    public soEventWithVec3Args enemyDied;
    public AudioClip enemyNoise;
    public AudioClip coinsDropped;
    public soEvent projectileFired;
    public AudioClip projectileNoise;
    public soEvent stoneHit;
    public AudioClip stoneNoise;
    public soEvent enemyDiedWithoutReward;
    void Start()
    {
        startFire.events.Add(() => { source.PlayOneShot(bowPulledBack); });
        stopFire.events.Add(() => { source.PlayOneShot(bowRelease); });
        enemyDied.events.Add((Vector3 _) => { source.PlayOneShot(enemyNoise);  source.PlayOneShot(coinsDropped);  });
        projectileFired.events.Add(() => { source.PlayOneShot(projectileNoise); });
        stoneHit.events.Add(() => { source.PlayOneShot(stoneNoise); });
        enemyDiedWithoutReward.events.Add(() => { source.PlayOneShot(stoneNoise); });
    }
}