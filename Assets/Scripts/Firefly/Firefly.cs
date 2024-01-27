using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    bool isInLight;
    Rigidbody rb;
    public float speed;
    Vector3 lightPos;
    Vector3 startPos;
    float timeOutsideLight;
    public float timeOutsideLightToGoBack;
    Collider currentLightCollider;

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
            lightPos = currentLightCollider.transform.position;
            rb.AddForce((new Vector3(lightPos.x, lightPos.y + 2, lightPos.z) - transform.position).normalized * speed, ForceMode.Acceleration); 
        }
        else if (timeOutsideLight > timeOutsideLightToGoBack)
        {
            if((transform.position - startPos).magnitude > 0.1f)
                rb.AddForce((startPos - transform.position).normalized * speed, ForceMode.Acceleration); 
        }
        if((lightPos - rb.transform.position).magnitude < 0.1f && currentLightCollider.GetComponentInParent<FireflySwitch>())
        {
            currentLightCollider.GetComponentInParent<FireflySwitch>().Interact();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("FireflyLight"))
        {
            currentLightCollider = other;
            isInLight = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("FireflyLight"))
        {
            currentLightCollider = null;
            isInLight = false;
        }
    }
}
