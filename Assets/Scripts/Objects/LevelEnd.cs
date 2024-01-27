using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public bool flyToLevelEnd;
    public bool doneFlyToLevelEnd = false;
    public GameObject fireflyPrefab;

    private void Update() {
        if(flyToLevelEnd && !doneFlyToLevelEnd)
        {
            Debug.Log("Fly to level end");
            foreach(FireflySwitch fireflySwitch in FindObjectsByType<FireflySwitch>(FindObjectsSortMode.None))
            {
                if(fireflySwitch.hasFirefly.value)
                {
                    fireflySwitch.tip.GetComponent<Renderer>().material = fireflySwitch.withoutFirefly;
                    fireflySwitch.switchCable.SetLightActive(false);
                    Instantiate(fireflyPrefab, fireflySwitch.transform.position, Quaternion.identity);
                }
            }
            foreach(Firefly firefly in FindObjectsByType<Firefly>(FindObjectsSortMode.None))
            {
                firefly.flyToLevelEnd = true;
                firefly.GetComponent<Collider>().enabled = false;
            }
            doneFlyToLevelEnd = true;
        }
    }
}
