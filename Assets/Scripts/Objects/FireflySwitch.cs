using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflySwitch : MonoBehaviour
{
    public bool hasFirefly;
    public GameObject tip;
    public PlayerGrab playerGrab;
    [SerializeField] public GameObject switchable;

    public Material withFirefly, withoutFirefly;

    public void AddFirefly()
    {
        tip.GetComponent<Renderer>().material = withFirefly;
        Debug.Log("Firefly added METHOD CALLED");
        hasFirefly = true;
    }

    public void RemoveFirefly()
    {
        tip.GetComponent<Renderer>().material = withoutFirefly;
        hasFirefly = false;
    }

    public void Interact()
    {
        if (hasFirefly)
        {
            RemoveFirefly();
            switchable.GetComponent<ISwitchable>().Switch(false);
            playerGrab.heldFireflies++;
        }
        else if(playerGrab.heldFireflies > 0)
        {
            AddFirefly();
            switchable.GetComponent<ISwitchable>().Switch(true);
            playerGrab.heldFireflies--;
            Debug.Log("Firefly added");
        }
    }
}
