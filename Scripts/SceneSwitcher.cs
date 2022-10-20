using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    private AudioManager audioManager;
    
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void LoadScene(string scene) 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }

    public void LoadSameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
