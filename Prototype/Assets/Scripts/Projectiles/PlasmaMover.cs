using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
//justin
public class PlasmaMover : MonoBehaviour, IProjectile
{
    private Vector2 direction = new Vector2(0f, 1f);
    public float speed = 10f;
    private float coefficient;
    private float initializationTime;
    private float initialX;
    private float frequency = Mathf.PI * 4;
    private string target;

    public int damage = 2;
    void Start() {
        initializationTime = Time.timeSinceLevelLoad;
        initialX = gameObject.transform.position.x;
    }
    public void setTarget(string t)
    {
        target = t;
    }
    public void setDirection(Vector2 direction) {
        this.direction = Vector2.ClampMagnitude(direction, 1);
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    public void setCoefficient(float coefficient) {
        this.coefficient = coefficient;
    }

    public void setFrequency(float frequency) {
        this.frequency = frequency;
    }

    void Update() {
        float deltaTime = Time.timeSinceLevelLoad - initializationTime;
        gameObject.transform.Translate(direction * speed * Time.deltaTime);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + (coefficient * Mathf.Sin(frequency * deltaTime)), gameObject.transform.position.y);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(target))
        {
            other.gameObject.transform.SendMessageUpwards("OnDamage", damage, SendMessageOptions.RequireReceiver);
            Destroy(gameObject);
        }
    }
}
