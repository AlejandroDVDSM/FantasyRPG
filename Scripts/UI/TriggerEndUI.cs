using UnityEngine;
using TMPro;

public class TriggerEndUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI uiText;


    public void TriggerUI(string text)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.Stop("BattleTheme");
        gameOverUI.SetActive(true);

        switch (text)
        {
            case "Game Over":
                uiText.text = text;
                audioManager.Play("GameOver");
                break;

            case "Winner":
                uiText.text = text;
                audioManager.Play("Winner");
                break;

            default:
                break;
        }
    }
}
