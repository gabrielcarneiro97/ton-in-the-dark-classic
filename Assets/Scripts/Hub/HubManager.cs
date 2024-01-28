using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubManager : MonoBehaviour, ISwitchable
{
    public Observable<int> activeSwitches = new(0);

    public void Switch(bool fireflySwitchState)
    {
        activeSwitches.value += fireflySwitchState ? 1 : -1;
    }

}
