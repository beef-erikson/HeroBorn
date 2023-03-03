/********************************
 * EnemyBehavior.cs
 * Handles enemy AI and lives.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 * Private Methods:
 * private void InitializePatrolRoute() - Adds all children of patrolRoute to locations.
 * private void MoveToNextPatrolLocation() - Move to next location in patrolRoute.
 * 
 ********************************/

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

    /// <summary>
    /// Getter/setter for _lives.
    /// </summary>
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

    /// <summary>
    /// Initializes variables and patrols.
    /// </summary>
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;

        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    /// <summary>
    /// Adds all children of patrolRoute to locations list.
    /// </summary>
    private void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    /// <summary>
    /// Moves Enemy to the next location from patrolRoute.
    /// </summary>
    private void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
        {
            return;
        }

        _agent.destination = locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % locations.Count;
    }

    /// <summary>
    /// Attacks player, if present in trigger.
    /// </summary>
    /// <param name="other">Collider the Enemy entered.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") return;
        
        _agent.destination = player.position;
        Debug.Log("Player detected - attack!");
    }

    /// <summary>
    /// Resumes patrol if player is targeted and leaves the trigger range.
    /// </summary>
    /// <param name="other">Collider that is exiting range.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }

    /// <summary>
    /// Moves to next patrol point if current destination reached.
    /// </summary>
    private void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
           MoveToNextPatrolLocation();
        }
    }
    
    /// <summary>
    /// If shot by bullet, subtracts a life.
    /// </summary>
    /// <param name="collision">Object that entered collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Bullet(Clone)") return;
        
        EnemyLives -= 1;
        Debug.Log("Critical hit!");
    }
}
