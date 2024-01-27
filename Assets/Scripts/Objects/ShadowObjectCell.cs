using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowObjectCell : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "FireflyLight")
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<MeshCollider>().isTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "FireflyLight")
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshCollider>().isTrigger = true;
        }
    }
}
