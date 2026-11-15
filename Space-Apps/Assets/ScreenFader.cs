using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    public float delayBeforeFade = 5f; // Temps d'attente avant le fondu
    public float fadeSpeed = 1f;       // Vitesse du fondu

    void Start()
    {
        // Se déclenche automatiquement au chargement de la scène
        StartCoroutine(FadeToBlackRoutine());
    }

    private IEnumerator FadeToBlackRoutine()
    {
        // 1. Le script attend le délai défini (3 secondes)
        yield return new WaitForSeconds(delayBeforeFade);

        // 2. L'attente est terminée, on lance la transition vers le noir (Alpha = 1)
        Color currentColor = fadeImage.color;
        float alpha = currentColor.a;

        while (alpha < 1f)
        {
            alpha = Mathf.MoveTowards(alpha, 1f, fadeSpeed * Time.deltaTime);
            currentColor.a = alpha;
            fadeImage.color = currentColor;
            
            yield return null;
        }
    }
}