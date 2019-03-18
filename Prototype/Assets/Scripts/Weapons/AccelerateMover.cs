using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class AccelerateMover : MonoBehaviour
{
    private Vector2 direction;
    private float speed;
    private float speedIncrease;
    private float  initializationTime;
    void Start() {
        initializationTime = Time.timeSinceLevelLoad;
    }
    public void setDirection(Vector2 direction) {
        this.direction = direction;
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    public void setSpeedIncrease(float speedIncrease) {
        this.speedIncrease = speedIncrease;
    }

    void Update() {
        float deltaTime = Time.timeSinceLevelLoad - initializationTime;
        gameObject.transform.Translate(direction * (speed + (deltaTime * speedIncrease)) * Time.deltaTime);
    }
}
