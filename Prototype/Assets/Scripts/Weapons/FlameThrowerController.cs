using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerController : MonoBehaviour, IWeapon
{
    public GameObject flamePrefab;
    private GameObject flame;

    private bool firing = false;
    void Start() {
        
    }

    public void fire() {
        if (!firing) {
            flame = Instantiate(flamePrefab, gameObject.transform.position, transform.root.rotation);
            FlameController fController = flame.GetComponent<FlameController>();
            fController.setParent(gameObject);
                if (transform.root.CompareTag("Player")) {
                    fController.setTarget("Enemy");
                }
                else {
                    fController.setTarget("Player");
                }
            firing = true;
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
