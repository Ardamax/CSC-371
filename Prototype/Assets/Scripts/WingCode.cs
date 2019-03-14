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

    private void OnTriggerStay2D(Collider2D col)
    {

        if (col.tag == "Left Wing" || col.tag == "Right Wing")
        {
            snappable = true;
            savedCol = col;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Left Wing" || col.tag == "Right Wing")
        {
            //Debug.Log("Out of range!");
            snappable = false;
            savedCol = null;
        }


    }
    private void Update()
    {
        /*right wing stuff*/
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            /* wing is disconnected but in range of ship; attach right*/
            //   no parent                                 is snappable       collider still in range     at right wing                                  no other weapons attached
            if ((gameObject.transform.parent == null) && (snappable == true) && (savedCol != null) && (savedCol.gameObject.name == "Right Wing"))
            {
                if ((savedCol.gameObject.transform.childCount == 1) || (savedCol.gameObject.transform.childCount == 2 && savedCol.gameObject.transform.GetChild(1).name == "Cannon"))
                {

                    transform.parent = savedCol.transform;
                    transform.position = Vector2.zero;
                    transform.localPosition = new Vector2(0, 0);
                    snappable = false;
                    isSnapped = true;
                }
            }
            /* weapon is connected to right wing; disconnect*/
            else if ((gameObject.transform.parent) && (transform.parent.gameObject.name == "Right Wing") && (snappable == false))
            {
                transform.parent = null;
                snappable = true;
                isSnapped = false;
                IWeapon weapon = gameObject.GetComponent<IWeapon>(); 
                if (weapon != null) {
                    weapon.stopFiring();
                }
                if (gameObject.name == "Cannon") {
                    Destroy(gameObject);
                }
            }
        }

        /*left wing stuff*/
        else if (Input.GetKeyDown(KeyCode.L))
        {
            /* wing is disconnected but in range of ship; attach left*/
            if ((gameObject.transform.parent == null) && (snappable == true) && (savedCol != null) && (savedCol.gameObject.name == "Left Wing"))
            {
                if ((savedCol.gameObject.transform.childCount == 1) || (savedCol.gameObject.transform.childCount == 2 && savedCol.gameObject.transform.GetChild(1).name == "Cannon"))
                {
                    transform.parent = savedCol.transform;
                    transform.position = Vector2.zero;
                    transform.localPosition = new Vector2(0, 0);
                    snappable = false;
                    isSnapped = true;
                }
            }
            /* wing is connected to left wing; disconnect*/
            else if ((gameObject.transform.parent) && (transform.parent.gameObject.name == "Left Wing") && (snappable == false))
            {
                transform.parent = null;
                snappable = true;
                isSnapped = false;
                IWeapon weapon = gameObject.GetComponent<IWeapon>(); 
                if (weapon != null) {
                    weapon.stopFiring();
                }
                if (gameObject.name == "Cannon") {
                    Destroy(gameObject);
                }
            }
        }
    }
}
