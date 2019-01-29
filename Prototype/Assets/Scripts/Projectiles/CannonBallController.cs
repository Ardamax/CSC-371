using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }
    public float damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (parent is CannonController)
        {
            damage = 100;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SendMessage("OnDamage", damage);
            Destroy(gameObject);
        }
    }
}
