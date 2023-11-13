using UnityEngine;

public class LighthouseInteraction : MonoBehaviour
{
    public LighthouseLight rotateLight; // The RotateLight script that should be toggled

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is Ellen
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered lighthouse trigger area");
            // Toggle the light and rotation by calling the method on rotateLight
            if (rotateLight != null)
                rotateLight.ToggleLightAndRotation();
        }
    }
}
