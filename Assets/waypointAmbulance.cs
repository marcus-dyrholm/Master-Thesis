using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointAmbulance : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector3(1,1,1));
        int index = transform.GetSiblingIndex();
        

        if (index < (transform.parent.childCount-1))
        {
            GameObject nextWaypoint = transform.parent.GetChild(index+1).gameObject;
            Gizmos.DrawRay(transform.position, nextWaypoint.transform.position - transform.position);
        }
        
    }

    void Start()
    {
        
    }
}
