using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyPipeStart : MonoBehaviour, IInteractable
{
    SoundManager soundManager;
    [SerializeField] FireflyPipe fireflyPipe;
    public PlayerGrab playerGrab;
    public GameObject pivotTampa;

    void Start()
    {
        soundManager = SoundManager.instance;
    }
    public void Interact()
    {
        if (fireflyPipe.hasFirefly.value) return;

        if (playerGrab.heldFireflies.value > 0)
        {
            // TODO: animate close pipe
            fireflyPipe.hasFirefly.value = true;
            playerGrab.heldFireflies.value--;
            StartCoroutine(fireflyPipe.RunThroughPipe());
            StartCoroutine(AnimateClose());
        }
    }

    public IEnumerator AnimateClose()
    {
        soundManager.PlayCover();
        var pivot = pivotTampa.transform;
        var targetRotation = pivot.rotation * Quaternion.Euler(0, 0, 150);
        var duration = 1.5f;
        var time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            pivot.rotation = Quaternion.Lerp(pivot.rotation, targetRotation, time / duration);
            yield return null;
        }
    }

    public IEnumerator AnimateOpen()
    {
        soundManager.PlayCover();
        var pivot = pivotTampa.transform;
        var targetRotation = pivot.rotation * Quaternion.Euler(0, 0, -150);
        var duration = 1.5f;
        var time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            pivot.rotation = Quaternion.Lerp(pivot.rotation, targetRotation, time / duration);
            yield return null;
        }
    }
}
