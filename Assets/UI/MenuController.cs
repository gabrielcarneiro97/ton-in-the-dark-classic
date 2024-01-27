using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : UserInterface
{
    new void Start()
    {
        base.Start();
        root.Q<Button>("Start").RegisterCallbackOnce<ClickEvent>(HandleStartClick);
    }

    void HandleStartClick(ClickEvent ev)
    {
        Debug.Log("Start");
    }
}
