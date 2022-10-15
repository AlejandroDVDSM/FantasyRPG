using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadScene(string name) 
    {
        FindObjectOfType<AudioManager>().Play("Play");
        FindObjectOfType<AudioManager>().Stop("MainTheme");
        FindObjectOfType<AudioManager>().Play("BattleTheme");
        SceneManager.LoadScene(name);
        
    }

}
