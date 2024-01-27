using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyPipeStartInteractableArea : MonoBehaviour, IInteractable
{
    [SerializeField] FireflyPipeStart fireflyPipeStart;
    public void Interact()
    {
        fireflyPipeStart.Interact();
    }

}
