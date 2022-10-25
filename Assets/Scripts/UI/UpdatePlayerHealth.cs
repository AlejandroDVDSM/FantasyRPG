using UnityEngine;
using TMPro;

public class UpdatePlayerHealth : MonoBehaviour
{

    private GameObject player;
    private Player playerScript;
    private int currentHealth;
    [SerializeField] private TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null && player.activeSelf)
        {
            playerScript = player.GetComponent<Player>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        currentHealth = playerScript.CurrentHealth;
        healthText.text = currentHealth.ToString();
    }
}
