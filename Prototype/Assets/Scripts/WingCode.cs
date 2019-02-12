using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingCode : MonoBehaviour
{



    bool snappable = false;
    private Vector3 offset;
    private Vector2 PosOffset;
    Collider2D savedCol;
    float x = 0, y = 0;
    private void Start()
    {
        Debug.Log("Start!");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.tag == "AnchorPoint")
        {
            snappable = true;
            savedCol = col;
            Debug.Log("Snapable!");
            /* orient potential parts to the slots they are near*/
            if (col.gameObject.name == "LeftWingHardPoint")
            {
                //  Debug.Log("LEFT!");
                x = -2.2f;
                y = 0.1f;
                transform.eulerAngles = new Vector3(0, 0, 180);


            }
            else if (col.gameObject.name == "RightWingHardPoint")
            {
                //   Debug.Log("RIGHT!");
                x = 2.7f;
                y = 0.3f;
                transform.eulerAngles = new Vector3(0, 0, 0);

            }

        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "AnchorPoint")
        {
            //Debug.Log("Out of range!");
            snappable = false;
        }


    }
    private void Update()
    {
        /*right wing stuff*/
        if (Input.GetKeyDown(KeyCode.E))
        {
            /* wing is disconnected but in range of ship; attach right*/
            if ((gameObject.transform.parent == null) && (snappable == true))
            {
                transform.parent = savedCol.transform;
                transform.position = Vector2.zero;
                transform.localPosition = new Vector2(x +0.9f, y - 0.3f);
                snappable = false;

            }
            /* wing is connected to right wing; disconnect*/
            else if ((gameObject.transform.parent) && (transform.parent.gameObject.name == "RightWingHardPoint") && (snappable == false))
            {
                transform.parent = null;
                snappable = true;
            }

        }

        /*left wing stuff*/
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            /* wing is disconnected but in range of ship; attach right*/
            if ((gameObject.transform.parent == null) && (snappable == true))
            {
                //Debug.Log("Connecting\n");
                transform.parent = savedCol.transform;
               // Debug.Log("parent check\n");

                transform.position = Vector2.zero;
                transform.localPosition = new Vector2(x-1.45f, y -0.1f);
                //Debug.Log("location check\n");

                snappable = false;

            }
            /* wing is connected to right wing; disconnect*/
            else if ((gameObject.transform.parent) && (transform.parent.gameObject.name == "LeftWingHardPoint") && (snappable == false))
            {
                //Debug.Log("Disconnecting\n");

                transform.parent = null;
                snappable = true;
            }
        }
    }

}
