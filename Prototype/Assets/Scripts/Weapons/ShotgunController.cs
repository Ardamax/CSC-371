using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : MonoBehaviour, IWeapon
{
    public float spawnRate = 1f;
    public float spreadDegrees = 30f;
    public int shotsPerFire = 5;
    public GameObject shotPrefab;
    private float timeSinceLastSpawned = 0f;
    private Vector2 spawnOffset = new Vector2(0f, 0.5f);
    private bool firing = false;
    private IProjectile projectile;

    public int maxDurability;
    private int durability;
    private SpriteRenderer r;

    void Start()
    {
        maxDurability = 100;
        durability = maxDurability;
        r = GetComponent<SpriteRenderer>();
    }
    public void degrade()
    {
        durability--;
        if (durability <= maxDurability / 4)
            r.color = Color.red;
        if (durability < 1)
            Destroy(gameObject);
    }
    public void fire()
    {
        firing = true;
    }
    public void stopFiring()
    {
        firing = false;
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (firing && timeSinceLastSpawned > spawnRate)
        {
            fireShots();
            degrade();
        }
    }

    private void fireShots() {
        timeSinceLastSpawned = 0f;

        GameObject obj;

        for (int i = 0; i < shotsPerFire; i++) {
            float angle = (spreadDegrees / 2f) - (i * (spreadDegrees / (shotsPerFire - 1)));

            obj = Instantiate(shotPrefab, gameObject.transform.position, transform.root.rotation * Quaternion.Euler(0, 0, angle));
            projectile = obj.GetComponent<IProjectile>();
            if (gameObject.transform.root.CompareTag("Player"))
                projectile.setTarget("Enemy");
            else
                projectile.setTarget("Player");
        }
    }

    public string toString()
    {
        return "Shotgun";
    }
}
