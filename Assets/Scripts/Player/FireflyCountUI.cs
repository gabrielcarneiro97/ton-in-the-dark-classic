using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyCountUI : MonoBehaviour
{
    public int maxFireflies = 5;
    public Material withFirefly, withoutFirefly;

    public PlayerGrab playerGrab;

    public GameObject countObject;

    List<GameObject> counts = new();

    void Start()
    {
        for (int i = 0; i < maxFireflies; i++)
        {
            var fireflyCount = Instantiate(countObject, transform);
            fireflyCount.transform.localPosition = new Vector3(i * .5f, 0, 0);
            fireflyCount.SetActive(true);
            counts.Add(fireflyCount);
        }

        playerGrab.heldFireflies.Subscribe((heldFireflies) =>
        {
            ActiveFireflyCount(heldFireflies);
            gameObject.SetActive(true);
            StartCoroutine(ShowCount());
        });
        gameObject.SetActive(false);
    }


    void ActiveFireflyCount(int count)
    {
        for (int i = 0; i < counts.Count; i++)
        {
            if (i < count) counts[i].GetComponent<Renderer>().material = withFirefly;
            else counts[i].GetComponent<Renderer>().material = withoutFirefly;
        }
    }

    IEnumerator ShowCount()
    {
        yield return new WaitForSeconds(.8f);
        gameObject.SetActive(false);
    }
}
