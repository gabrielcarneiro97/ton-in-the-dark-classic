using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , ISwitchable
{
    bool isOpen;
    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;
    public void Switch(bool value)
    {
        if(value)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    void Open()
    {
        isOpen = true;
        leftDoor.transform.rotation = Quaternion.Euler(0, 90, 0);
        rightDoor.transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    void Close()
    {
        isOpen = false;
        leftDoor.transform.rotation = Quaternion.Euler(0, 0, 0);
        rightDoor.transform.rotation = Quaternion.Euler(0, 0, 0);
        
    }
}
