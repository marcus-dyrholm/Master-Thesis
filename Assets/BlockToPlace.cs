using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockToPlace : MonoBehaviour
{

    public GameObject placementTarget;
    public bool isColliding = false;

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
