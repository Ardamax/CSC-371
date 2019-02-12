using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMover : MonoBehaviour
{
    private Vector2 direction;
    private GameObject destination;
    private float speed;
    private float homingThreshold = 1f;
    private bool flewPast = false;
    public void setDirection(Vector2 direction) {
        this.direction = direction;
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }

    public void setDestination(GameObject destination) {
        this.destination = destination;
    }

    void Update() {
        float distance = Mathf.Abs(Vector2.Distance((Vector2)destination.transform.position, gameObject.transform.position));
        if (!flewPast && distance >= homingThreshold) {
            Vector2 dir = (Vector2)destination.transform.position - (Vector2)gameObject.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.AngleAxis(90f + angle, Vector3.forward);
        }
        else if (!flewPast) {
            flewPast = true;
        }
        gameObject.transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime);

    }
}
