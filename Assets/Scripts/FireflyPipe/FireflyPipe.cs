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

    void Start()
    {
        fireflySwitch.hasFirefly.Subscribe((hasFireflySwitch) =>
        {
            hasFirefly.value = hasFireflySwitch;
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
