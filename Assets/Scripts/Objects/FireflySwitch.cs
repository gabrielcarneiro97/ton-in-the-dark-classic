using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireflySwitch : MonoBehaviour
{
    public Observable<bool> hasFirefly = new(false);
    public GameObject tip;
    public PlayerGrab playerGrab;
    [SerializeField] public GameObject switchable, switchable2;
    public SphereCollider lightCollider;

    public Material withFirefly, withoutFirefly;
    public SwitchCable switchCable, switchCable2;
    public float radius;
    public GameObject vagalumeVisual;

    void Awake()
    {
        hasFirefly.Subscribe((hasFirefly) =>
        {
            if (hasFirefly) tip.GetComponent<Renderer>().material = withFirefly;
            else tip.GetComponent<Renderer>().material = withoutFirefly;

            lightCollider.radius = hasFirefly ? radius : 0;
            vagalumeVisual.SetActive(hasFirefly);
            if (switchCable != null) switchCable.SetLightActive(hasFirefly);
            if (switchCable2 != null) switchCable2.SetLightActive(hasFirefly);
            if (switchable != null) switchable.GetComponent<ISwitchable>().Switch(hasFirefly);
            if(switchable2 != null) switchable2.GetComponent<ISwitchable>().Switch(hasFirefly);
        });
    }

    void Start()
    {
        radius = lightCollider.radius;
        lightCollider.radius = 0;
        switchCable = GetComponentInChildren<SwitchCable>();
    }


    public void Interact()
    {
        if (hasFirefly.value)
        {
            hasFirefly.value = false;
            playerGrab.heldFireflies.value++;
        }
        else if (playerGrab.heldFireflies.value > 0)
        {
            hasFirefly.value = true;
            playerGrab.heldFireflies.value--;
        }
    }
}
