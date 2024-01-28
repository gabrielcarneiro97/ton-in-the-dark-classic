using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class FireflyPipe : MonoBehaviour
{
    public Observable<bool> hasFirefly = new(false);
    public SplineAnimate fireflySplineAnimate;
    public GameObject firefly;
    public FireflySwitch fireflySwitch;
    public GameObject fireflySwitchInteractableArea;
    public FireflyPipeStart fireflyPipeStart;

    void Start()
    {
        fireflyPipeStart = GetComponentInChildren<FireflyPipeStart>();
        fireflySwitch.hasFirefly.Subscribe((hasFireflySwitch) =>
        {
            hasFirefly.value = hasFireflySwitch;
            if(!hasFireflySwitch) StartCoroutine(fireflyPipeStart.AnimateOpen());
        });
    }

    public IEnumerator RunThroughPipe()
    {
        var newFirefly = Instantiate(firefly, firefly.transform.position, Quaternion.identity);
        fireflySwitchInteractableArea.SetActive(false);
        newFirefly.SetActive(true);
        yield return new WaitForSeconds(fireflySplineAnimate.Duration);
        Destroy(newFirefly);
        fireflySwitchInteractableArea.SetActive(true);
        fireflySwitch.hasFirefly.value = true;
    }
}
