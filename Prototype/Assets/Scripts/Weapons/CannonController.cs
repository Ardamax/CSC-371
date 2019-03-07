using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour, IWeapon
{
    public float spawnRate = 0.1f;
    public GameObject cannonBallPrefab;
    private float timeSinceLastSpawned = 0f;
    private Vector2 spawnOffset = new Vector2(0f, 0.5f);
    private bool firing = false;
    private IProjectile projectile;

    public int maxDurability;
    private int durability;
    private SpriteRenderer r;

    void Start()
    {
        maxDurability = 200;
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
            timeSinceLastSpawned = 0f;
            GameObject cannonBall = (GameObject)Instantiate(cannonBallPrefab, new Vector2(gameObject.transform.position.x,
   gameObject.transform.position.y), transform.root.rotation);
            projectile = cannonBall.GetComponent<IProjectile>();
            if (gameObject.transform.root.CompareTag("Player"))
                projectile.setTarget("Enemy");
            else
                projectile.setTarget("Player");
            degrade();
        }
    }
    public string toString()
    {
        return "Cannon";
    }
}
