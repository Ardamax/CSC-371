using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaHelixController : MonoBehaviour, IWeapon
{
    public float spawnRate = 0.1f;
    public GameObject plasmaBallPrefab;
    private float timeSinceLastSpawned = 0f;
    private Vector2 spawnOffset = new Vector2(0f, 0.5f);
    private bool firing = false;
    private GameObject obj;
    private IProjectile projectile;
    private Vector2 vectorToTarget;

    private GameObject player;

    public int maxDurability;
    private int durability;
    private SpriteRenderer r;
    // Start is called before the first frame update
    void Start()
    {
        maxDurability = 150;
        durability = maxDurability;
        r = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }
    //Larry Xu
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
    public string toString()
    {
        return "PlasmaHelix";
    }
    //Larry Xu
    public void aim(int aimSpeed)
    {
        vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg-90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * aimSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        //Larry Xu
        if (firing && timeSinceLastSpawned > spawnRate)
        {
            timeSinceLastSpawned = 0f;
            obj = Instantiate(plasmaBallPrefab, new Vector2(gameObject.transform.position.x + spawnOffset.x,
               gameObject.transform.position.y + spawnOffset.y), transform.rotation);
            obj.GetComponent<PlasmaMover>().setCoefficient(0.1f);
            //obj.GetComponent<PlasmaMover>().setDirection(vectorToTarget);
            projectile = obj.GetComponent<IProjectile>();
            if (gameObject.transform.root.CompareTag("Player"))
                projectile.setTarget("Enemy");
            else
                projectile.setTarget("Player");
            obj = Instantiate(plasmaBallPrefab, new Vector2(gameObject.transform.position.x + spawnOffset.x,
               gameObject.transform.position.y + spawnOffset.y), transform.rotation);
            obj.GetComponent<PlasmaMover>().setCoefficient(-0.1f);
            //obj.GetComponent<PlasmaMover>().setDirection(vectorToTarget);
            projectile = obj.GetComponent<IProjectile>();
            if (gameObject.transform.root.CompareTag("Player"))
                projectile.setTarget("Enemy");
            else
                projectile.setTarget("Player");
            degrade();
        }
    }
}
