using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour, IEnemy
{
    public bool isAttacking = false;
    public int health = 10;

    private SpriteRenderer r;
    private float timeSinceHit = 0f;
    private float timeSinceLastAttack = 0f;
    private float damageTime = 0.3f;

    private float speed = 2.0f;
    private Vector2 target;
    private Vector2 position;

    private GameObject player;

    void Start() {
        player = GameObject.Find("Player");
        r = gameObject.transform.Find("Body").GetComponent<SpriteRenderer>();
    }

    void OnDamage(int damage)
    {
        health = health - damage;
        r.color = Color.black;
        timeSinceHit = 0f;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
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

    public void fire() {
        
    }
    public void move()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

        target = new Vector2(player.transform.position.x, player.transform.position.y);
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
}
