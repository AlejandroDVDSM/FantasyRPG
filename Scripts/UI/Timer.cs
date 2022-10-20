using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeValue = 61; // 120 secs = 2 min.
    [SerializeField] private TextMeshProUGUI timerText;

    private GameObject player;
    private int playerHealth;
    private bool looseHasBeenTrigger = false;

    private GameObject finalUIManager;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        finalUIManager = GameObject.Find("FinalUIManager");
    }

    public float TimeValue { get => timeValue; }

    private void Update()
    {
        playerHealth = player.GetComponent<Player>().CurrentHealth;

        if (timeValue > 0 && playerHealth > 0)
        {
            timeValue -= Time.deltaTime;
        } else if (timeValue < 0 && playerHealth > 0)
        {
            timeValue = 0;
            finalUIManager.GetComponent<TriggerEndUI>().TriggerWin();
        } else if (playerHealth <= 0 && !looseHasBeenTrigger)
        {
            looseHasBeenTrigger = true;
            finalUIManager.GetComponent<TriggerEndUI>().TriggerLoose();
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
