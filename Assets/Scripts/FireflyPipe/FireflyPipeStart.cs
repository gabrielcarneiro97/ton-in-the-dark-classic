using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyPipeStart : MonoBehaviour, IInteractable
{
    [SerializeField] FireflyPipe fireflyPipe;
    public PlayerGrab playerGrab;

    public void Interact()
    {
        if (fireflyPipe.hasFirefly.value) return;

        if (playerGrab.heldFireflies > 0)
        {
            // TODO: animate close pipe
            fireflyPipe.hasFirefly.value = true;
            playerGrab.heldFireflies--;
            StartCoroutine(fireflyPipe.RunThroughPipe());
        }
    }
}
