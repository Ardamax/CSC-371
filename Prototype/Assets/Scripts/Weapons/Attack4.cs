using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack4 : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 0.5f;
    public float speed = 5f;
    public float rotationPerWave = 0f;
    public float objectsPerWave = 10;
    private bool isFiring = false;
    private float timeSinceLastSpawn = 0f;
    private int waveCount = 0;
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
            waveCount++;
            for (int i = 0; i < objectsPerWave; i++) {
                GameObject obj = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
                obj.transform.Rotate(0f, 0f, (waveCount * rotationPerWave) + (i * (360 / (objectsPerWave))));
                obj.GetComponent<SimpleMover>().setDirection(new Vector2(0, 1));
                obj.GetComponent<SimpleMover>().setSpeed(speed);
            }
        }
    }
}
