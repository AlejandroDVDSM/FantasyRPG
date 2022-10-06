using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterClassText, healthText, speedText, damageText;

    void Start()
    {
        healthText.enabled = false;
        speedText.enabled = false;
        damageText.enabled = false;
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
    }
}
