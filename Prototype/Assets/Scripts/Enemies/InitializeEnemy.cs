using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class InitializeEnemy : MonoBehaviour
{
    public float minX = -7f;
    public float maxX = 7f;
    public float initialY = 6.5f;
    public float targetY = 3.5f;
    public float moveSpeed = 1f;

    void Start()
    {
        float initialX = Random.Range(minX, maxX);
        Vector2 initialPos = new Vector2(initialX, initialY);
        gameObject.transform.position = initialPos;
    }

    void Update()
    {
        Vector2 oldPos = gameObject.transform.position;
        Vector2 newPos = new Vector2 (oldPos.x, oldPos.y - (moveSpeed * Time.deltaTime));
        if (newPos.y <= targetY) {
            newPos.y = 3.5f;
            gameObject.transform.position = newPos;
            SendMessage("startAttacking");
            this.enabled = false;
        }
        gameObject.transform.position = newPos;
    }
}
