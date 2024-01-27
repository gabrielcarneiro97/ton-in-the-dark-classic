using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyLight : MonoBehaviour
{
    Light light;
    public Renderer renderer;
    public float pulseSpeed = 1f;
    public float pulseAmount = 0.5f;

    private void Start() {
        light = GetComponent<Light>();
    }

    private void Update() {
        light.intensity = 10 + pulseAmount * Mathf.Sin(Time.time * pulseSpeed);
        renderer.material.SetFloat("_EmissionMapIntensity", 0.5f + pulseAmount * Mathf.Sin(Time.time * pulseSpeed));
    }
}
