using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public List<Transform> waypoints = new List<Transform>();
    int currentWaypoint = 0;
    public bool playerInSight = false;
    public float regularSpeed = 3.5f;
    public float chaseSpeed = 5f;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[currentWaypoint].position);
    }

    private void Update() {
        if(playerInSight)
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
        else
        {
            agent.speed = regularSpeed;
            if(agent.remainingDistance < 0.1f)
            {
                currentWaypoint++;
                if(currentWaypoint >= waypoints.Count)
                    {
                        currentWaypoint = 0;
                    }
                agent.SetDestination(waypoints[currentWaypoint].position);
            }
        }
    } 

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, waypoints[currentWaypoint].position);
        for(int i = 0; i < waypoints.Count; i++)
        {
            Gizmos.DrawSphere(waypoints[i].position, 0.5f);
            if(i < waypoints.Count - 1)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
        }
    }
}
