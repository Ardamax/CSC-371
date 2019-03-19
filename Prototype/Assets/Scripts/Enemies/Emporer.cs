using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Author: Larry Xu
public class Emporer : MonoBehaviour, IEnemy
{
    public bool isAttacking = false;
    public int health = 100;
    public float speed = 5f;
    private int direction = 1;

    private SpriteRenderer r;
    private float timeSinceHit = 0f;
    private float timeSinceLastAttack = 0f;
    private float damageTime = 0.3f;


    private Vector2 target;
    private Vector2 position;

    private GameObject player;

    public int fireDelay = 100;
    private int fireCooldown = 0;

    public GameObject drop;
    void Start()
    {
        player = GameObject.Find("Player");
        r = gameObject.transform.Find("MainBody").GetComponent<SpriteRenderer>();
    }

    public void startAttacking()
    {
        // Spencer
        this.isAttacking = true;
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
        GameObject newDrop = Instantiate(drop, new Vector2(gameObject.transform.position.x,
            gameObject.transform.position.y), Quaternion.identity);
        newDrop.GetComponent<WingCode>().isSnapped = false;
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
            move();
            fire();
        }
    }

    public void fire()
    {
        Transform body = transform.Find("MainBody");
        if (fireCooldown <= 0)
        {
            foreach (Transform child in body.transform)
            {
                if (child.CompareTag("Weapon"))
                {
                    child.SendMessage("fire");
                }
            }
            fireCooldown = fireDelay;
        }
        else
        {
            foreach (Transform child in body.transform)
            {
                if (child.CompareTag("Weapon"))
                    child.SendMessage("stopFiring");
            }
            fireCooldown--;
        }
    }
    public void move()
    {
    }
}

