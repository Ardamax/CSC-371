﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagEffect : MonoBehaviour
{
    //activates lightning effects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon")) {
            transform.GetChild(0).gameObject.SetActive(true);
        } 
    }


    //both disable effects for different cases
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    
    private void Update()
    {
        /*disables effect when a part is equiped
         may cause UI issues if a free part on the other side is still in range because effects on both sides turn off */
        if ((Input.GetKeyDown(KeyCode.Q)) || (Input.GetKeyDown(KeyCode.E)))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
