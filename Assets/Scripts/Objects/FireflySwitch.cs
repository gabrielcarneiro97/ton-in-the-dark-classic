using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflySwitch : MonoBehaviour
{
    public Observable<bool> hasFirefly = new(false);
    public GameObject tip;
    public PlayerGrab playerGrab;
    [SerializeField] public GameObject switchable;
    public Collider lightCollider;

    public Material withFirefly, withoutFirefly;


    void Start()
    {
        hasFirefly.Subscribe((hasFirefly) =>
        {
            if (hasFirefly) tip.GetComponent<Renderer>().material = withFirefly;
            else tip.GetComponent<Renderer>().material = withoutFirefly;

            lightCollider.enabled = hasFirefly;
        });
    }


    public void Interact()
    {
        if (hasFirefly.value)
        {
            hasFirefly.value = false;
            if (switchable != null) switchable.GetComponent<ISwitchable>().Switch(false);
            playerGrab.heldFireflies++;
        }
        else if (playerGrab.heldFireflies > 0)
        {
            hasFirefly.value = true;
            if (switchable != null) switchable.GetComponent<ISwitchable>().Switch(true);
            playerGrab.heldFireflies--;
            Debug.Log("Firefly added");
        }
    }
}
