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
        if (gameObject.transform.childCount == 2) //if conditions modified by Chris to fix bugs
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
        // checks if there are multiple weapons equipped on a wing, and detaches the extras
        else if (gameObject.transform.childCount > 2)
        {
            for (int i = 1; i < gameObject.transform.childCount -1; i++) //else if added by Chris to fix bugs
            {
                gameObject.transform.GetChild(i).parent = null;
            }
        }
    }
}
