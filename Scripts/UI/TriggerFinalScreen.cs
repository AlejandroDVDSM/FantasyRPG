using UnityEngine;
using System.Collections;
using TMPro;

public class TriggerFinalScreen : MonoBehaviour
{
    [SerializeField] private GameObject finalScreenUI;
    [SerializeField] private TextMeshProUGUI uiText;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void TriggerWin()
    {
        audioManager.Stop("BattleTheme");
        finalScreenUI.SetActive(true);

        uiText.text = "You win!";
        audioManager.Play("Winner");
        //Time.timeScale = 0;
    }

    public void TriggerLoose()
    {
        audioManager.Stop("BattleTheme");
        finalScreenUI.SetActive(true);

        uiText.text = "GameOver";
        audioManager.Play("GameOver");
        //Time.timeScale = 0;
    }

}
