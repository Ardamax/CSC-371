using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class GroundMovement : MonoBehaviour
{
    public float speed;
    private float groundVerticalLength;

    void Start() {
        groundVerticalLength = GetComponent<MeshCollider>().bounds.size.y;
    }

    void Update()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime);
        if (transform.position.y < -groundVerticalLength) {
            RepositionBackground();
        }
    }

    private void RepositionBackground() {
        Vector2 offset = new Vector2(0, groundVerticalLength * 2f);
        transform.position = new Vector3 (transform.position.x, transform.position.y + (groundVerticalLength * 2f) - 3f, transform.position.z);
    }
}
