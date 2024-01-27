using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireflySwitchInteractableArea : MonoBehaviour, IInteractable
{
    [SerializeField] FireflySwitch fireflySwitch;
    public void Interact()
    {
        fireflySwitch.Interact();
    }
}
