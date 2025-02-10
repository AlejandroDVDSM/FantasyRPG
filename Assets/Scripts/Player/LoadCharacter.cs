using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private Player heroKnight;
    [SerializeField] private Player wizard;
    
    void Awake()
    {
        Debug.Log($"Class: {PlayerPrefs.GetString("Class")}");

        switch (PlayerPrefs.GetString("Class"))
        {
            case "Wizard":
                Instantiate(wizard, playerSpawn);
                break;
            case "Hero Knight":
                Instantiate(heroKnight, playerSpawn);
                break;
        }
    }
}
