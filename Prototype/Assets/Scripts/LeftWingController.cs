using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWingController : MonoBehaviour
{
    IWeapon weapon;
    private KeyCode key;
    private float timeSinceLastSpawned = 0f;
    private Vector2 spawnOffset = new Vector2(0f, 0.5f);

    void Start() {
        if (gameObject.transform.childCount > 1)
        {

        }
    }

    void Update() {

        if (gameObject.transform.childCount == 2)
        {
            weapon = gameObject.GetComponentInChildren<IWeapon>();


            if (gameObject.CompareTag("Left Wing"))
            {
                key = KeyCode.O;
            }
            else
            {
                // idk
            }
            timeSinceLastSpawned += Time.deltaTime;
            if (Input.GetKey(key))
                weapon.fire();
            else
                weapon.stopFiring();
        }
        // checks if there are multiple weapons equipped on a wing, and detaches the extras
        else if (gameObject.transform.childCount > 2)
        {
            for(int i = 1; i < gameObject.transform.childCount -1; i++)
            {
                gameObject.transform.GetChild(i).parent = null;
            }
        }
    }
}
