using UnityEngine;

public class Button : MonoBehaviour
{
    public Door linkedDoor;

    public void Activate()
    {
        linkedDoor.OpenDoor();
    }
}