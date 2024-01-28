using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    GameManager gameManager;
    public bool flyToLevelEnd;
    public bool doneFlyToLevelEnd = false;
    public GameObject fireflyPrefab;

    public int level = 0;

    public bool giveFireflyOnEnd = true;

    void Start()
    {
        gameManager = GameManager.instance;
    }
    private void Update()
    {
        if (flyToLevelEnd && !doneFlyToLevelEnd)
        {
            foreach (FireflySwitch fireflySwitch in FindObjectsByType<FireflySwitch>(FindObjectsSortMode.None))
            {
                if (fireflySwitch.hasFirefly.value)
                {
                    fireflySwitch.tip.GetComponent<Renderer>().material = fireflySwitch.withoutFirefly;
                    fireflySwitch.switchCable.SetLightActive(false);
                    Instantiate(fireflyPrefab, fireflySwitch.transform.position, Quaternion.identity);
                }
            }
            foreach (Firefly firefly in FindObjectsByType<Firefly>(FindObjectsSortMode.None))
            {
                firefly.flyToLevelEnd = true;
                firefly.GetComponent<Collider>().enabled = false;
            }
            doneFlyToLevelEnd = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flyToLevelEnd = true;
            if (gameManager.lastLevelCompleted.value < level)
            {
                gameManager.lastLevelCompleted.value = level;
                if (giveFireflyOnEnd) gameManager.heldFirefliesOnHub += 1;
            }

            gameManager.sceneToLoad = "Scenes/HubScene";
            gameManager.StartLoading();
        }
    }
}
