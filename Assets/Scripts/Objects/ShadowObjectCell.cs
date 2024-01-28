using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowObjectCell : MonoBehaviour
{
    public GameObject pathBlocker;
    public bool isPathBlocker;
    public bool isWall;
    int triggerAmount;
    private void Start() {
        if(isPathBlocker)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshCollider>().isTrigger = false;
        }
        else 
        {
            GetComponent<MeshCollider>().isTrigger = true;
            GetComponent<MeshRenderer>().enabled = false;
            if(!isWall)
            {
                pathBlocker = Instantiate(gameObject, transform.position + Vector3.up * 2, transform.rotation);
                pathBlocker.GetComponent<ShadowObjectCell>().isPathBlocker = true;

            }

        }        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawMesh(GetComponent<MeshFilter>().sharedMesh, transform.position, transform.rotation, transform.localScale);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "FireflyLight")
        {
            triggerAmount++;
            if(isPathBlocker)
            {
                GetComponent<MeshCollider>().isTrigger = true;
            }
            else 
            {
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<MeshCollider>().isTrigger = false;
                if(pathBlocker != null)
                    pathBlocker.GetComponent<MeshCollider>().isTrigger = true;
            }

        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "FireflyLight")
        {
            triggerAmount--;
            if(isPathBlocker && triggerAmount == 0)
            {
                GetComponent<MeshCollider>().isTrigger = false;
            }
            else if(triggerAmount == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<MeshCollider>().isTrigger = true;
            }
        }
    }
}
