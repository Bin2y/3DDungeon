using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float maxValue;
    public float curValue;
    public float startValue;
    public Image uibar;

    private void Start()
    {
        curValue = startValue;
    }
    private void Update()
    {
        uibar.fillAmount = GetPercentage();
    }

    private float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Add(float amount)
    {
        curValue = Mathf.Max(curValue + amount, maxValue);
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }
}