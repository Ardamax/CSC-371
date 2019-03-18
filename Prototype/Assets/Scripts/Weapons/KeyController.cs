using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class KeyController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            GetComponent<Attack1>().toggle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            GetComponent<Attack2>().toggle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            GetComponent<Attack3>().toggle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            GetComponent<Attack4>().toggle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            GetComponent<Attack5>().toggle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            GetComponent<Attack6>().toggle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) {
            GetComponent<Attack7>().toggle();
        }
    }
}
