using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyGrabManager : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject ownerFirefly;
    PlayerGrab playerGrab;

    public void Interact()
    {
        playerGrab = GameObject.FindWithTag("Player").GetComponent<PlayerGrab>();
        playerGrab.heldFireflies.value++;
        playerGrab.enteredColliders.Remove(gameObject.GetComponent<Collider>());
        Destroy(ownerFirefly);
    }
}
