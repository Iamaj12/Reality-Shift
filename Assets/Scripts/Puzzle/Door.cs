using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 openPosition;
    public float speed = 2f;

    private Vector3 closedPosition;
    public bool isOpen = false;

    void Start()
    {
        closedPosition = transform.position;
    }

    void Update()
    {
        Vector3 target = isOpen ? openPosition : closedPosition;

        transform.position =
            Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }
}
