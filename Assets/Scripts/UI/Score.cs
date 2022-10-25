using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentScore = 0;
    private int record;

    public int CurrentScore { get => currentScore; }
    public int Record { get => record; }

    private void Start()
    {
        record = PlayerPrefs.GetInt("Record", 0);
    }

    public void AddPoint()
    {
        currentScore++;

        UpdateScoreText();

        if (currentScore > record)
        {
            UpdateRecord();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore;
    }

    private void UpdateRecord()
    {
        record = currentScore;
        PlayerPrefs.SetInt("Record", record);
     
    }
}
