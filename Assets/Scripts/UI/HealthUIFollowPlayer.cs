using UnityEngine;
using TMPro;

public class HealthUIFollowPlayer : MonoBehaviour
{
    private GameObject player;
    private Transform target;

    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null && player.activeSelf)
        {
            target = player.transform;
        }
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;


    }
}
