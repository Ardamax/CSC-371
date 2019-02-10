using UnityEngine;
using System.Collections;

//Justin Evnas

public class Spawner : MonoBehaviour
{
	public float spawnTime = 5f; // we can change these as we please		
	public float spawnDelay = 3f;		
	public GameObject[] enemies;	


	void Start ()
	{
		
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}


	void Spawn ()
	{
		
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);

	}
}
