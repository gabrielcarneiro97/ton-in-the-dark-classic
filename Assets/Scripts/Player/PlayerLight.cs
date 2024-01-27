using System;
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
        SetLightParams();
    }


    void SetLightParams()
    {
        transform.localPosition = new Vector3(0, 3 +  2.2f * playerGrab.heldFireflies, 0);

        switch(playerGrab.heldFireflies)
        {
            case 0:
                light.intensity = 9999;
                break;
            case 1:
                light.intensity = 40;
                break;
            case 2:
                light.intensity = 120;
                break;
            case 3:
                light.intensity = 280;
                break;
            case 4:
                light.intensity = 500;
                break;
            case 5:  
                light.intensity = 1200;
                break;
            case > 5:  
                light.intensity = 1200;
                break;
            default:
                light.intensity = 9999;
                break;
        }
        fireflyLightCollider.radius = 5 + playerGrab.heldFireflies * 5f;
    }
}
