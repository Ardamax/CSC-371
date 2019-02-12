using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public bool isAttacking = false;
    public GameObject fireBallPrefab;
    public float attackFrequency = 3f;
    public float damageTime = 0.3f;
    public int health = 25;
    private SpriteRenderer r;
    private float timeSinceLastAttack = 0f;
    private float timeSinceHit = 0f;

    void Start() {
        r = GetComponent<SpriteRenderer>();
    }

    void OnDamage(int damage) {
        health = health - damage;
        r.color = Color.red;
        timeSinceHit = 0f;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    void Update() {
        timeSinceHit += Time.deltaTime;
        timeSinceLastAttack += Time.deltaTime;

        if (r.color != Color.white && timeSinceHit >= damageTime) {
           r.color = Color.white;
        }

        if (isAttacking == true && timeSinceLastAttack >= attackFrequency) {
            timeSinceLastAttack = 0f;
            Instantiate(fireBallPrefab, transform.position, Quaternion.identity);
        }
    }

    void Attacking() {
        isAttacking = true;
    }
}
