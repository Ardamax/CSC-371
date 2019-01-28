using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed;  
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0f, 1f, 0f) * speed * Time.deltaTime);

        if (transform.position.y > 20) {
            Destroy(gameObject);
        }
    }
}
