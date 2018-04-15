using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour {

    public GameObject enemyPrefab;
    public float spawnTime = 2f;
    public Transform[] spawnPoints;

    public Transform player;
    private int maxEnemiesOnScene = 10;

	void Start () {
        StartCoroutine(spawnEnemy());
	}

	IEnumerator spawnEnemy()
    {
        while (true)
        {
            while (GameObject.FindGameObjectsWithTag("enemy").Length < maxEnemiesOnScene)
            {
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                yield return new WaitForSeconds(spawnTime);
                Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("enemy").Length < maxEnemiesOnScene);
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
