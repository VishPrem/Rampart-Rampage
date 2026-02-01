using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyDeath : MonoBehaviour
{
    public Transform enemyTransform;
    private Rigidbody[] rigidbodies;
    private bool isDead;
    public Animator animator;
    public NavMeshAgent agent;
    void Start()
    {
        rigidbodies = enemyTransform.GetComponentsInChildren<Rigidbody>();
        for(int i = 0; i < rigidbodies.Length; i++) {
            rigidbodies[i].isKinematic = true;
        }
    }

    void Update()
    {
        if(isDead == true)
        {
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                rigidbodies[i].isKinematic = false;
            }
        }
    }

    public void ragdoll()
    {
        animator.enabled = false;
        agent.enabled = false;
        isDead = true;
    }
}
