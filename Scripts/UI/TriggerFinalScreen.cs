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
        StartCoroutine(PauseGame());
    }

    public void TriggerLoose()
    {
        audioManager.Stop("BattleTheme");
        finalScreenUI.SetActive(true);

        uiText.text = "Game Over";
        audioManager.Play("GameOver");
        StartCoroutine(PauseGame());
    }

    private IEnumerator PauseGame()
    {
        yield return new WaitForSeconds(1);

        Time.timeScale = 0;
    }

}
