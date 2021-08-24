using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 10;

    public float shootRadius = 5f;

    public Transform target;

    NavMeshAgent agent;

    public Rigidbody Projectile;
    public Transform Barrel;

    public bool hasShot;
    public float shotTimer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if (distance < agent.stoppingDistance)
            {
                agent.SetDestination(transform.position);
            }
        }
        if (distance >= lookRadius)
        {
            agent.SetDestination(transform.position);
        }
        if (distance <= shootRadius)
        {
            if (distance < agent.stoppingDistance)
            {
                agent.SetDestination(transform.position);
            }
            transform.LookAt(target);
            Shoot();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootRadius);
    }

    private void Shoot()
    {
        if(!hasShot)
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(Projectile, Barrel.position, Barrel.rotation) as Rigidbody;
            projectileInstance.AddForce(Barrel.forward * 10000f);
            hasShot = true;
        }
        if(hasShot)
        {
            shotTimer += Time.deltaTime;
            if(shotTimer >= 0.5)
            {
                shotTimer = 0;
                hasShot = false;
            }
        }


    }
}
