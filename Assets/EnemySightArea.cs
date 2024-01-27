using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightArea : MonoBehaviour
{
    Enemy enemy;

    private void Start() {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            enemy.playerInSight = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            enemy.playerInSight = false;
        }
    }
}
