using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// spencer
public class Attack3 : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 0.5f;
    public float speed = 5f;
    public float spreadDegrees = 30f;
    public float objectsPerWave = 3;
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
            for (int i = 0; i < objectsPerWave; i++) {
                GameObject obj = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
                obj.transform.Rotate(0f, 0f, (spreadDegrees / 2f) - (i * (spreadDegrees / (objectsPerWave - 1))));
                obj.GetComponent<SimpleMover>().setDirection(new Vector2(0, 1));
                obj.GetComponent<SimpleMover>().setSpeed(speed);
            }
        }
    }
}
