using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class WeaponScroller : MonoBehaviour
{
    public float speed = 1f;
    public WingCode weapon;
    private Vector3 movement = new Vector3(0, -1, 0);

    void Start() {
        weapon = gameObject.GetComponent<WingCode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!weapon.isSnapped) {
            weapon.gameObject.transform.Translate(movement * speed * Time.deltaTime);
        }
    }
}
