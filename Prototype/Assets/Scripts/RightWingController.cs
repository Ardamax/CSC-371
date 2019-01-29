﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWingController : MonoBehaviour
{
    public float spawnRate = 0.1f;
    IWeapon weapon;
    private KeyCode key;
    private float timeSinceLastSpawned = 0f;
    private Vector2 spawnOffset = new Vector2(0f, 0.5f);

    void Start()
    {
        weapon = gameObject.GetComponentInChildren<IWeapon>();
        if (gameObject.CompareTag("Right Wing"))
        {
            key = KeyCode.E;
        }
        else
        {
            // idk
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (Input.GetKey(key))
            weapon.fire();
        else
            weapon.stopFiring();
    }
}
