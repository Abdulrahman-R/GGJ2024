using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    [SerializeField] float maxBrightness; // Adjust this value to control the brightness threshold
    [SerializeField] float minBrightness;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ChangeBackgroundColor()
    {
        Color randomColor = GenerateRandomBrightColor();
        spriteRenderer.color = randomColor;
    }

    private Color GenerateRandomBrightColor()
    {

        float hue = Random.value;
        float saturation = Random.Range(0.5f, 1f);
        float brightness = Random.Range(minBrightness, maxBrightness);

        return Color.HSVToRGB(hue, saturation, brightness);

    }
}
