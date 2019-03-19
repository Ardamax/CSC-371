using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Larry Xu
public class BoatCarrier : MonoBehaviour, IEnemy
{
    public bool isAttacking = false;
    public int health = 200;
    public int aimSpeed = 5;
    private string sceneName;

    private SpriteRenderer r;
    private float timeSinceHit = 0f;
    private float timeSinceLastAttack = 0f;
    private float timeSinceBoatSpawn = 0f;
    private float damageTime = 0.3f;

    public float boatSpawnDelay = 2f;
    public float firingInterval = 1f;
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
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void startAttacking() {
        // Spencer
        this.isAttacking = true;
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
        if (timeSinceLastAttack >= firingInterval)
        {
            timeSinceLastAttack = 0;
            weapon.fire();
        }
        else
        {
            weapon.stopFiring();
        }
        if (timeSinceBoatSpawn >= boatSpawnDelay)
        {
            timeSinceBoatSpawn = 0;
            Instantiate(boat, new Vector2(gameObject.transform.position.x,
   gameObject.transform.position.y), Quaternion.identity);
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

    public void die() {
        GameObject newDrop = Instantiate(weaponPrefab, new Vector2(gameObject.transform.position.x,
   gameObject.transform.position.y), Quaternion.identity);
        newDrop.GetComponent<WingCode>().isSnapped = false;
        Destroy(gameObject);
    }


    void Update()
    {
        if (isAttacking) {
            float deltaTime = Time.deltaTime;
            timeSinceHit += deltaTime;
            timeSinceLastAttack += deltaTime;
            timeSinceBoatSpawn += deltaTime;

            if (r.color != Color.white && timeSinceHit >= damageTime)
            {
                r.color = Color.white;
            }
            weaponPrefab.SendMessage("aim", aimSpeed);
            fire();
            move();
        }
    }
    public void aim()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * aimSpeed);
    }
}
