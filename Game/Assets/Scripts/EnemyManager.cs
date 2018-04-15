using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour {

    public GameObject enemyPrefab;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    public Transform player;
    private int maxEnemiesOnScene = 10;
    private int count;

	void Start () {
        count = 0;
        InvokeRepeating("spawnEnemy", spawnTime, spawnTime);
	}

	void spawnEnemy()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        if (count < 10)
            Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        else
            CancelInvoke();
        count += 1;
    }

    void Update()
    {
        GameObject[] obs = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject ob in obs){
            ob.GetComponent<NavMeshAgent>().SetDestination(player.position);
        }
    }
}
