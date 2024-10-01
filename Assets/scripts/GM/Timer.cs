using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject timerBar;
    public Sprite redBar;

    public Slider slider;
    public float duration;

    private bool isChangingValue = false;
    private float timerStartTime;

   

    void Start()
    {
        slider.value = 1f;
        StartChangingValue();

    }

    void Update()
    {
        if (isChangingValue)
        {
            float elapsedTime = Time.time - timerStartTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            slider.value = Mathf.Lerp(1f, 0f, t);

            if (t >= 1f)
            {
                isChangingValue = false;
            }

            if (slider.value <= 0.5f)
            {
                timerBar.GetComponent<Image>().sprite = redBar;
            }
            if(slider.value <= 0)
            {
                transform.parent.GetComponent<Shooting>().Shoot();
            }
        }
    }

    public void StartChangingValue()
    {
        isChangingValue = true;
        timerStartTime = Time.time;
        slider.value = 1f;
    }

    public float GetElapsedSeconds()
    {
        if (isChangingValue)
        {
            return Time.time - timerStartTime;
        }
        else
        {
            return duration;
        }
    }
}
