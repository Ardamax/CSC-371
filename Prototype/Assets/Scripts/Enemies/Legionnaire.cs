using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legionnaire : MonoBehaviour, IEnemy
{
    public bool isAttacking = false;
    public int health = 10;

    private SpriteRenderer r;
    private float timeSinceHit = 0f;
    private float timeSinceLastAttack = 0f;
    private float damageTime = 0.3f;

    public float speed = 2.0f;
    private Vector2 target;
    private Vector2 position;

    public int damage = 10;

    private GameObject player;

    private IWeapon weapon;
    public GameObject drop;

    int sequence = 1;
    bool deploy = false;

    void Start()
    {
        player = GameObject.Find("Player");
        r = gameObject.transform.Find("Body").GetComponent<SpriteRenderer>();
        weapon = gameObject.transform.Find("Body").gameObject.GetComponentInChildren<IWeapon>();
        drop = gameObject.transform.Find("Body").GetChild(0).gameObject;
    }

    public void startAttacking()
    {
        this.isAttacking = true;
    }

    public void OnDamage(int damage)
    {
        if (isAttacking) {
            health = health - damage;
            r.color = Color.black;
            timeSinceHit = 0f;

            //deploy shield if it hasn't been deployed yet
            if (weapon != null)
            {
                deploy = true;
                drop.GetComponent<WingCode>().isSnapped = false;
            }

            if (health <= 0)
            {
                die();
            }
        }
    }
    public void die() { Destroy(gameObject); }
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
        }
        if (deploy)
            fire();
    }
    
    
    public void fire()
    {
        switch (sequence)
        {
            case 1:
                weapon.fire();
                break;
            case 2:
                GameObject shield = GameObject.Find("DeployableShieldShooter");
                drop.transform.rotation = Quaternion.identity;
                drop.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                drop.transform.parent = null;
                break;
            case 3:
                weapon.stopFiring();
                weapon = null;
                break;
            default:
                deploy = false;
                break;
        }
        sequence++;
    }

    public void move()
    {
        float s = speed / 3;
        if (weapon == null)
            s = speed;
        
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

        target = new Vector2(player.transform.position.x, player.transform.position.y);
        float step = s * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.gameObject.transform.SendMessageUpwards("OnDamage", damage, SendMessageOptions.RequireReceiver);
            Destroy(gameObject);
        }
    }
}
