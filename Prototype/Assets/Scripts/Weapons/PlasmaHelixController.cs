using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaHelixController : MonoBehaviour, IWeapon
{
    public float spawnRate = 0.1f;
    public GameObject plasmaBallPrefab;
    private float timeSinceLastSpawned = 0f;
    private Vector2 spawnOffset = new Vector2(0f, 0.5f);
    private bool firing = false;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void fire()
    {
        firing = true;
    }
    public void stopFiring()
    {
        firing = false;
    }
    public
    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (firing && timeSinceLastSpawned > spawnRate)
        {
            timeSinceLastSpawned = 0f;
            obj = Instantiate(plasmaBallPrefab, new Vector2(gameObject.transform.position.x + spawnOffset.x,
               gameObject.transform.position.y + spawnOffset.y), Quaternion.identity);
            obj.GetComponent<PlasmaMover>().setCoefficient(0.5f);
            
            obj = Instantiate(plasmaBallPrefab, new Vector2(gameObject.transform.position.x + spawnOffset.x,
               gameObject.transform.position.y + spawnOffset.y), Quaternion.identity);
            obj.GetComponent<PlasmaMover>().setCoefficient(-0.5f);
        }
    }
}
