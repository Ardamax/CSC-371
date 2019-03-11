using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class HealerController : MonoBehaviour, IWeapon
{
    public float healingRate = 1f;
    public float healthPerTick = 1f;
    private float timeSinceLastHealed = 0f;

    public int maxDurability = 300;
    private int durability;
    private SpriteRenderer r;

    private PlayerHealth playerHealth;

    void Start()
    {
        durability = maxDurability;
        r = GetComponent<SpriteRenderer>();
    }
    public void degrade()
    {
        durability--;
        if (durability <= maxDurability / 4)
            r.color = Color.red;
        if (durability < 1)
            Destroy(gameObject);
    }

    public void fire() {
        // Don't do anything - healer doesn't fire
    }

    public void stopFiring() {
        // Don't do anything - healer doesn't fire
    }

    void Update()
    {
        timeSinceLastHealed += Time.deltaTime;

        if (gameObject.transform.root.CompareTag("Player") && timeSinceLastHealed > healingRate) {
            timeSinceLastHealed = 0f;

            playerHealth = gameObject.transform.root.GetComponent<PlayerHealth>();
            playerHealth.heal(healthPerTick);
            
            degrade();
        }
    }

    public string toString() {
        return "Healer";
    }
}
