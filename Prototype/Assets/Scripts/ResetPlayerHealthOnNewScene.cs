using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerHealthOnNewScene : MonoBehaviour
{
    void Start()
    {
        PlayerHealth playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            playerHealth.resetHealth();
        }
    }
}
