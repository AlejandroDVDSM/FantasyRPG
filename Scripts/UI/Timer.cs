using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeValue = 120; // 120 secs = 2 min.
    //private float timeValue = 2; // Test line

    [SerializeField] private TextMeshProUGUI timerText;

    private Player player;
    private int playerHealth;
    private bool looseHasBeenTrigger = false;

    private TriggerFinalScreen finalScreenManager;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        finalScreenManager = GameObject.Find("FinalScreenManager").GetComponent<TriggerFinalScreen>();
    }

    public float TimeValue { get => timeValue; }

    private void Update()
    {
        playerHealth = player.CurrentHealth;

        if (timeValue > 0 && playerHealth > 0)
        {
            timeValue -= Time.deltaTime;
        } else if (timeValue < 0 && playerHealth > 0)
        {
            timeValue = 0;
            finalScreenManager.TriggerEnd("Win");
        } else if (playerHealth <= 0 && !looseHasBeenTrigger)
        {
            looseHasBeenTrigger = true;
            finalScreenManager.TriggerEnd("Lose");
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
