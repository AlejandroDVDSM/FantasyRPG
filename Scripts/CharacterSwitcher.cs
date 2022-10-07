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
        menuTextManager.GetComponent<MenuUIManager>().setText(characterData.CharacterClass, characterData.Health.ToString(), characterData.Speed.ToString(), characterData.Damage.ToString());

        // Mejorar en el futuro este cacho de código - Esto se encarga de reproducir una animación distinta cuando se pincha encima
        /*if (characterData.CharacterClass == "Hero Knight")
        {
            animator.Play("HeroKnight_Attack1");
        } else if (characterData.CharacterClass == "Wizard")
        {
            animator.Play("Wizard_Attack1");
        } */

        PlayerPrefs.SetString("Class", characterData.CharacterClass);
    }
}
