using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacingTowardsPlayer : MonoBehaviour
{

    private GameObject player;
    private Transform playerPosition;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null && player.activeSelf)
        {
            playerPosition = player.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > playerPosition.position.x && facingRight)
        { // If the enemy is at player's right, face left
            FlipEnemy();
        } else if (transform.position.x < playerPosition.position.x && !facingRight)
        { // If the enemy is at player's left, face right
            FlipEnemy();
        }
    }

    void FlipEnemy()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
