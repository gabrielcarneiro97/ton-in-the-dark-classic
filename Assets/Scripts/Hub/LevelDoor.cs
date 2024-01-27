using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    GameManager gameManager;
    public int level = 0;
    public Observable<bool> isOpen = new(false);

    public GameObject doorColliderGameObject;

    HubManager hubManager;

    void Start()
    {
        gameManager = GameManager.instance;
        hubManager = GameObject.Find("HubManager").GetComponent<HubManager>();

        isOpen.Subscribe((bool isOpen) =>
        {
            // Debug.Log($"Door {level}: {isOpen}");
            if (isOpen)
            {
                // Debug.Log("Opening door");
                doorColliderGameObject.SetActive(false);
            }
        });

        if (level <= gameManager.maxLevel.value) isOpen.value = true;

        hubManager.activeSwitches.Subscribe((int activeSwitches) =>
        {
            if (level <= activeSwitches) isOpen.value = true;
        });
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3 && isOpen.value)
        {
            // TODO: load level
        }
    }
}
