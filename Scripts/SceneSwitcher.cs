using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }


    public void LoadScene(string scene) 
    {
        SceneManager.LoadScene(scene);
    }

    /**
     * This method start playing the song of the scene that is going to be loaded
     */
    public void initSong(string song)
    {
        audioManager.Play("Play");

        switch(song)
        {
            case "MainTheme":
                audioManager.Stop("BattleTheme");
                break;

            case "BattleTheme":
                audioManager.Stop("MainTheme");
                break;

            default:
                break;
        }

        audioManager.Play(song);
    }
}
