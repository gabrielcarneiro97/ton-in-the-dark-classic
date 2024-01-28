using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public PlayerGrab playerGrab;
    public SphereCollider fireflyLightCollider;
    public Transform lanternPos;
    float radius;

    private void Awake()
    {
        var light = GetComponent<Light>();
        playerGrab.heldFireflies.Subscribe((heldFireflies) =>
        {
            Debug.Log("Held fireflies: " + heldFireflies);
            if (heldFireflies > 0)
            {
                light.enabled = true;
            }
            else
            {
                light.enabled = false;
            }
            SetLightParams(heldFireflies, light);
        });
    }

    private void Start()
    {
        radius = fireflyLightCollider.radius;
        fireflyLightCollider.radius = 0;
    }

    void SetLightParams(int heldFireflies, Light light)
    {
        transform.position = new Vector3(lanternPos.position.x, lanternPos.position.y + 3 + 2.2f * heldFireflies, lanternPos.position.z);

        light.intensity = heldFireflies switch
        {
            0 => 9999,
            1 => 40,
            2 => 120,
            3 => 280,
            4 => 500,
            5 => 1200,
            > 5 => 1200,
            _ => 9999,
        };
        fireflyLightCollider.radius = 5 + heldFireflies * 5f;
        if (heldFireflies == 0)
        {
            fireflyLightCollider.radius = 0;
        }
    }
}
