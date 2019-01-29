using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneWave : MonoBehaviour
{
    public GameObject[] waveOnePrefabs;

    public float timeUntilFirstWave = 5f;
    public float waveOneApproachRate = 1.5f;

    private GameObject[] waveOneInstantiatedObjects;
    private float timeSinceLastWave = 0f;
    private int currentWave = 0;

    void Start() {
        waveOneInstantiatedObjects = new GameObject[waveOnePrefabs.Length];
    }
    void Update() {
        timeSinceLastWave += Time.deltaTime;
        if (currentWave == 0 && timeSinceLastWave >= timeUntilFirstWave) {
            timeSinceLastWave = 0;
            currentWave = 1;
            for (int i = 0; i < waveOnePrefabs.Length; i++) {
                waveOneInstantiatedObjects[i] = Instantiate(waveOnePrefabs[i], new Vector2(-4.5f + (i * 4.5f), 7), Quaternion.identity);
            }
        }

        if (currentWave == 1 && timeSinceLastWave > 0 && waveOneInstantiatedObjects[0] != null && waveOneInstantiatedObjects[0].transform.position.y != 3) {
            // Move them into place
            for (int i = 0; i < waveOneInstantiatedObjects.Length; i++) {
                if (waveOneInstantiatedObjects[i] != null) {
                    waveOneInstantiatedObjects[i].transform.Translate(new Vector2(0f, -1f) * waveOneApproachRate * Time.deltaTime);
                    if (waveOneInstantiatedObjects[i].transform.position.y < 3) {
                        waveOneInstantiatedObjects[i].transform.position = new Vector3(waveOneInstantiatedObjects[i].transform.position.x, 3, waveOneInstantiatedObjects[i].transform.position.z);
                    }
                }
            }
        }

        if (currentWave == 1 && waveOneInstantiatedObjects[0] != null && waveOneInstantiatedObjects[0].transform.position.y == 3) {
            // Set them as attacking
            for (int i = 0; i < waveOneInstantiatedObjects.Length; i++) {
                if (waveOneInstantiatedObjects[i] != null) {
                    waveOneInstantiatedObjects[i].SendMessage("Attacking");
                }
            }
        }
    }
}
