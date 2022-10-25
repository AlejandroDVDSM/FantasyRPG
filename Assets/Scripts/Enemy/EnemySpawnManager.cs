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
        leftRespawn = new Vector3(-65, 20, 0);
        rightRespawn = new Vector3(42, 20, 0);

        respawns[0] = leftRespawn;
        respawns[1] = rightRespawn;

        InvokeRepeating("SpawnEnemy", 1, 5);
    }

    void SpawnEnemy()
    {
        var randomEnemy = Random.Range(0, enemiesPrefab.Length);
        var randomRespawn = Random.Range(0, respawns.Length);
        Instantiate(enemiesPrefab[randomEnemy], respawns[randomRespawn], transform.rotation);
    }
}
