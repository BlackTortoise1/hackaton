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
    private int count = 0;

	void Start () {
        StartCoroutine(spawnEnemy());
	}

	IEnumerator spawnEnemy()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        while(count < maxEnemiesOnScene) { 
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            count += 1;
        }
    }

    void Update()
    {
        GameObject[] obs = GameObject.FindGameObjectsWithTag("enemy");
        foreach(GameObject ob in obs){
            ob.GetComponent<NavMeshAgent>().SetDestination(player.position);
        }
    }
}
