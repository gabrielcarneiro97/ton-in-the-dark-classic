using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubManager : MonoBehaviour
{
    GameManager gameManager;
    public int selectedLevel = 0;

    public List<GameObject> levelDoors = new();
    public GameObject selector;

    void Start()
    {
        gameManager = GameManager.instance;
        selectedLevel = gameManager.maxLevel.value;
        gameManager.maxLevel.Subscribe(OnMaxLevelChange);
    }

    void OnMaxLevelChange(int maxLevel)
    {
        selectedLevel = maxLevel;
    }

}
