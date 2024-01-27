using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    GameManager gameManager;
    public int level = 0;
    public Observable<bool> isOpen = new(false);

    public GameObject doorColliderGameObject;

    void Start()
    {
        gameManager = GameManager.instance;

        isOpen.Subscribe((bool isOpen) =>
        {
            Debug.Log($"Door {level}: {isOpen}");
            if (isOpen)
            {
                Debug.Log("Opening door");
                doorColliderGameObject.SetActive(false);
            }
        });

        if (level <= gameManager.maxLevel.value) isOpen.value = true;

        gameManager.maxLevel.Subscribe((int maxLevel) =>
        {
            if (level <= maxLevel) isOpen.value = true;
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
