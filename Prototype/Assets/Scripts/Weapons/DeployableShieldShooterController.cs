using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class DeployableShieldShooterController : MonoBehaviour, IWeapon
{
    public float cooldownDuration = 10f;
    public GameObject deployableShieldPrefab;
    private GameObject cooldownBar;
    private Vector3 initialCooldownScale;
    private float timeSinceLastSpawned;
    private Vector2 spawnOffset = new Vector2(0f, 0.5f);
    private bool firing = false;
    private IProjectile projectile;

    public int maxDurability;
    private int durability;
    private SpriteRenderer r;

    void Start() {
        maxDurability = 4;
        durability = maxDurability;
        r = GetComponent<SpriteRenderer>();

        timeSinceLastSpawned = cooldownDuration;
        cooldownBar = gameObject.transform.Find("CooldownBar").gameObject;
        initialCooldownScale = cooldownBar.transform.localScale;
    }

    public void fire() {
        firing = true;
    }
    public void degrade()
    {
        durability--;
        if (durability <= maxDurability / 4)
            r.color = Color.red;
        if (durability < 1)
            Destroy(gameObject);
    }
    public void stopFiring() {
        firing = false;
    }

    void Update() {
        timeSinceLastSpawned += Time.deltaTime;
        if (firing && timeSinceLastSpawned > cooldownDuration) {
            timeSinceLastSpawned = 0f;
            GameObject deployableShield = (GameObject)Instantiate(deployableShieldPrefab, new Vector2(gameObject.transform.position.x,
                gameObject.transform.position.y), transform.rotation);
        
            if (gameObject.transform.root.CompareTag("Player")) {
                deployableShield.tag = "Player";
            }
            else {
                deployableShield.tag = "Enemy";
            }
            degrade();
        }
        updateCooldownBar();
    }

    void updateCooldownBar() { 
        float timeScale = Mathf.Min(timeSinceLastSpawned / cooldownDuration, 1f);
        cooldownBar.transform.localScale = new Vector3(initialCooldownScale.x * timeScale, initialCooldownScale.y, initialCooldownScale.z);

        if (timeScale < 1f) {
            cooldownBar.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else {
            cooldownBar.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public string toString()
    {
        return "DeployableShield";
    }
}