using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TriggerPauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private TextMeshProUGUI recordText;
    [SerializeField] private Button resume;

    private bool isPaused = false;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void TriggerPause()
    {
        audioManager.Stop("BattleTheme");
        pauseScreen.SetActive(true);
        pauseText.text = "Pause";
        recordText.text = "Record: " + FindObjectOfType<Score>().Record;

        Time.timeScale = 0;
    }

    public void Resume()
    {
        audioManager.Play("BattleTheme");
        pauseScreen.SetActive(false);

        Time.timeScale = 1;
        isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            isPaused = true;
            TriggerPause();
        }
    }
}
