using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{

    [SerializeField] private CharacterData characterData;
    
    void Awake()
    {
        if (!PlayerPrefs.GetString("Class").Equals(characterData.CharacterClass))
        {
            gameObject.SetActive(false);
        }
    }
}
