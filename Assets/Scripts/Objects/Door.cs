using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , ISwitchable
{
    bool isOpen;
    public int energyRequired = 1;
    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;
    int energySourceCount;
    public void Switch(bool value)
    {
        if(value)
        {
            energySourceCount++;
        }
        else
        {
            energySourceCount--;
        }

        if(energySourceCount >= energyRequired)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    void Open()
    {
        isOpen = true;
        leftDoor.transform.localRotation = Quaternion.Euler(0, 90, 0);
        rightDoor.transform.localRotation = Quaternion.Euler(0, -90, 0);
    }

    void Close()
    {
        isOpen = false;
        leftDoor.transform.localRotation = Quaternion.Euler(0, 0, 0);
        rightDoor.transform.localRotation = Quaternion.Euler(0, 0, 0);
        
    }
}
