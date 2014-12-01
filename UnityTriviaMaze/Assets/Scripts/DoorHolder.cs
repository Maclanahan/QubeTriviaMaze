using UnityEngine;
using System.Collections;
using TriviaMaze;

public class DoorHolder : MonoBehaviour {

    protected Door door;

    public void setDoor(Door newDoor)
    {
        door = newDoor;
    }

    public void knock()
    {
        if (door != null)
        {
            door.isDoorOpen();
        }

        else
            print("Door is not instanciated.");
    }
}
