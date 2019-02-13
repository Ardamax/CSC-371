﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{	
	public float health = 100f;					// The player's health.
	public float repeatDamagePeriod = 2f;						
	public float hurtForce = 10f;				
	public float damageAmount = 10f;			//if crashing into enemy get damaged this amount

	private SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private float lastHitTime;					// The time at which the player was last hit.
	private Vector3 healthScale;					

	void Awake ()
	{

		healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();

		// Getting the intial scale of the healthbar (whilst the player has full health).
		healthScale = healthBar.transform.localScale;
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		// If the colliding gameobject is an Enemy
		if(col.gameObject.tag == "Enemy")
		{
			if (Time.time > lastHitTime + repeatDamagePeriod) 
			{
				if(health > 0f)
				{
					//call take damage and reset time since last hit
					TakeDamage(col.transform); 
					lastHitTime = Time.time; 
				}
				// If the player doesn't have health, do some stuff
				else
				{
					//GameControllerMain.GameOver();
					
				}
			}
		}
	}


	void TakeDamage (Transform enemy)
	{

		// Create a vector that's from the enemy to the player with an upwards boost.
		Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;

		//force that propels the player away from enemy
		GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);

		// Reduce the player's health
		health -= damageAmount;

		// Update what the health bar looks like.
		UpdateHealthBar();

	}


	public void UpdateHealthBar ()
	{
		// Set the health bar's colour to proportion of the way between green and red based on the player's health.
		healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
	}
}