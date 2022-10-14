using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private CharacterData characterData;
    [SerializeField] private float minimunDistance;
    private Vector2 targetPosition;
    
    private GameObject player;
    private Transform playerPosition;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerPosition = player.transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector2(playerPosition.position.x, transform.position.y);
        
        if (Vector2.Distance(transform.position, targetPosition) > minimunDistance)
        { // If the enemy is not near to the player, keep following him
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, characterData.Speed * Time.deltaTime);
        }
        else
        { // attack code here
            //animator.SetTrigger("Attack1");
        }
    }
}
