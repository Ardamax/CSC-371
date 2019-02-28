using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour, IProjectile
{
    // Start is called before the first frame update
    private string target;
    private SpriteRenderer r;
    public float damage = 1;
    public float speed;

    void Start()
    {
        r = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (target == "Player")
        {
            r.color = Color.red;
        }
        gameObject.transform.Translate(new Vector3(0f, 1f, 0f) * speed * Time.deltaTime);

        if (transform.position.y > 20 || transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }
    public void setTarget(string t)
    {
        target = t;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(target))
        {
            other.gameObject.transform.root.SendMessage("OnDamage", damage, SendMessageOptions.RequireReceiver);
            Destroy(gameObject);
        }
    }
    
}
