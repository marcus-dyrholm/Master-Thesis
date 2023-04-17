using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public BlockToPlace ColliderTarget1, ColliderTarget2;

    private Collider snapTo;

    int childCount;

    // Update is called once per frame
    void Update()
    {
        if(ColliderTarget1.isColliding == true && ColliderTarget2.isColliding == true) 
        {
           GetChildren();
           this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Vehicle")
        {
            snapTo = other;

            childCount = snapTo.transform.childCount;
        }



    }

    private void GetChildren()
    {
        

        for(int i = 0; i < childCount; i++)
        {
            snapTo.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
