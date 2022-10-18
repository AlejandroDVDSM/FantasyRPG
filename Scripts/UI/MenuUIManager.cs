using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterClassText, healthText, speedText, damageText;
    [SerializeField] private Button playButton;
    [SerializeField] private Image heartIcon, speedIcon, swordIcon;

    void Start()
    {
        healthText.enabled = false;
        speedText.enabled = false;
        damageText.enabled = false;

        playButton.gameObject.SetActive(false);

        heartIcon.enabled = false;
        speedIcon.enabled = false;
        swordIcon.enabled = false;
    }

    public void SetText(string characterClassText, string healthText, string speedText, string damageText)
    {
        this.characterClassText.text = characterClassText;
        this.healthText.text = healthText;
        this.speedText.text = speedText;
        this.damageText.text = damageText;

        EnableText();
    }

    void EnableText()
    {
        healthText.enabled = true;
        speedText.enabled = true;
        damageText.enabled = true;
        
        playButton.gameObject.SetActive(true);
        
        heartIcon.enabled = true;
        speedIcon.enabled = true;
        swordIcon.enabled = true;
    }
}
