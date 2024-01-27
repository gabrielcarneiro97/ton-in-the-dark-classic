using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyGrabManager : MonoBehaviour
{
    [SerializeField] GameObject ownerFirefly;

    public void GrabFirefly()
    {
        Destroy(ownerFirefly);
    }
}
