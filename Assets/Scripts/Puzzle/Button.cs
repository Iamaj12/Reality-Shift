using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public Door linkedDoor;
    public bool isFake = false;

    [SerializeField] private string sceneToLoad;

    public void Activate()
    {
        if (isFake == true)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        linkedDoor.OpenDoor();
    }
}