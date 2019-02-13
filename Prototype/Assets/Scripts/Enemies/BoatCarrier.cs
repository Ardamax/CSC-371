using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCarrier : MonoBehaviour, IEnemy
{
    public bool isAttacking = false;
    public int health = 100;
    public int aimSpeed = 5;

    private SpriteRenderer r;
    private float timeSinceHit = 0f;
    private float timeSinceLastAttack = 0f;
    private float damageTime = 0.3f;

    public int boatSpawnDelay = 5000;
    private int boatSpawnCounter = 0;
    public int fireWeaponDelay = 1000;
    private int fireWeaponCounter = 0;
    private IWeapon weapon;


    private GameObject weaponPrefab;
    public GameObject boat;
    private GameObject player;
    public int moveAmount = 200;
    private int moveCount = 0;
    public float speed = 1.5f;
    private int direction = 1;
    private Vector2 target;
    private Vector2 position;
    void Start()
    {
        player = GameObject.Find("Player");
        r = gameObject.transform.Find("Body").GetComponent<SpriteRenderer>();
        weapon = gameObject.GetComponentInChildren<IWeapon>();
        weaponPrefab = gameObject.transform.GetChild(0).GetChild(0).gameObject;
    }
    public void move()
    {
        if (moveCount > moveAmount)
        {

            direction *= -1;
            moveCount = 0;
            return;
        }
        target = new Vector2(transform.position.x + speed * direction, transform.position.y);
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        moveCount++;
    }
    public void fire()
    {
        if (fireWeaponCounter >= fireWeaponDelay)
        {
            fireWeaponCounter = 0;
            weapon.fire();
        }
        else
        {
            weapon.stopFiring();
            fireWeaponCounter++;
        }
        if (boatSpawnCounter >= boatSpawnDelay)
        {
            boatSpawnCounter = 0;
            Instantiate(boat, new Vector2(gameObject.transform.position.x,
   gameObject.transform.position.y), Quaternion.identity);
        }
        else
            boatSpawnCounter++;
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
    public void die() {
        Instantiate(weaponPrefab, new Vector2(gameObject.transform.position.x,
   gameObject.transform.position.y), Quaternion.identity);
        Destroy(gameObject);
    }
    void Update()
    {
        timeSinceHit += Time.deltaTime;
        timeSinceLastAttack += Time.deltaTime;

        if (r.color != Color.white && timeSinceHit >= damageTime)
        {
            r.color = Color.white;
        }
        weaponPrefab.SendMessage("aim", aimSpeed);
        fire();
        move();

    }
    public void aim()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * aimSpeed);
    }
}
