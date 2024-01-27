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

    void Start()
    {
        fireflySwitch.hasFirefly.Subscribe((hasFireflySwitch) =>
        {
            if (hasFireflySwitch) hasFirefly.value = false;
        });
    }

    public IEnumerator RunThroughPipe()
    {
        Debug.Log("Running through pipe");
        var newFirefly = Instantiate(firefly, firefly.transform.position, Quaternion.identity);
        newFirefly.SetActive(true);
        yield return new WaitForSeconds(fireflySplineAnimate.Duration);
        Destroy(newFirefly);
        fireflySwitch.hasFirefly.value = true;
    }
}
