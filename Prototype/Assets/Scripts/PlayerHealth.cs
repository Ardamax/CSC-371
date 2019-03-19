using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
//justin 
//chris (sound)
//Spencer (Haungs mode)
[Preserve]

public class PlayerHealth : MonoBehaviour
{	
	public float initialHealth;			// The player's starting health
	public float health;				// The player's current health.
	public float repeatDamagePeriod = 2f;						
	public float hurtForce = 10f;				
	public float damageAmount = 10f;			//if crashing into enemy get damaged this amount

	private SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private float lastHitTime;					// The time at which the player was last hit.
	private Vector3 healthScale;
    private string sceneName;


    //Audio stuff added by Chris
    public AudioClip impact;
    static AudioSource audioSrc;

	void Start() {
		healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
		healthScale = healthBar.transform.localScale;

		resetHealth();
        sceneName = SceneManager.GetActiveScene().name;

		audioSrc = GetComponent<AudioSource>();
    }

	void Update() {
		if (Input.GetKeyDown(KeyCode.H)) {
			health = 1000;
			UpdateHealthBar();
		}
	}

	public void resetHealth() {
		health = initialHealth;
		UpdateHealthBar();
	}

	public void heal(float healingAmount) {
		float newHealth = health + healingAmount;
		if (newHealth > initialHealth) {
			newHealth = initialHealth;
		}

		health = newHealth;
		UpdateHealthBar();
		print("Healing: " + health);
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
                    //TakeDamage(col.transform); 
                    //OnDamage(damageAmount);
					lastHitTime = Time.time; 
				}
				// If the player doesn't have health, do some stuff
				else
				{
                    //SceneManager.LoadScene(0);
                    //GameControllerMain.GameOver();
                }
			}
		}
    }

    void OnDamage(int damage)
    {
        health -= damage;
        audioSrc.PlayOneShot(impact, 0.7F);
        UpdateHealthBar();
        if(health <= 0f)
        {
            if (sceneName == "Level1")
            {
                sceneName = "NotLevel1";
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        }
    }


    void TakeDamage (Transform enemy)
	{
		// Create a vector that's from the enemy to the player with an upwards boost.
		//Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;

		//force that propels the player away from enemy
		//GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);

		// Reduce the player's health
		health -= damageAmount;
        audioSrc.PlayOneShot(impact, 0.7F);


        // Update what the health bar looks like.
        UpdateHealthBar();

	}


	public void UpdateHealthBar ()
	{
		// Set the health bar's colour to proportion of the way between green and red based on the player's health.
		healthBar.material.color = Color.Lerp(Color.blue, Color.red, 1 - health * 0.1f);

		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.1f, 1, 1);
	}
}
