using UnityEngine;
using System.Collections;

//Justin Evnas

public class BossSpawner : MonoBehaviour
{
    public GameObject Boss;
    public GameObject[] baddies;
    public float BossSpawnsIn = 120.0f;



    void fixedupdate()
    {
        BossSpawnsIn -= Time.deltaTime;
        if (BossSpawnsIn < 0)
        {
            Spawn();
        }

    }


    void Spawn()
    {
        Instantiate(Boss);
        for (int i = 0; i < baddies.Length; i++)
        {
            Instantiate(baddies[i]);
        }
    }
}