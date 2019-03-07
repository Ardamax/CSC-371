using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hunter : MonoBehaviour, IEnemy
{
    public bool isAttacking = false;
    public int health = 100;
    private string sceneName;

    private SpriteRenderer r;
    private float timeSinceHit = 0f;
    private float timeSinceLastAttack = 0f;
    private float damageTime = 0.3f;


    private IWeapon leftWeapon;
    private IWeapon rightWeapon;

    public int fireDelay = 100;
    private int fireCooldown = 0;

    public GameObject drop;

    private GameObject player;
    private int moveCount = 0;
    public float speed = 1.5f;
    private int direction = 1;
    private Vector2 target;
    private Vector2 position;
    void Start()
    {
        player = GameObject.Find("Player");
        r = gameObject.transform.Find("Body").GetComponent<SpriteRenderer>();
        leftWeapon = gameObject.transform.Find("Left Wing").gameObject.GetComponentInChildren<IWeapon>();
        rightWeapon = gameObject.transform.Find("Right Wing").gameObject.GetComponentInChildren<IWeapon>();
        drop = gameObject.transform.Find("Left Wing").GetChild(0).gameObject;
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void startAttacking()
    {
        // Spencer
        this.isAttacking = true;
    }

    public void move()
    {
        target = new Vector2(player.transform.position.x, transform.position.y);
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
    public void fire()
    {
        if (fireCooldown <= 0)
        {
            if (leftWeapon != null)
                leftWeapon.fire();
            if (rightWeapon != null)
                rightWeapon.fire();
            fireCooldown = fireDelay;
        }
        else
        {
            leftWeapon.stopFiring();
            rightWeapon.stopFiring();
            fireCooldown--;
        }

    }
    public void OnDamage(int damage)
    {
        health = health - damage;
        r.color = Color.red;
        timeSinceHit = 0f;

        if (health <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Instantiate(drop, new Vector2(gameObject.transform.position.x,
   gameObject.transform.position.y), Quaternion.identity);
        Destroy(gameObject);

    }


    void Update()
    {
        if (isAttacking)
        {
            timeSinceHit += Time.deltaTime;
            timeSinceLastAttack += Time.deltaTime;

            if (r.color != Color.white && timeSinceHit >= damageTime)
            {
                r.color = Color.white;
            }
            fire();
            move();
        }
    }
}

