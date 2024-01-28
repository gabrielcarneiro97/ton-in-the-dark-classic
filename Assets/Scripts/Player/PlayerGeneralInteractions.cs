using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneralInteractions : MonoBehaviour
{
    public UserInterface pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pauseUI.visible.value = !pauseUI.visible.value;
        }
        if (Input.GetButtonDown("Cancel") && pauseUI.visible.value)
        {
            pauseUI.visible.value = false;
        }
    }
}
