using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflySwitch : MonoBehaviour
{
    public bool hasFirefly;
    public GameObject tip;
    public PlayerGrab playerGrab;

    public Material withFirefly, withoutFirefly;

    public void AddFirefly()
    {
        tip.GetComponent<Renderer>().material = withFirefly;
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
            playerGrab.heldFireflies++;
        }
        else if(playerGrab.heldFireflies > 0)
        {
            AddFirefly();
            playerGrab.heldFireflies--;
        }
    }
}
