using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialArea : MonoBehaviour
{
    bool hasRun = false;
    public string textToShow;
    public TutorialText tutorialText;

    void OnTriggerEnter(Collider other)
    {
        if (!hasRun)
        {
            if (other.gameObject.tag == "Player")
            {
                StartCoroutine(tutorialText.ShowText(textToShow));
                hasRun = true;
            }
        }
    }
}
