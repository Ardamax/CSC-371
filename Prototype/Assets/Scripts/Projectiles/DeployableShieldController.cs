using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class DeployableShieldController : MonoBehaviour
{
    private string target;
    private SpriteRenderer r;
    public int health = 100;
    public float speed;
    public float distance = 3f;
    private bool isDeploying = true;
    private Vector2 initialPosition;
    private Vector3 initialSize;
    private float size = 1f;
    private int currentHealth;
    void Start()
    {
        r = GetComponent<SpriteRenderer>();
        initialPosition = gameObject.transform.position;
        currentHealth = health;
        initialSize = gameObject.transform.localScale;
    }
    void Update()
    {
        if (gameObject.CompareTag("Enemy")) {
            r.color = Color.red;
            distance = Mathf.Abs(distance) * -1f;
        }

        if (isDeploying) {
            gameObject.transform.Translate(new Vector2(0f, 1f) * speed * Time.deltaTime);
            if (gameObject.CompareTag("Enemy")) {
                if (gameObject.transform.position.y <= initialPosition.y + distance) {
                    isDeploying = false;
                }
            }
            else {
                if (gameObject.transform.position.y >= initialPosition.y + distance) {
                    isDeploying = false;
                }
            }
        }

        gameObject.transform.localScale = new Vector3(size * initialSize.x, size * initialSize.y, 1f);
    }

    void OnDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 10) {
            Destroy(gameObject);
        }
        else {
            size = (float)currentHealth / (float)health;
        }
    }
}
