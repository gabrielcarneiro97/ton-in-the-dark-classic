using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyGrabManager : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject ownerFirefly;
    PlayerGrab playerGrab;

    private void Start() {
        playerGrab = GameObject.FindWithTag("Player").GetComponent<PlayerGrab>();
    }

    public void Interact()
    {
        StartCoroutine(GrabFirefly());
    }

    IEnumerator GrabFirefly()
    {
        yield return new WaitForSeconds(0.5f);
        playerGrab.heldFireflies.value++;
        playerGrab = GameObject.FindWithTag("Player").GetComponent<PlayerGrab>();
        playerGrab.enteredColliders.Remove(gameObject.GetComponent<Collider>());
        ownerFirefly.SetActive(false);
        playerGrab.UpdateFirefliesInLantern();
    }
}
