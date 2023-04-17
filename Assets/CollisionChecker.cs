using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public bool cubesIsColliding = false;
    public int collisionID;

    private void OnTriggerStay(Collider other)
    {
        
        if (other.GetComponent<TutorialCube>().ID == collisionID)
            cubesIsColliding = true;
    }

    

    private void OnTriggerExit(Collider other)
    {
        cubesIsColliding = false;
    }
}
