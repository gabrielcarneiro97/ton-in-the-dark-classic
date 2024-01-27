using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    GameManager gameManager;
    public int level = 0;
    public bool isOpen = false;

    void Start()
    {
        gameManager = GameManager.instance;

        if (level <= gameManager.maxLevel.value) isOpen = true;

        gameManager.maxLevel.Subscribe((int maxLevel) =>
        {
            if (level <= maxLevel) isOpen = true;
        });
    }
}
