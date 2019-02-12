using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 0.5f;
    public float speed = 5f;
    private bool isFiring = false;
    private float timeSinceLastSpawn = 0f;
    private Vector2 offset = new Vector2(0.2f, 0f);
    public void toggle() {
        isFiring = !isFiring;
    }

    void Update() {
        if (!isFiring) {
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > spawnRate) {
            timeSinceLastSpawn = 0f;
            GameObject obj = Instantiate(prefab, (Vector2)gameObject.transform.position - offset, Quaternion.identity);
            obj.GetComponent<SimpleMover>().setDirection(new Vector2(0, 1));
            obj.GetComponent<SimpleMover>().setSpeed(speed);

            obj = Instantiate(prefab, (Vector2)gameObject.transform.position + offset, Quaternion.identity);
            obj.GetComponent<SimpleMover>().setDirection(new Vector2(0, 1));
            obj.GetComponent<SimpleMover>().setSpeed(speed);
        }
    }
}
