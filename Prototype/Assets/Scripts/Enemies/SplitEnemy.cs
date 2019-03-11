using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemy : MonoBehaviour, IEnemy
{
    public bool isAttacking = false;
    public int health = 20;

    public float speed = 3f;

    public float timeBeforeAttacking = 2f;
    private float timeSinceSpawned = 0f;

    public float timeBetweenMovements = 4f;
    private float randomTimeBetweenMovements;
    public float singleEnemySpawnXOffset = 1f;

    private float damageTime = 0.3f;
    private float timeSinceHit = 0f;

    private float timeSinceLastMove = 0f;
    
    private SpriteRenderer r;

    private Vector2 target;
    private Vector2 targetOffset = new Vector2(0f, 3f);
    private GameObject player;

    private bool isMoving = false;

    private bool isFiring = false;


    private IWeapon weapon;

    public GameObject drop;


    void Start() {
        player = GameObject.Find("Player");
        r = gameObject.transform.Find("Body").GetComponent<SpriteRenderer>();
        weapon = gameObject.transform.Find("Weapon").gameObject.GetComponentInChildren<IWeapon>();
        drop = gameObject.transform.Find("Weapon").GetChild(0).gameObject;
        timeSinceLastMove = timeBetweenMovements;
    }

    public void startAttacking() {
        this.isAttacking = true;
    }

    public void OnDamage(int damage) {
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

    public void die() {
        drop.GetComponent<WingCode>().isSnapped = false;
        Instantiate(drop, new Vector2(gameObject.transform.position.x,
            gameObject.transform.position.y), Quaternion.identity);
        Destroy(gameObject);
    }

    void Update() {
        if (isAttacking) {
            timeSinceHit += Time.deltaTime;
            timeSinceLastMove += Time.deltaTime;

            if (r.color != Color.white && timeSinceHit >= damageTime) {
                r.color = Color.white;
            }

            if (isMoving || shouldMove()) {
                move();
            }
            else if (!isFiring) {
                fire();
            }
        }
        else {
            timeSinceSpawned += Time.deltaTime;
            if (timeSinceSpawned > timeBeforeAttacking) {
                isAttacking = true;
            }
        }
    }

    private bool shouldMove() {
        if (timeSinceLastMove > randomTimeBetweenMovements) {
            target = player.transform.position + (Vector3)targetOffset;
            stopFiring();
            return true;
        }
        return false;
    }

    public void move() {
        isMoving = true;
        float step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            timeSinceLastMove = 0f;
            isMoving = false;
            randomTimeBetweenMovements = Random.Range(timeBetweenMovements - 1, timeBetweenMovements + 1);
        }
    }

    public void fire() {
        if (weapon != null) {
            weapon.fire();
        }
    }

    private void stopFiring() {
        if (weapon != null) {
            weapon.stopFiring();
        }
    }

    public void setTargetOffsetX(float x) {
        targetOffset.x = x;
    }
}
