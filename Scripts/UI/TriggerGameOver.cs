using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{

    [SerializeField] private GameObject gameOverUI;

    public void TriggerGameOverScreen()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();

        audioManager.Stop("BattleTheme");
        audioManager.Play("GameOver");
        gameOverUI.SetActive(true);
    }
}
