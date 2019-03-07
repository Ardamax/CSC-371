using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spencer
public class FlameController : MonoBehaviour
{
    public float damagePerTick = 2f;
    public float secondsPerTick = 0.1f;
    private float timeSinceLastTick = 0.1f;
    private string target;
    private GameObject parent;
    void Start()
    {
        
    }
    public void setTarget(string target) {
        this.target = target;
    }

    public void setParent(GameObject parent) {
        this.parent = parent;
    }
    void Update()
    {
        timeSinceLastTick += Time.deltaTime;
        transform.position = parent.transform.position;
    }

    void OnTriggerStay2D(Collider2D other) {
        if (timeSinceLastTick >= secondsPerTick && other.gameObject.CompareTag(target)) {
            print("Attacking");
            timeSinceLastTick = 0f;
            other.gameObject.transform.root.SendMessage("OnDamage", damagePerTick, SendMessageOptions.RequireReceiver);
        }
    }
}
