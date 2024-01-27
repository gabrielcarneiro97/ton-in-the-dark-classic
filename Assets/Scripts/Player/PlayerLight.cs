using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public PlayerGrab playerGrab;
    Light light;
    public SphereCollider fireflyLightCollider;

    private void Start() 
    {
        light = GetComponent<Light>();
    }

    private void Update() 
    {
        if(playerGrab.heldFireflies > 0)
        {
            light.enabled = true;
            fireflyLightCollider.enabled = true;
        }
        else
        {
            light.enabled = false;
            fireflyLightCollider.enabled = false;
        }

        light.spotAngle = 70 + playerGrab.heldFireflies * 30;
        light.innerSpotAngle = 40 + playerGrab.heldFireflies * 25;
        fireflyLightCollider.radius = playerGrab.heldFireflies * 2f;
    }
}
