using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingController : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
        if (gameManager.sceneToLoad == "") gameManager.sceneToLoad = "Scenes/HubScene";
        gameManager.LoadScene();
    }

}
