using UnityEngine;
using System.Collections;

public class DestroyByBoundaryMain : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}