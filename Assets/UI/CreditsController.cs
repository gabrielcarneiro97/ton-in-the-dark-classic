using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CreditsController : UserInterface
{
    public UserInterface menuUI;
    // Start is called before the first frame update
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

}
