using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{

    [SerializeField] private CharacterData characterData;
    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.GetString("Class").Equals(characterData.CharacterClass))
        {
            gameObject.SetActive(false);
        }
    }
}
