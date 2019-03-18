using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class DontDestroyPlayer : MonoBehaviour
{

    public GameObject playerPrefab;
    void Start()
    {
        GameObject player = GameObject.Find("Player");

        if (!player) {
            // Player is null - Instantiate new one
            player = Instantiate(playerPrefab);
            player.name = "Player";
        }

        DontDestroyOnLoad(player);
    }
}
