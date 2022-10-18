using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeValue = 120; // 120 secs = 2 min.
    [SerializeField] private TextMeshProUGUI timerText;

    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        } else
        {
            timeValue = 0;

            GameObject.Find("GameOverManager").GetComponent<TriggerGameOver>().TriggerGameOverScreen();
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
