using UnityEngine;
using System.Collections;

public class DestroyByBoundaryMain : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}