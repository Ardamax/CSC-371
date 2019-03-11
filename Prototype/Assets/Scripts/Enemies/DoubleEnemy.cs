using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleEnemy : MonoBehaviour, IEnemy
{
    public bool isAttacking = false;
    public int health = 20;

    public float speed = 3f;

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


    private IWeapon leftWeapon;
    private IWeapon rightWeapon;

    public GameObject splitEnemyPrefab;


    void Start() {
        player = GameObject.Find("Player");
        r = gameObject.transform.Find("Body").GetComponent<SpriteRenderer>();
        leftWeapon = gameObject.transform.Find("DoubleEnemy Left Wing").gameObject.GetComponentInChildren<IWeapon>();
        rightWeapon = gameObject.transform.Find("DoubleEnemy Right Wing").gameObject.GetComponentInChildren<IWeapon>();
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
        // Instantiate new SingleEnemies
        GameObject leftSpawn = Instantiate(splitEnemyPrefab, new Vector2(gameObject.transform.position.x + singleEnemySpawnXOffset, gameObject.transform.position.y), transform.root.rotation);
        GameObject rightSpawn = Instantiate(splitEnemyPrefab, new Vector2(gameObject.transform.position.x - singleEnemySpawnXOffset, gameObject.transform.position.y), transform.root.rotation);

        leftSpawn.GetComponent<SplitEnemy>().setTargetOffsetX(1f);
        rightSpawn.GetComponent<SplitEnemy>().setTargetOffsetX(-1f);

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
        if (leftWeapon != null) {
            leftWeapon.fire();
        }
        if (rightWeapon != null) {
            rightWeapon.fire();
        }
    }

    private void stopFiring() {
        if (leftWeapon != null) {
            leftWeapon.stopFiring();
        }
        if (rightWeapon != null) {
            rightWeapon.stopFiring();
        }
    }
}
