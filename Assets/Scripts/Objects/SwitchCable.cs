using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SwitchCable : MonoBehaviour
{
    public Material onMaterial;
    public Material offMaterial;

    public List<GameObject> poles = new List<GameObject>();
    LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() 
    {
        if(lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = poles.Count;
        for (int i = 0; i < poles.Count; i++)
        {
            lineRenderer.SetPosition(i, poles[i].transform.position);
        }
    }

    public void SetLightActive(bool value)
    {
        if (value)
        {
            lineRenderer.material = onMaterial;
        }
        else
        {
            lineRenderer.material = offMaterial;
        }

    }
}
