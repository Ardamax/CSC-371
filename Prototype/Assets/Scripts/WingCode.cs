    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingCode : MonoBehaviour
{



    public bool snappable = false;
    public bool isSnapped = false;
    private Vector3 offset;
    private Vector2 PosOffset;
    Collider2D savedCol;
    float x = 0, y = 0;
    private void Start()
    {
        //Debug.Log("Start!");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isSnapped) {
            //Debug.Log("snapped");
            return;
        }
        else {
            //Debug.Log("Not snapped");
        }

        if (col.tag == "Left Wing" || col.tag == "Right Wing")
        {
            snappable = true;
            savedCol = col;
            //Debug.Log("Snapable!");
            /* orient potential parts to the slots they are near*/
            if (col.gameObject.name == "Left Wing")
            {
                //  Debug.Log("LEFT!");
                //x = -2.2f;
                //y = 0.1f;
                //transform.eulerAngles = new Vector3(0, 0, 180);


            }
            else if (col.gameObject.name == "Right Wing")
            {
                //   Debug.Log("RIGHT!");
               // x = 2.7f;
                //y = 0.3f;
               // transform.eulerAngles = new Vector3(0, 0, 0);

            }

        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Left Wing" || col.tag == "Right Wing")
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
            if ((gameObject.transform.parent == null) && (snappable == true) && (savedCol != null) && (savedCol.gameObject.name == "Right Wing"))
            {
                transform.parent = savedCol.transform;
                transform.position = Vector2.zero;
                transform.localPosition = new Vector2(0, 0);//(x +0.9f, y - 0.3f);
                snappable = false;
                isSnapped = true;

            }
            /* wing is connected to right wing; disconnect*/
            else if ((gameObject.transform.parent) && (transform.parent.gameObject.name == "Right Wing") && (snappable == false))
            {
                transform.parent = null;
                snappable = true;
                isSnapped = false;
            }

        }

        /*left wing stuff*/
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            /* wing is disconnected but in range of ship; attach right*/
            if ((gameObject.transform.parent == null) && (snappable == true) && (savedCol != null) && (savedCol.gameObject.name == "Left Wing"))
            {
                //Debug.Log("Connecting\n");
                transform.parent = savedCol.transform;
               // Debug.Log("parent check\n");

                transform.position = Vector2.zero;
                transform.localPosition = new Vector2(0, 0);//(x-1.45f, y -0.1f);
                //Debug.Log("location check\n");

                snappable = false;
                isSnapped = true;

            }
            /* wing is connected to left wing; disconnect*/
            else if ((gameObject.transform.parent) && (transform.parent.gameObject.name == "Left Wing") && (snappable == false))
            {
                //Debug.Log("Disconnecting\n");

                transform.parent = null;
                snappable = true;
                isSnapped = false;
            }
        }
    }

}
