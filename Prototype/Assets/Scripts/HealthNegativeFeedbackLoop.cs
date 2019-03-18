using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class HealthNegativeFeedbackLoop : MonoBehaviour
{
    public GameObject healthWeaponPrefab;
    public float healthRatioThreshold = 0.25f;
    public float spawnRate = 15f;
    private PlayerHealth health;
    private float timeSinceLastSpawned = 0f;

    void Start() {
        GameObject player = GameObject.Find("Player");
        if (player != null) {
            health = player.GetComponent<PlayerHealth>();
        }
    }

    void Update() {
        timeSinceLastSpawned += Time.deltaTime;
        if (health == null) {
            GameObject player = GameObject.Find("Player");
            if (player != null) {
                health = player.GetComponent<PlayerHealth>();
            }
        }
        else {
            float currentHealth = health.health;
            float maxHealth = health.initialHealth;

            if (currentHealth / maxHealth < healthRatioThreshold &&
                    timeSinceLastSpawned > spawnRate) {
                float spawnX = Random.Range(-12f, 12f);
                float spawnY = 11f;

                Instantiate(healthWeaponPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);
                timeSinceLastSpawned = 0f;
            }
        }
    }
}
