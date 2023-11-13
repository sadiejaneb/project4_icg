using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public Color[] colors; // Array of colors
    public float colorChangeSpeed = 1.0f;
    private int currentColorIndex = 0;
    private float transitionProgress = 0f; // Tracks the progress of the color transition

    private Material material;
    private ParticleSystem particleEffect;
    private Renderer myRenderer;
    private AudioSource audioSource;


    void Start()
    {
        // Get the Particle System component
        particleEffect = GetComponentInChildren<ParticleSystem>();

        // Get the Renderer component
        myRenderer = GetComponent<Renderer>();
        material = myRenderer.material; // Get a reference to the material
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (colors.Length < 2) return; // Ensure there are at least two colors

        // Calculate the next color index
        int nextColorIndex = (currentColorIndex + 1) % colors.Length;

        // Update the transition progress
        transitionProgress += Time.deltaTime * colorChangeSpeed;

        // Lerp the color of the material
        material.color = Color.Lerp(colors[currentColorIndex], colors[nextColorIndex], transitionProgress);

        // Check if the transition is complete
        if (transitionProgress >= 1f)
        {
            // Move to the next color
            currentColorIndex = nextColorIndex;
            // Reset the transition progress
            transitionProgress = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with object: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered magic ball's trigger area");
            if (particleEffect != null && !particleEffect.isPlaying)
            {
                particleEffect.Play();
            }
            // Play the sound
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exit detected with object: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited magic ball's trigger area");
            if (particleEffect != null && particleEffect.isPlaying)
            {
                particleEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            }
            // Stop the sound if it should only play while in contact
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}