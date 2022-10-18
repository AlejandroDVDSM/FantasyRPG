using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;
    [SerializeField] private GameObject menuTextManager;
    public Animator animator;

    private void OnMouseDown()
    {
        menuTextManager.GetComponent<MenuUIManager>().SetText(characterData.CharacterClass, characterData.Health.ToString(), characterData.Speed.ToString(), characterData.Damage.ToString());
        FindObjectOfType<AudioManager>().Play("Click");
        PlayerPrefs.SetString("Class", characterData.CharacterClass);
    }
}
