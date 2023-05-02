using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTarget : MonoBehaviour
{
    private Collider boxCollider;
    private Bounds bounds;
    private GameObject sphere;

    private void Start()
    {
        boxCollider = GetComponent<Collider>();
        bounds = boxCollider.bounds;
    }

    private void Update()
    {
        // Get the bounds of the box collider
        

        if (sphere == null)
        {
            return;
        }

        // Calculate the sphere's position relative to the box collider's center
        Vector3 relativePos = sphere.transform.position - bounds.center;

        // Check if the sphere is fully inside the box collider
        if (Mathf.Abs(relativePos.x) + sphere.transform.localScale.x / 2 <= bounds.extents.x &&
            Mathf.Abs(relativePos.y) + sphere.transform.localScale.y / 2 <= bounds.extents.y &&
            Mathf.Abs(relativePos.z) + sphere.transform.localScale.z / 2 <= bounds.extents.z)
        {
            Debug.Log("The sphere is fully inside the box collider");
        }
        else
        {
            Debug.Log("The sphere is not fully inside the box collider");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SphereCollider>() != null)
            sphere = other.gameObject;
    }
}
