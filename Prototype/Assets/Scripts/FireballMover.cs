using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class FireballMover : MonoBehaviour
{
    public float speed;

    void Update()
    {
        gameObject.transform.Translate(new Vector3(0f, -1f, 0f) * speed * Time.deltaTime);

        if (transform.position.y < -15) {
            Destroy(gameObject);
        }
    }
}
