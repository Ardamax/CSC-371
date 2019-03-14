using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battleship : MonoBehaviour, IEnemy
{
    public bool isAttacking = false;
    public int health = 20;
    public int moveAmount = 250;
    private int moveCount = 0;
    public float speed = 1.5f;
    private int direction = 1;

    private SpriteRenderer r;
    private float timeSinceHit = 0f;
    private float timeSinceLastAttack = 0f;
    private float damageTime = 0.3f;


    private Vector2 target;
    private Vector2 position;

    private GameObject player;

    private IWeapon leftWeapon;
    private IWeapon rightWeapon;

    public int fireDelay = 100;
    private int fireCooldown = 0;

    public GameObject drop;
    void Start()
    {
        player = GameObject.Find("Player");
        r = gameObject.transform.Find("Body").GetComponent<SpriteRenderer>();
        leftWeapon = gameObject.transform.Find("Battleship Left Wing").gameObject.GetComponentInChildren<IWeapon>();
        rightWeapon = gameObject.transform.Find("Battleship Right Wing").gameObject.GetComponentInChildren<IWeapon>();
        if (drop == null) {
            drop = gameObject.transform.Find("Battleship Left Wing").GetChild(0).gameObject;
        }
    }

    public void startAttacking() {
        // Spencer
        this.isAttacking = true;
    }

    public void OnDamage(int damage)
    {
        if (isAttacking) {
            health = health - damage;
            r.color = Color.red;
            timeSinceHit = 0f;

            if (health <= 0)
            {
                die();
            }
        }        
    }
    public void die()
    {
        drop.GetComponent<WingCode>().isSnapped = false;
        Instantiate(drop, new Vector2(gameObject.transform.position.x,
            gameObject.transform.position.y), Quaternion.identity);
        Destroy(gameObject);
    }
    void Update()
    {
        if (isAttacking) {
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
    public void move()
    {
        if (moveCount > moveAmount)
        {
            
            direction *= -1;
            moveCount = 0;
            return;
        }
        target = new Vector2(transform.position.x + speed*direction, transform.position.y);
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        moveCount++;
    }
}
