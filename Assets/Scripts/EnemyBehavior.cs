using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;

    private int _locationIndex = 0;
    private NavMeshAgent _agent;

    private int _lives = 3;

    public int EnemyLives
    {
        get => _lives;
        private set
        {
            _lives = value;
            
            // die
            if (_lives > 0) return;
            Destroy(this.gameObject);
            Debug.Log("Enemy down.");
        }
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;

        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    private void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    private void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
        {
            return;
        }

        _agent.destination = locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % locations.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") return;
        
        _agent.destination = player.position;
        Debug.Log("Player detected - attack!");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
           MoveToNextPatrolLocation();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Critical hit!");
        }
    }
}
