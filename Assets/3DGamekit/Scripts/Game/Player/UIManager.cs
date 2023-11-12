using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Gamekit3D;

public class UIManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private bool isFading = false;
    public bool IsFading { get { return isFading; } }

    private void Start()
    {
        // Optional: Start with a fully transparent fade image if you want the screen to be visible at the start.
        SetFade(0f);
    }
    public IEnumerator FadeSceneOut()
    {
        yield return FadeScreen(1f); // Fades to fully opaque (black)
    }

    public IEnumerator FadeSceneIn()
    {
        yield return FadeScreen(0f); // Fades to fully transparent (clear)
    }
    private void SetFade(float alpha)
    {
        // Make sure to check if fadeImage is assigned to avoid null reference exceptions
        if (fadeImage != null)
        {
            Color newColor = fadeImage.color;
            newColor.a = alpha;
            fadeImage.color = newColor;
        }
        else
        {
            Debug.LogError("Fade image not assigned in UIManager.");
        }
    }


    IEnumerator FadeScreen(float targetAlpha)
    {
        // We're starting a new fade, set isFading to true
        isFading = true;

        float startAlpha = fadeImage.color.a;

        for (float t = 0f; t < fadeDuration; t += Time.deltaTime)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, t / fadeDuration);
            SetFade(newAlpha);
            yield return null;
        }

        SetFade(targetAlpha);

        // Fade is complete, set isFading to false
        isFading = false;
    }
}