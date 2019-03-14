using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] waves;
    public float timeBetweenWaves = 5f;
    private int currentWaveId = -1;
    private float timeSinceLastWaveEnded = 0f;
    private bool isWaveRunning = false;

    void Update()
    {
        if (isWaveRunning) {
            checkIfWaveDied();
        }
        else {
            timeSinceLastWaveEnded += Time.deltaTime;
            if (timeSinceLastWaveEnded > timeBetweenWaves) {
                startNextWave();
            }
        }
    }
    private void checkIfWaveDied() {
        GameObject currentWave = waves[currentWaveId];
        if (currentWave != null) {
            if (currentWave.transform.childCount <= 0) {
                isWaveRunning = false;
                currentWave.SetActive(false);
                timeSinceLastWaveEnded = 0f;
            }
        }
    }

    private void startNextWave() {
        currentWaveId++;
        if (currentWaveId >= waves.Length) {
            // No more waves - all waves completed.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            this.enabled = false;
        }
        else {
            isWaveRunning = true;
            GameObject currentWave = waves[currentWaveId];
            if (currentWave != null) {
                currentWave.SetActive(true);
            }
        }
    }
}
