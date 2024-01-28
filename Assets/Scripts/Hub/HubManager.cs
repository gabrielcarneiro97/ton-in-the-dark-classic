using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubManager : MonoBehaviour, ISwitchable
{
    GameManager gameManager;
    public Observable<int> activeSwitches = new(0);
    public List<FireflySwitch> fireflySwitches = new();

    public GameObject initialFirefly;

    void Start()
    {
        gameManager = GameManager.instance;
        bool someActive = false;

        foreach (FireflySwitch fireflySwitch in fireflySwitches)
        {

            if (gameManager.hubActiveSwitches.value.Contains(fireflySwitch.name))
            {
                fireflySwitch.hasFirefly.value = true;
                someActive = true;
            }
            fireflySwitch.hasFirefly.Subscribe((bool hasFirefly) =>
            {
                if (hasFirefly)
                    gameManager.hubActiveSwitches.Add(fireflySwitch.name);
                else
                    gameManager.hubActiveSwitches.Remove(fireflySwitch.name);
            });
        }

        activeSwitches.value = gameManager.hubActiveSwitches.value.Count;

        if (someActive) Destroy(initialFirefly);
    }

    public void Switch(bool fireflySwitchState)
    {
        activeSwitches.value += fireflySwitchState ? 1 : -1;
    }

}
