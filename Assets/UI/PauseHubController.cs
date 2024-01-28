using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseControlllerHub : UserInterface
{
    GameManager gameManager;
    // Start is called before the first frame update
    public new void Start()
    {
        gameManager = GameManager.instance;
        buttonNames.Add("Resume");
        buttonNames.Add("ReturnToMenu");

        base.Start();

        visible.Subscribe((bool visible) =>
        {
            Time.timeScale = visible ? 0 : 1;
        });
    }

    public override EventCallback<ClickEvent> HandleClick(string buttonName)
    {
        return buttonName switch
        {
            "Resume" => (ClickEvent ev) =>
            {
                visible.value = false;
            }
            ,
            "ReturnToMenu" => (ClickEvent ev) =>
            {
                visible.value = false;
                gameManager.sceneToLoad = "Scenes/MenuScene";
                gameManager.StartLoading();
            }
            ,
            _ => (ClickEvent ev) => { }
            ,
        };
    }

}
