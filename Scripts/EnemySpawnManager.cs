using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] enemiesPrefab;

    private Vector3 leftRespawn;
    private Vector3 rightRespawn;

    private Vector3[] respawns = new Vector3[2];

    // Start is called before the first frame update
    void Start()
    {
        leftRespawn = new Vector3(-55, 15, 0);
        rightRespawn = new Vector3(30, 15, 0);

        respawns[0] = leftRespawn;
        respawns[1] = rightRespawn;

        InvokeRepeating("SpawnEnemy", 1, 5);
    }

    void SpawnEnemy()
    {
        Instantiate(enemiesPrefab[Random.Range(0, 4)], respawns[Random.Range(0, respawns.Length)], transform.rotation);
    }
}
