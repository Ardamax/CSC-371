﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWingController : MonoBehaviour
{
    IWeapon weapon;
    private KeyCode key;
    private float timeSinceLastSpawned = 0f;
    private Vector2 spawnOffset = new Vector2(0f, 0.5f);

    void Start() {
        weapon = gameObject.GetComponentInChildren<IWeapon>();
        if (gameObject.CompareTag("Left Wing")) {
            key = KeyCode.Q;
        }
        else {
            // idk
        }
    }

    void Update() {
        timeSinceLastSpawned += Time.deltaTime;
        if (Input.GetKey(key))
            weapon.fire();
        else
            weapon.stopFiring();
    }
}
