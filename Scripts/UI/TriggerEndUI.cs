using UnityEngine;
using System.Collections;
using TMPro;

public class TriggerEndUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI uiText;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void TriggerWin()
    {
        audioManager.Stop("BattleTheme");
        gameOverUI.SetActive(true);

        uiText.text = "You win!";
        audioManager.Play("Winner");
        //Time.timeScale = 0;
    }

    public void TriggerLoose()
    {
        audioManager.Stop("BattleTheme");
        gameOverUI.SetActive(true);

        uiText.text = "GameOver";
        audioManager.Play("GameOver");
        //Time.timeScale = 0;
    }

}
