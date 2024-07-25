using System.Collections;
using UnityEngine;

public class ImageFade : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image image;
    [SerializeField] float fadeTime;
    private Color originalColor;

    private void Awake()
    {
        originalColor = image.color;
    }
    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }

    public void DisableImage()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        //print("Comecou Transicao");
        float timeMultiplier = 1 / fadeTime;

        //print($"Alpha original: {transitionScreen.color.a}");

        Color currentColor = originalColor; 
            
        currentColor.a = 0;
            
        image.color = currentColor;

        //print("ativou " + transitionScreen.gameObject.name);

        while (image.color.a < originalColor.a)
        {
            currentColor.a += originalColor.a * (Time.deltaTime * timeMultiplier);
            image.color = currentColor;
            //print($"Alpha aumentando: {transitionScreen.color.a}");
            yield return null;
        }   
    }
    IEnumerator FadeOut()
    {
        float timeMultiplier = 1 / fadeTime;

        Color currentColor = originalColor;

        image.color = currentColor;

        while (image.color.a > 0)
        {
            currentColor.a -= originalColor.a * (Time.deltaTime * timeMultiplier);
            image.color = currentColor;

            yield return null;
        }

        image.gameObject.SetActive(false);
        yield return null;

    }

    public void SwitchState()
    {
        if (gameObject.activeSelf)
        {
            DisableImage();
        }
        else gameObject.SetActive(true);
    }
}
