using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    GameManager gameManager;
    public int level = 0;
    public Observable<bool> isOpen = new(false);

    public HubManager hubManager;

    public Door door;

    void Start()
    {
        gameManager = GameManager.instance;
        isOpen.Subscribe((bool isOpen) =>
        {
            door.Switch(isOpen);
        });

        isOpen.value = gameManager.hubActiveSwitches.value.Count >= level;
        gameManager.hubActiveSwitches.Subscribe((HashSet<string> hubActiveSwitches) =>
        {
            isOpen.value = hubActiveSwitches.Count >= level;
        });
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3 && isOpen.value)
        {
            gameManager.sceneToLoad = "Scenes/Levels/Level0" + level;
            gameManager.StartLoading();
        }
    }
}
