using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : UserInterface
{
    public UserInterface creditsUI;
    public UserInterface controlsUI;
    public new void Start()
    {
        buttonNames.Add("Start");
        buttonNames.Add("Controls");
        buttonNames.Add("Options");
        buttonNames.Add("Credits");
        buttonNames.Add("Exit");

        base.Start();
    }
    public override EventCallback<ClickEvent> HandleClick(string buttonName)
    {
        return buttonName switch
        {
            "Start" => (ClickEvent ev) => SceneManager.LoadScene("Scenes/HubScene"),
            "Credits" => (ClickEvent ev) =>
            {
                creditsUI.visible.value = true;
                visible.value = false;
            }
            ,
            "Controls" => (ClickEvent ev) =>
            {
                controlsUI.visible.value = true;
                visible.value = false;
            }
            ,
            "Exit" => (ClickEvent ev) => Application.Quit(),
            _ => (ClickEvent ev) => { }
            ,
        };
    }

}
