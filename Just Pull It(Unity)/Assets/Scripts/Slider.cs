using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueChanger : MonoBehaviour
{
    public Slider slider;
    public float duration = 5f;

    private float currentValue;
    private float targetValue;
    private float timer;

    void Start()
    {
        // Set initial values
        currentValue = 12f;
        targetValue = 0f;
        timer = 0f;
    }

    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Calculate new value based on current time
        float newValue = Mathf.Lerp(currentValue, targetValue, timer / duration);

        // Update slider value
        slider.value = newValue;

        // Check if duration has elapsed
        if (timer >= duration)
        {
            // Reset timer and current value
            timer = 0f;
            currentValue = newValue;
        }
    }
}

