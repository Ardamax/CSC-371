using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Timers;

public class Wanderer : MonoBehaviour, IEnemy
{
    public float xbounds;
    private bool cannotLeft = false;
    private bool cannotRight = false;

    public bool isAttacking = false;
    public int health = 200;
    public int aimSpeed = 5;

    private SpriteRenderer r;
    private float timeSinceHit = 0f;
    private float timeSinceLastAttack = 0f;
    private float damageTime = 0.3f;

    public int fireWeaponDelay = 1000;
    private int fireWeaponCounter = 0;
    private IWeapon weapon;


    private GameObject weaponPrefab;
    private GameObject player;
    public int moveAmount = 200;
    private int moveCount = 0;
    public float speed = 6f;
    private int direction = 1;
    private Vector2 target;
    private Vector2 position;

    PlayerController p;

    void Start()
    {
        player = GameObject.Find("Player");
        p = player.GetComponentInChildren<PlayerController>();
        xbounds = p.xbounds - 2;
        Debug.Log(xbounds);
        r = gameObject.transform.Find("Body").GetComponent<SpriteRenderer>();
        weapon = gameObject.transform.Find("Body").GetComponentInChildren<IWeapon>();
        weaponPrefab = gameObject.transform.GetChild(0).GetChild(0).gameObject;
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
            weaponPrefab.SendMessage("aim", aimSpeed);
            fire();
            move();
        }
    }
    public void startAttacking()
    {
        this.isAttacking = true;
    }
    public void move()
    {
        var relativePoint = transform.InverseTransformPoint(player.transform.position);
        // going left
        if (relativePoint.x < 0.0)
        {
            if (direction > 0)
                direction *= -1;
        }
        //going right
        else
        {
            if (direction < 0)
                direction *= -1;
        }

        if (transform.position.x <= -xbounds)
            cannotLeft = true;
        else
            cannotLeft = false;
        if (transform.position.x >= xbounds)
            cannotRight = true;
        else
            cannotRight = false;

        target = new Vector2(transform.position.x + speed * direction, transform.position.y);
        float step = speed * Time.deltaTime;
        if (!cannotLeft && direction < 0 || !cannotRight && direction >=0 )
            transform.position = Vector2.MoveTowards(transform.position, target, step);


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
        Instantiate(weaponPrefab, new Vector2(gameObject.transform.position.x,
   gameObject.transform.position.y), Quaternion.identity);
        Destroy(gameObject);

    }
    public void aim()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * aimSpeed);
    }
}
