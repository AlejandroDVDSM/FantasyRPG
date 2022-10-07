using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterClassText, healthText, speedText, damageText;
    [SerializeField] private Button playButton;

    void Start()
    {
        healthText.enabled = false;
        speedText.enabled = false;
        damageText.enabled = false;
        playButton.gameObject.SetActive(false);
    }

    public void setText(string characterClassText, string healthText, string speedText, string damageText)
    {
        this.characterClassText.text = characterClassText;
        this.healthText.text = healthText;
        this.speedText.text = speedText;
        this.damageText.text = damageText;

        enableText();
    }

    void enableText()
    {
        healthText.enabled = true;
        speedText.enabled = true;
        damageText.enabled = true;
        playButton.gameObject.SetActive(true);
    }
}
