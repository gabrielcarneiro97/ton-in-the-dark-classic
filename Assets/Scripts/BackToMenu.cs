using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
       gameManager = GameManager.instance; 
    }

    public void ToMenu() {
        gameManager.sceneToLoad = "Scenes/MenuScene";
        gameManager.StartLoading();
    }

}
