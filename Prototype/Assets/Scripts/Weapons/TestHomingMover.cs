using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class TestHomingMover : MonoBehaviour
{
    public float width = 5f;
    private float initializationTime;
    private float initialX;

    void Start() {
        initializationTime = Time.timeSinceLevelLoad;
        initialX = gameObject.transform.position.x;
    }
    void Update()
    {
        float deltaTime = Time.timeSinceLevelLoad - initializationTime;
        gameObject.transform.position = new Vector2(initialX + 4 * (Mathf.Sin(deltaTime)), gameObject.transform.position.y);
    }
}
