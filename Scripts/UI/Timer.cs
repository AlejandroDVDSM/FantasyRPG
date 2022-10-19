using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeValue = 120; // 120 secs = 2 min.
    [SerializeField] private TextMeshProUGUI timerText;

    public float TimeValue { get => timeValue; }


    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        } else
        {
            timeValue = 0;

            GameObject.Find("FinalUIManager").GetComponent<TriggerEndUI>().TriggerUI("Game Over");
            GameObject.FindWithTag("Player").GetComponent<Player>().DisablePlayer();
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
