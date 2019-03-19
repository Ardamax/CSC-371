using UnityEngine;
using System.Collections;
//justin

public class DestroyByBoundaryMain : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
