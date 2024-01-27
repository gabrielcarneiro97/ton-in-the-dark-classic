using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField] GameObject fireflyPrefab;
    public int heldFireflies = 0;
    public List<Collider> enteredColliders = new List<Collider>();

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Interact();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && heldFireflies > 0 || Input.GetKeyDown(KeyCode.Joystick1Button3) && heldFireflies > 0)
        {
            ReleaseFirefly();
        }
    }

    void Interact()
    {
        if(enteredColliders.Count > 0)
        {
            Collider closestCollider = enteredColliders[0];
            for(int i = 0; i < enteredColliders.Count; i++)
            {
                if(enteredColliders[i].GetComponentInParent<Firefly>())
                {
                    closestCollider = enteredColliders[i];
                    closestCollider.GetComponent<IInteractable>().Interact();
                    return;
                }
                if(Vector3.Distance(transform.position, enteredColliders[i].transform.position) < Vector3.Distance(transform.position, closestCollider.transform.position))
                {
                    closestCollider = enteredColliders[i];
                }  
            }
            closestCollider.GetComponent<IInteractable>().Interact();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponent<IInteractable>() != null)
        {
            enteredColliders.Add(other);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.GetComponent<IInteractable>() != null)
        {
            enteredColliders.Remove(other);
        }
    }

    public void ReleaseFirefly()
    {
        heldFireflies--;
        Instantiate(fireflyPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 3), Quaternion.identity);
    }
}
