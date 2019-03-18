using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class Attack6 : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 0.5f;
    public float speed = 5f;
    public float speedIncrease = 2f;
    private bool isFiring = false;
    private float timeSinceLastSpawn = 0f;

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
            GameObject obj = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            obj.GetComponent<AccelerateMover>().setDirection(new Vector2(0, 1));
            obj.GetComponent<AccelerateMover>().setSpeed(speed);
            obj.GetComponent<AccelerateMover>().setSpeedIncrease(speedIncrease);
        }
    }
}
