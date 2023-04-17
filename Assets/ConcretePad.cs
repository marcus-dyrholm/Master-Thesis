using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcretePad : MonoBehaviour
{
    private Collider snapTo;

    int childCount;

    // Update is called once per frame
    void Update()
    {
        
        
           
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Concrete Pad")
        {
            snapTo = other;

            childCount = snapTo.transform.childCount;

            GetChildren();
            this.transform.parent.gameObject.SetActive(false);

            
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
