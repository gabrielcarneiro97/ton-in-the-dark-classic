using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    bool isInLight;
    Rigidbody rb;
    public float speed;
    Vector3 playerPos;
    Vector3 startPos;
    float timeOutsideLight;
    public float timeOutsideLightToGoBack;

    private void Start() 
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(!isInLight)
        {
            timeOutsideLight += Time.deltaTime;
        }
        else
        {
            timeOutsideLight = 0;
        }
    }

    private void FixedUpdate() 
    {
        if(isInLight)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            rb.AddForce((new Vector3(playerPos.x, playerPos.y + 2, playerPos.z) - transform.position).normalized * speed, ForceMode.Acceleration); 
        }
        else if (timeOutsideLight > timeOutsideLightToGoBack)
        {
            if((transform.position - startPos).magnitude > 0.1f)
                rb.AddForce((startPos - transform.position).normalized * speed, ForceMode.Acceleration); 
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("FireflyLight"))
        {
            isInLight = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("FireflyLight"))
        {
            isInLight = false;
        }
    }
}
