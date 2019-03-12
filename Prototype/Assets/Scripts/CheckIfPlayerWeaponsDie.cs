using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfPlayerWeaponsDie : MonoBehaviour
{
    private GameObject player;
    private GameObject leftWing;
    private GameObject rightWing;
    public GameObject basicCannonPrefab;

    void Update() {
        player = GameObject.Find("Player");
        leftWing = player.transform.Find("Left Wing").gameObject;
        rightWing = player.transform.Find("Right Wing").gameObject;
        // Check left wing
        if (leftWing.GetComponentInChildren<WingCode>() == null) {
            GameObject weapon = Instantiate(basicCannonPrefab);
            weapon.name = "Cannon";
            WingCode weaponWing = weapon.GetComponent<WingCode>();
            weaponWing.transform.parent = leftWing.transform;
            weaponWing.transform.position = Vector2.zero;
            weaponWing.transform.localPosition = Vector2.zero;
            weaponWing.snappable = false;
            weaponWing.isSnapped = true;
        }

        // Check right wing
        if (rightWing.GetComponentInChildren<WingCode>() == null) {
            GameObject weapon = Instantiate(basicCannonPrefab);
            weapon.name = "Cannon";
            WingCode weaponWing = weapon.GetComponent<WingCode>();
            weaponWing.transform.parent = rightWing.transform;
            weaponWing.transform.position = Vector2.zero;
            weaponWing.transform.localPosition = Vector2.zero;
            weaponWing.snappable = false;
            weaponWing.isSnapped = true;
        }
    }
}
