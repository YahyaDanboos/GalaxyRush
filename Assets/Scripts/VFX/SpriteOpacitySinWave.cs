using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOpacitySinWave : MonoBehaviour
{
    [Header("Component References")]
    public SpriteRenderer spriteRenderer;

    [Header("Settings")]
    // Duration of the effect
    public float duration = 3f; 

    void Start()
    {
        StartCoroutine(OpacityWave());
    }

    IEnumerator OpacityWave()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float sinValue = Mathf.Sin(elapsedTime * Mathf.PI * 2 * 3);
            float alpha = Mathf.Lerp(0.5f, 1f, (sinValue + 1) / 2);

            Color newColor = spriteRenderer.color;
            newColor.a = alpha;
            spriteRenderer.color = newColor;

            yield return null;
        }

        Color color = spriteRenderer.color;
        color.a = 1f;
        spriteRenderer.color = color;

        yield return null;
    }
}