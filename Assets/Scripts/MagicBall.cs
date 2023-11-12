using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public Color startColor = Color.blue;
    public Color endColor = Color.green;
    public float colorChangeSpeed = 1.0f;

    private Material material;
    private ParticleSystem particleEffect;
    private Renderer renderer;
    private AudioSource audioSource;

    void Start()
    {
        // Get the Particle System component
        particleEffect = GetComponentInChildren<ParticleSystem>();

        // Get the Renderer component
        renderer = GetComponent<Renderer>(); // This is the updated line
        material = renderer.material; // Get a reference to the material
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Lerp the color of the material based on the time
        material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * colorChangeSpeed, 1));
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