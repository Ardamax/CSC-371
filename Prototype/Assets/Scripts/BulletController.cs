using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float spawnRate = 0.1f;
    public GameObject bulletPrefab;
    private KeyCode key;
    private float timeSinceLastSpawned = 0f;
    private Vector2 spawnOffset = new Vector2(0f, 0.5f);

    void Start() {
        if (gameObject.CompareTag("Left Wing")) {
            key = KeyCode.Q;
        }
        else if (gameObject.CompareTag("Right Wing")) {
            key = KeyCode.E;
        }
        else {
            // idk
        }
    }

    void Update() {
        timeSinceLastSpawned += Time.deltaTime;
        if (Input.GetKey(key) && timeSinceLastSpawned > spawnRate) {
            timeSinceLastSpawned = 0f;
            Instantiate(bulletPrefab, new Vector2(gameObject.transform.position.x + spawnOffset.x, gameObject.transform.position.y + spawnOffset.y), Quaternion.identity); 
        }
    }
}
