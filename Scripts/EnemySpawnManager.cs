using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] enemiesPrefab;
    private Vector3 respawnPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", 1, 3);
    }

    void spawnEnemy()
    {
        respawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        Instantiate(enemiesPrefab[Random.Range(0, 4)], respawnPos, transform.rotation);
    }
}
