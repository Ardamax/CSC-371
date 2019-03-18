using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class ResetPlayerHealthOnNewScene : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null) {
            PlayerHealth playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
            if (playerHealth != null) {
                playerHealth.resetHealth();
            }
        }
        
    }
}
