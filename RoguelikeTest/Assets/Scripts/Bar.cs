using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float percentage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //checks for the percentage of the bar
        if (slider.value == percentage) return;
        if (Mathf.Abs(slider.value - percentage) < 0.01)
        {
            slider.value = percentage;
            return;
        }

        //changes size of bar to smoothly increase
        slider.value = (float)Math.Round(slider.value + (percentage - slider.value) / 10, 3);
    }

    /// <summary>
    /// Sets target percentage to be displayed by the bar.
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="percentage"></param>
    public void UpdateBar(int amount, float percentage)
    {
        this.percentage = percentage;
    }
}
