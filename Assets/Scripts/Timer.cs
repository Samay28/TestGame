using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public float totalTime = 20f;
    public float timer;
    public TMP_Text timerText;
    void Start()
    {
        timer = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            UpdateDisplay();
        }
        else
        {
            timer = 0;
        }
    }

    void UpdateDisplay()
    {
        timerText.text = "Time: "+ Mathf.CeilToInt(timer).ToString();
    }
}
