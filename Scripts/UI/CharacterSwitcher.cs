using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;
    [SerializeField] private GameObject menuTextManager;
    private AudioManager audioManager;

    public Animator animator;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnMouseDown()
    {
        menuTextManager.GetComponent<MenuUIManager>().SetText(characterData.CharacterClass, characterData.Health.ToString(), characterData.Speed.ToString(), characterData.Damage.ToString());
        audioManager.Play("Click");
        PlayerPrefs.SetString("Class", characterData.CharacterClass);
    }
}
