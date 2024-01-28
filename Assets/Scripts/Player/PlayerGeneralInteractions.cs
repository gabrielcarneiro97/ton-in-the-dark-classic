using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneralInteractions : MonoBehaviour
{
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    const string pauseButton = "Start_Mac";
    const string backButton = "Back_Mac";
#elif UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    const string pauseButton = "Start_Windows";
    const string backButton = "Back_Windows";
#endif
    public UserInterface pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(pauseButton))
        {
            pauseUI.visible.value = !pauseUI.visible.value;
        }
        if (Input.GetButtonDown(backButton) && pauseUI.visible.value)
        {
            pauseUI.visible.value = false;
        }
    }
}
