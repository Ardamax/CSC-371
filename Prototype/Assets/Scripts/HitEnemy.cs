using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    public float damage = 1;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            other.gameObject.SendMessage("OnDamage", damage);
            Destroy(gameObject);
        }
    }
}
