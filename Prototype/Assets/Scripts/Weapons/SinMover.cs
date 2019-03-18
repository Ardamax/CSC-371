using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class SinMover : MonoBehaviour
{
    private Vector2 direction = new Vector2(0f, 1f);
    private float speed;
    private float coefficient;
    private float initializationTime;
    private float initialX;
    private float frequency = Mathf.PI * 4;
    void Start() {
        initializationTime = Time.timeSinceLevelLoad;
        initialX = gameObject.transform.position.x;
    }
    public void setDirection(Vector2 direction) {
        this.direction = direction;
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
        gameObject.transform.position = new Vector2(initialX + (coefficient * Mathf.Sin(frequency * deltaTime)), gameObject.transform.position.y);
    }
}
