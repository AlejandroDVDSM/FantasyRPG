using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class TriggerFinalScreen : MonoBehaviour
{
    [SerializeField] private GameObject finalScreenUI;
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private Image panelImage;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void TriggerWin()
    {
        audioManager.Stop("BattleTheme");
        finalScreenUI.SetActive(true);
        panelImage.color = new Color(0.22f, 0.424f, 0.09f, .75f); // Hex: 386C17

        uiText.text = "You win!";
        audioManager.Play("Winner");
        StartCoroutine(PauseGame());
    }

    public void TriggerLoose()
    {
        audioManager.Stop("BattleTheme");
        finalScreenUI.SetActive(true);
        panelImage.color = new Color(.725f, .239f, .118f, .75f); // Hex: B93D1E

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
