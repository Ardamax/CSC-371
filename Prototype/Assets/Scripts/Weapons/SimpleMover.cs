using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    private Vector2 direction;
    private float speed;
    public void setDirection(Vector2 direction) {
        this.direction = direction;
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    void Update() {
        gameObject.transform.Translate(direction * speed * Time.deltaTime);
    }
}
