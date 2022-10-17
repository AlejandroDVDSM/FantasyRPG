using DefaultNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour, IHitEntities
{

    [SerializeField] private Animator animator;
    [SerializeField] private MonsterData monsterData;
    [SerializeField] private float minimunDistance; // Distance in which the monster stop following the player
    
    private GameObject player;
    private Transform playerPosition;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;

    private void Start()
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
        if (Vector2.Distance(transform.position, playerPosition.position) > minimunDistance)
        { // If the enemy is not near to the player, keep following him
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, monsterData.Speed * Time.deltaTime);
        }
        else
        { // attack code hereç
            animator.SetTrigger("Attack");

        }
    }

    private IEnumerator CooldownAttack(float secs)
    {
        yield return new WaitForSeconds(secs);
    }

    /**
     * This method is called by Animation Events
     */
    public void HitEntities()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, monsterData.AttackRange, playerLayer);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<Player>().TakeDamage(monsterData.Damage);
        } 
        
        StartCoroutine(CooldownAttack(2 * Time.deltaTime));
        
    }





    /**
     * This method will draw the gizmos of the attack in the Unity Editor
    */
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, monsterData.AttackRange);
    }
}
