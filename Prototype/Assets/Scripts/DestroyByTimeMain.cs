using UnityEngine;
using System.Collections;
//justin
public class DestroyByTimeMain : MonoBehaviour
{
    public float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
