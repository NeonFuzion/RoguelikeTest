using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Experience : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] UnityEvent onLevelUp;
    [SerializeField] UnityEvent<int, float> onExperienceGained;

    int value, maxValue;

    // Start is called before the first frame update
    void Start()
    {
        value = 0;
        maxValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExperience(int exp)
    {
        value += exp;
        if (value >= maxValue)
        {
            int excess = value - maxValue;
            levelText.text = int.Parse(levelText.text) + 1 + "";
            maxValue = (int)(maxValue * 1.1f);
            value = 0;
            onLevelUp.Invoke();
            AddExperience(excess);
        }
        else
        {
            onExperienceGained.Invoke(exp, (float)value / maxValue);
        }
    }
}
