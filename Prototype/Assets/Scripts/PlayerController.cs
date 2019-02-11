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
    public float maxSpeed;
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


    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            
        }
    }



    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalMovement, verticalMovement) * speed;
        rb2d.AddForce(movement);

        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);

    }
}