using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.instance;
    }

    void PlaySteps()
    {
        soundManager.PlaySteps();
    }

}
