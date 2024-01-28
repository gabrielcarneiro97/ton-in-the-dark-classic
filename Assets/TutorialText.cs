using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    bool isRunning = false;
    public TMP_Text text;
    float runningTime = 0f;
    float totalRunningTime = 5f;

    void Update()
    {
        if (isRunning)
        {
            text.enabled = true;
            runningTime += Time.deltaTime;
            if (runningTime < totalRunningTime / 2)
            {
                text.alpha = Mathf.Lerp(0, 1, runningTime / (totalRunningTime / 2));
            }
            else
            {
                text.alpha = Mathf.Lerp(1, 0, (runningTime - totalRunningTime / 2) / (totalRunningTime / 2));
            }
        }
        else
        {
            runningTime = 0f;
            text.enabled = false;
        }
    }

    public IEnumerator ShowText(string textToShow)
    {
        if (isRunning)
        {
            yield return new WaitForSeconds(totalRunningTime - runningTime);
        }
        text.text = textToShow;
        isRunning = true;
        runningTime = 0f;
        yield return new WaitForSeconds(totalRunningTime);
        isRunning = false;
    }
}
