using UnityEngine;

public class LighthouseLight : MonoBehaviour
{
    public GameObject lightObject; 
    public bool isLightOn = true; 
    public float rotationSpeed = 30.0f;

    void Start()
    {
        // Ensure the light matches the desired initial state
        if (lightObject != null && !lightObject.activeSelf && isLightOn)
        {
            lightObject.SetActive(true); // Turn on the light if it's not on
        }
    }

    void Update()
    {
        // Rotate the light if it's on
        if (isLightOn)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    public void ToggleLightAndRotation()
    {
        isLightOn = !isLightOn;
        lightObject.SetActive(isLightOn); // Toggle the light on/off
    }
}
