using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCannonController : MonoBehaviour, IWeapon
{
    public float spawnRate = 0.1f;
    public GameObject cannonBallPrefab;
    private GameObject parent;
    private IProjectile projectile;

    private float timeSinceLastSpawned = 0f;

    private float xOffset = 0.2f;
    private float yOffset = 0.5f;
    private bool firing = false;

    string target;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void fire()
    {
        firing = true;
    }
    public void stopFiring()
    {
        firing = false;
    }
    public
    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (firing && timeSinceLastSpawned > spawnRate)
        {
            timeSinceLastSpawned = 0f;
            GameObject leftCannonBall = (GameObject)Instantiate(cannonBallPrefab, new Vector2(gameObject.transform.position.x + xOffset,
               gameObject.transform.position.y), transform.root.rotation);
            projectile = leftCannonBall.GetComponent<IProjectile>();
            if (gameObject.transform.root.CompareTag("Player"))
                projectile.setTarget("Enemy");
            else
                projectile.setTarget("Player");

            GameObject rightCannonBall = Instantiate(cannonBallPrefab, new Vector2(gameObject.transform.position.x - xOffset,
               gameObject.transform.position.y), transform.root.rotation);
            projectile = rightCannonBall.GetComponent<IProjectile>();
            if (gameObject.transform.root.CompareTag("Player"))
                projectile.setTarget("Enemy");
            else
                projectile.setTarget("Player");
        }
    }
    public string toString()
    {
        return "DoubleCannon";
    }
}
