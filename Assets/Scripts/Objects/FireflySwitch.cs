using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflySwitch : MonoBehaviour
{
    public bool hasFirefly;

    public Material withFirefly, withoutFirefly;

    public void AddFirefly()
    {
        GetComponent<Renderer>().material = withFirefly;
        hasFirefly = true;
    }

    public void RemoveFirefly()
    {
        GetComponent<Renderer>().material = withoutFirefly;
        hasFirefly = false;
    }
}
