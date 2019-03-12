using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class InitializeEnemy : MonoBehaviour
{
    public float targetY = 7.5f;
    public float moveSpeed = 2f;
    private Vector2 target;

    void Start() {
        target = new Vector2(transform.position.x, targetY);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f) {
            print("Attacking!");
            SendMessage("startAttacking");
            this.enabled = false;
        }
    }
}
