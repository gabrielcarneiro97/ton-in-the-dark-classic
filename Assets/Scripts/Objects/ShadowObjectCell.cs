using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowObjectCell : MonoBehaviour
{
    public bool isWall;

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawMesh(GetComponent<MeshFilter>().sharedMesh, transform.position, transform.rotation, transform.localScale);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "FireflyLight")
        {
            GetComponent<MeshRenderer>().enabled = true;
            if(isWall)
                GetComponent<MeshCollider>().isTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "FireflyLight")
        {
            GetComponent<MeshRenderer>().enabled = false;
            if(isWall)
                GetComponent<MeshCollider>().isTrigger = true;
        }
    }
}
