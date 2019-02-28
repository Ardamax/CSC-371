using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class DeployableShieldShooterController : MonoBehaviour, IWeapon
{
    public float cooldownDuration = 10f;
    public GameObject deployableShieldPrefab;
    private float timeSinceLastSpawned;
    private Vector2 spawnOffset = new Vector2(0f, 0.5f);
    private bool firing = false;
    private IProjectile projectile;

    void Start() {
        timeSinceLastSpawned = cooldownDuration;
    }

    public void fire() {
        firing = true;
    }

    public void stopFiring() {
        firing = false;
    }

    void Update() {
        timeSinceLastSpawned += Time.deltaTime;
        if (firing && timeSinceLastSpawned > cooldownDuration) {
            timeSinceLastSpawned = 0f;
            GameObject deployableShield = (GameObject)Instantiate(deployableShieldPrefab, new Vector2(gameObject.transform.position.x,
   gameObject.transform.position.y), transform.root.rotation);
        projectile = deployableShield.GetComponent<IProjectile>();
        if (gameObject.transform.root.CompareTag("Player"))
                projectile.setTarget("Enemy");
            else
                projectile.setTarget("Player");
        }
    }

    public string toString()
    {
        return "DeployableShield";
    }
}