using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : UserInterface
{
    public new void Start()
    {
        buttonNames.Add("Start");
        buttonNames.Add("Options");
        buttonNames.Add("Exit");

        base.Start();
    }
    public override EventCallback<ClickEvent> HandleClick(string buttonName)
    {
        return buttonName switch
        {
            "Start" => (ClickEvent ev) => Debug.Log("Start"),
            _ => (ClickEvent ev) => { }
            ,
        };
    }

}
