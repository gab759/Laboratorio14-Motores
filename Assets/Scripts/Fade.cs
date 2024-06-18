using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Color currentColor;
    [SerializeField] private Color starColor;
    [SerializeField] private Color TargetColor;

    public void CallSimpleFadeIn()
    {
        StartCoroutine(FadeInNull());
    }
    public void CallComplexFadeIn()
    {
        StartCoroutine(FadeInWait());
    }
    IEnumerator FadeInNull()
    {
        currentColor = starColor;
        for(float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            currentColor.a = alpha;
            image.color = currentColor;
            yield return null;
        }
    }
    IEnumerator FadeInWait()
    {
        currentColor = starColor;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            currentColor.a = alpha;
            image.color = currentColor;
            yield return new WaitForSeconds(0.05f); 
        }
    }
}
