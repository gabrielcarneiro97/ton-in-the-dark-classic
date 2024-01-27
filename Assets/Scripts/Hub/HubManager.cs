using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubManager : MonoBehaviour, ISwitchable
{
    GameManager gameManager;
    public Observable<int> activeSwitches = new(0);

    public List<GameObject> levelDoors = new();

    void Start()
    {
        gameManager = GameManager.instance;
    }

    public void Switch(bool fireflySwitchState)
    {
        Debug.Log($"Switching firefly switch to {fireflySwitchState}");
        activeSwitches.value += fireflySwitchState ? 1 : -1;
        Debug.Log($"Active switches: {activeSwitches.value}");
    }

}
