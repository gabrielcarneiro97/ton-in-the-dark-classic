using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : UserInterface
{
    GameManager gameManager;
    SoundManager soundManager;
    public UserInterface creditsUI;
    public UserInterface controlsUI;
    public UserInterface optionsUI;
    public new void Start()
    {
        gameManager = GameManager.instance;
        soundManager = SoundManager.instance;
        buttonNames.Add("Start");
        buttonNames.Add("Controls");
        buttonNames.Add("Options");
        buttonNames.Add("Credits");
        buttonNames.Add("Cutscene");
        buttonNames.Add("Exit");

        base.Start();
    }
    public override EventCallback<ClickEvent> HandleClick(string buttonName)
    {
        return buttonName switch
        {
            "Start" => (ClickEvent ev) =>
            {
                gameManager.sceneToLoad = "Scenes/HubScene";
                gameManager.StartLoading();
            }
            ,
            "Credits" => (ClickEvent ev) =>
            {
                creditsUI.visible.value = true;
                visible.value = false;
            }
            ,
            "Options" => (ClickEvent ev) =>
            {
                optionsUI.visible.value = true;
                visible.value = false;
            }
            ,
            "Cutscene" => (ClickEvent ev) =>
            {
                soundManager.ChangeAmbientVolume(0);
                soundManager.ChangeEffectsVolume(0);
                gameManager.sceneToLoad = "Scenes/CutScene";
                gameManager.StartLoading();
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
