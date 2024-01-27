using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , ISwitchable
{
    public int energyRequired = 1;
    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;
    public int energySourceCount;
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
            StartCoroutine(LeftDoorAnimation(true));
            StartCoroutine(RightDoorAnimation(true));
        }
        else
        {
            StartCoroutine(LeftDoorAnimation(false));
            StartCoroutine(RightDoorAnimation(false));
        }
    }

    IEnumerator LeftDoorAnimation(bool value)
    {
        CinemachineShake.Instance.ShakeCamera(1f, 0.5f, CinemachineShake.ShakeType.STABLE);
        float t = 0;
        Quaternion startRotation = leftDoor.transform.localRotation;
        Quaternion endRotation = value ? Quaternion.Euler(0, 90, 0) : Quaternion.Euler(0, 0, 0);
        while(t < 1)
        {
            t += Time.deltaTime * 2;
            leftDoor.transform.localRotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }
        
    }

    IEnumerator RightDoorAnimation(bool value)
    {
        float t = 0;
        Quaternion startRotation = rightDoor.transform.localRotation;
        Quaternion endRotation = value ? Quaternion.Euler(0, -90, 0) : Quaternion.Euler(0, 0, 0);
        while(t < 1)
        {
            t += Time.deltaTime * 2;
            rightDoor.transform.localRotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }
        
    }
}
