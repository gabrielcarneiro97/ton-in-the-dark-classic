using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlsController : UserInterface
{
    public UserInterface menuUI;

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    const string backButton = "Back_Mac";
#elif UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    const string backButton = "Back_Windows";
#endif
    public new void Start()
    {
        buttonNames.Add("BackToMenu");
        base.Start();
    }

    public override EventCallback<ClickEvent> HandleClick(string buttonName)
    {
        return buttonName switch
        {
            "BackToMenu" => (ClickEvent ev) =>
            {
                menuUI.visible.value = true;
                visible.value = false;
            }
            ,
            _ => (ClickEvent ev) => { }
            ,
        };
    }

    public new void Update()
    {
        if (!visible.value) return;
        base.Update();

        if (Input.GetButtonDown(backButton))
        {
            HandleClick("BackToMenu")(null);
        }

    }

}
