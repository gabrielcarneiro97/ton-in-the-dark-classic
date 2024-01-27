using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public List<GameObject> closeFireflies = new List<GameObject>();
    [SerializeField] GameObject fireflyPrefab;
    public int heldFireflies = 0;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            GrabFirefly();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && heldFireflies > 0 || Input.GetKeyDown(KeyCode.Joystick1Button3) && heldFireflies > 0)
        {
            ReleaseFirefly();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "FireflyGrabArea")
        {
            closeFireflies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "FireflyGrabArea")
        {
            closeFireflies.Remove(other.gameObject);
        }
    }

    public void GrabFirefly()
    {
        if (closeFireflies.Count > 0)
        {
            closeFireflies[0].GetComponent<FireflyGrabManager>().GrabFirefly();
            heldFireflies++;
            closeFireflies.RemoveAt(0);
        }
    }

    public void ReleaseFirefly()
    {
        heldFireflies--;
        Instantiate(fireflyPrefab, transform.position + transform.forward * 2, Quaternion.identity);
    }
}
