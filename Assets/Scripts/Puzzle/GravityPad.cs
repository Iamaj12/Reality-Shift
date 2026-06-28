using UnityEngine;
using StarterAssets;

public class GravityPad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstPersonController controller =
                other.GetComponent<FirstPersonController>();

            if (controller != null)
            {
                controller.FlipPlayer();
            }
        }
    }

}
