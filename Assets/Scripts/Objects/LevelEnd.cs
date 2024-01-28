using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    GameManager gameManager;
    public Observable<bool> flyToLevelEnd = new(false);
    public Observable<bool> doneFlyToLevelEnd = new(false);
    public GameObject fireflyPrefab;

    public GameObject player;

    public int level = 0;

    public bool giveFireflyOnEnd = true;

    void Start()
    {
        gameManager = GameManager.instance;
        doneFlyToLevelEnd.Subscribe((bool done) =>
        {
            if (!done) return;

            gameManager.sceneToLoad = "Scenes/HubScene";
            gameManager.StartLoading();
        });

        flyToLevelEnd.Subscribe((bool fly) =>
        {
            if (!fly) return;

            player.GetComponent<PlayerMovement>().enabled = false;

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
            StartCoroutine(WaitFly());
        });
    }

    IEnumerator WaitFly()
    {
        yield return new WaitForSeconds(2);
        doneFlyToLevelEnd.value = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager.lastLevelCompleted.value < level)
            {
                gameManager.lastLevelCompleted.value = level;
                if (giveFireflyOnEnd) gameManager.heldFirefliesOnHub += 1;
            }
            flyToLevelEnd.value = true;
        }
    }
}
