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
    bool stoppedByFirefly = false;
    float timeToStopChase = 5f;
    float currentTimer = 0f;
    Light light;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[currentWaypoint].position);
        light = GetComponentInChildren<Light>();
    }

    private void FixedUpdate() {
        stoppedByFirefly = false;
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Firefly")
        {
            stoppedByFirefly = true;
        }
    }

    private void Update() {
        if(stoppedByFirefly)
        {
            light.color = Color.green;
            agent.speed = 0f;
            currentTimer = timeToStopChase;
            return;
        }
        else if(playerInSight)
        {
            light.color = Color.red;
            agent.speed = chaseSpeed;
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
            currentTimer = 0f;
        }
        else if(currentTimer < timeToStopChase)
        {
            light.color = Color.red;
            agent.speed = chaseSpeed;
            currentTimer += Time.deltaTime;
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
        else
        {
            light.color = Color.white;
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
