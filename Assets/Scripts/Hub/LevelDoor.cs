using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    GameManager gameManager;
    public int level = 0;
    public Observable<bool> isOpen = new(false);

    public HubManager hubManager;

    public Door door;

    void Awake()
    {
        isOpen.Subscribe((bool isOpen) =>
        {
            door.Switch(isOpen);
        });
        hubManager.activeSwitches.Subscribe((int activeSwitches) =>
        {
            Debug.Log("activeSwitches: " + activeSwitches);
            isOpen.value = level <= activeSwitches;
        });
    }
    void Start()
    {
        gameManager = GameManager.instance;
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
