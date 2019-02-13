using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWingController : MonoBehaviour
{
    IWeapon weapon;
    private KeyCode key;
    private float timeSinceLastSpawned = 0f;
    private Vector2 spawnOffset = new Vector2(0f, 0.5f);

    void Start()
    {
        /* prevents nullreference if gun not present*/
        if (gameObject.transform.childCount > 1)
        {

        }
    }

    void Update()
    {
        if (gameObject.transform.childCount > 1)
        {
            weapon = gameObject.GetComponentInChildren<IWeapon>();
            if (gameObject.CompareTag("Right Wing"))
            {
                key = KeyCode.P;
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

    }
}
