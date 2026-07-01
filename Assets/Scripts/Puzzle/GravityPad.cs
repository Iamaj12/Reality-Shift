using UnityEngine;
using StarterAssets;

public class GravityPad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GravityFirstPersonController controller =
                other.GetComponent<GravityFirstPersonController>();

            if (controller != null)
            {
                controller.FlipPlayer();
            }
        }
    }

}
