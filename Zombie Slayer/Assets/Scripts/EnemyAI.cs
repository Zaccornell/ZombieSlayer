﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    private NavMeshAgent myAgent;
    public Transform target;

    public float health = 100;
    public float enemyDamage = 30;
    // Use this for initialization
    void Start() {
        myAgent = this.GetComponent<NavMeshAgent>();

        if (myAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to" + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if (target != null)
        {
            Vector3 targetVector = target.transform.position;
            myAgent.SetDestination(targetVector);
        }
    }


    // Update is called once per frame
    void Update()
    {
        myAgent.SetDestination(target.position);
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().DamageTaken(enemyDamage);
        }
    }

}