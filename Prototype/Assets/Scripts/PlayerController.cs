using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float xbounds, ybounds;
    public float speed;
    public Boundary boundary;
    public Transform shotSpawn; // can add multiple
    public GameObject shot;
    public float fireRate;

    private float nextFire;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void OnDamage(int damage)
    {

    }
    void FixedUpdate() //Original movement by ______ Movement remade by Chris to get rid of sliding
    {

        float horizontalMovement = 0;
        float verticalMovement = 0;

        if (Input.GetKey("d"))
        {
            if (transform.position.x <= xbounds)
            {
                horizontalMovement = 1;

            }
        }
        else if (Input.GetKey("a"))
        {
            if (transform.position.x >= -1 * xbounds)
            {
                horizontalMovement = -1;

            }

        }
 
        if (Input.GetKey("w"))
        {
            if (transform.position.y <= ybounds)
            {
                verticalMovement = 1;

            }
        }
        else if (Input.GetKey("s"))
        {
            if (transform.position.y >= -1* ybounds)
            {
                verticalMovement = -1;

            }
        }

        Vector2 movement = new Vector2(horizontalMovement, verticalMovement) * speed;
        transform.Translate(movement * Time.deltaTime);

    }
}