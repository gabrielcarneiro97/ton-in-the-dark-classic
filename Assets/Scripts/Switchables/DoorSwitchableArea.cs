using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitchableArea : MonoBehaviour
{
    [SerializeField] Door door;
    public void Switch()
    {
        door.Switch();
    }
}
