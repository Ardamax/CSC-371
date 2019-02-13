﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCannonBallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    public float damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit player");
            other.gameObject.SendMessage("OnDamage", damage);
            Destroy(gameObject);
        }
    }
}