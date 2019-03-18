using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class FlameThrowerController : MonoBehaviour, IWeapon
{
    public GameObject flamePrefab;
    private GameObject flame;

    private bool firing = false;

    public int maxDurability;
    private int durability;
    private SpriteRenderer r;

    void Start() {
        maxDurability = 100;
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
        if (!firing) {
            flame = Instantiate(flamePrefab, gameObject.transform.position, transform.rotation);
            FlameController fController = flame.GetComponent<FlameController>();
            fController.setParent(gameObject);
                if (transform.root.CompareTag("Player")) {
                    fController.setTarget("Enemy");
                }
                else {
                    fController.setTarget("Player");
                }
            firing = true;
            degrade();//this line should be in the update function, but there seems to be none
        }
    }

    public void stopFiring() {
        if (flame) {
            Destroy(flame);
            flame = null;
        }
        firing = false;
    }

    public string toString() {
        return "FlameThrower";
    }
}
