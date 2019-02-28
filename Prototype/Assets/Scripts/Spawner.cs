using UnityEngine;
using System.Collections;

//Justin Evnas

public class Spawner : MonoBehaviour
{
	public float spawnTime = 5f; // we can change these as we please		
	public float spawnDelay = 3f;		
	public GameObject[] enemies;

    public GameObject Boss;
    public GameObject[] baddies;
    public float BossSpawnsIn = 120.0f;
    bool BossSpawned = false;




    void Start ()
	{
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}


    void FixedUpdate()
    {
        BossSpawnsIn -= Time.deltaTime;
        if (BossSpawnsIn <0 )
        {if (BossSpawned== false)
            {
                BossSpawn();
                BossSpawned = true;

            }
        }

    }


    void Spawn ()
	{
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex]);
	}


    void BossSpawn()
    {
        int i = 0;
        Instantiate(Boss);
        while(i< baddies.Length)
        {
            Instantiate(baddies[i]);
            i++;
        }
    }
}
