using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseControlller : UserInterface
{
    // Start is called before the first frame update
    public new void Start()
    {
        buttonNames.Add("Resume");
        buttonNames.Add("Restart");
        buttonNames.Add("ReturnToHub");

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
            "Restart" => (ClickEvent ev) =>
            {
                visible.value = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
            ,
            "ReturnToHub" => (ClickEvent ev) =>
            {
                visible.value = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/HubScene");
            }
            ,
            _ => (ClickEvent ev) => { }
            ,
        };
    }

}
