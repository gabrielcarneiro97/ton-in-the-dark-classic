using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LightNoise : MonoBehaviour
{
    Light light;
    float startingIntensity;
    public float minRange, maxRange;
    private void Start() {
        light = GetComponent<Light>();
        startingIntensity = light.intensity;
    }
    
    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time, 0);
        light.intensity = Mathf.Lerp(light.intensity, Random.Range(startingIntensity - startingIntensity / 5,
         startingIntensity + startingIntensity / 5), noise);
        light.range = Mathf.Lerp(light.range, Random.Range(minRange, maxRange), noise);
    }
}
