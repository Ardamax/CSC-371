using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jump = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = 20;
        }
        Vector3 movement = new Vector3(moveHorizontal, jump, moveVertical);
        


        rb.AddForce(movement*speed);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            count++;
            SetCountText();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("BadPickUp"))
        {
            count--;
            SetCountText();
            other.gameObject.SetActive(false);
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
            winText.text = "You Win!";
    }
}
