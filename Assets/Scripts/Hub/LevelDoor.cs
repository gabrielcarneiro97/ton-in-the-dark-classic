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
            Debug.Log("Level " + level + " is open: " + isOpen);
            door.Switch(isOpen);
        });

        if (level <= gameManager.lastLevelCompleted.value) isOpen.value = true;

        hubManager.activeSwitches.Subscribe((int activeSwitches) =>
        {
            if (level <= activeSwitches) Debug.Log("Level " + level + " is open");
            isOpen.value = level <= activeSwitches;
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
