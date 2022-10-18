using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{

    [SerializeField] private GameObject gameOverUI;

    public void TriggerGameOverScreen()
    {
        gameOverUI.SetActive(true);
    }
}
