using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    private AudioManager audioManager;
    private float timeScale;
    private float fixedDeltaTime;
    
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        fixedDeltaTime = Time.fixedDeltaTime;
        timeScale = Time.timeScale;
    }

    public void LoadScene(string scene) 
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadSameScene()
    {
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
