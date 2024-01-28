using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflySwitch : MonoBehaviour
{
    public Observable<bool> hasFirefly = new(false);
    public GameObject tip;
    public PlayerGrab playerGrab;
    [SerializeField] public GameObject switchable;
    public SphereCollider lightCollider;

    public Material withFirefly, withoutFirefly;
    public SwitchCable switchCable;
    public float radius;


    void Start()
    {
        radius = lightCollider.radius;
        lightCollider.radius = 0;
        switchCable = GetComponentInChildren<SwitchCable>();
        hasFirefly.Subscribe((hasFirefly) =>
        {
            if (hasFirefly) tip.GetComponent<Renderer>().material = withFirefly;
            else tip.GetComponent<Renderer>().material = withoutFirefly;

            lightCollider.radius = hasFirefly ? radius : 0;
            switchCable.SetLightActive(hasFirefly);
        });
    }


    public void Interact()
    {
        if (hasFirefly.value)
        {
            hasFirefly.value = false;
            if (switchable != null) switchable.GetComponent<ISwitchable>().Switch(false);
            playerGrab.heldFireflies.value++;
        }
        else if (playerGrab.heldFireflies.value > 0)
        {
            hasFirefly.value = true;
            if (switchable != null) switchable.GetComponent<ISwitchable>().Switch(true);
            playerGrab.heldFireflies.value--;
        }
    }
}
