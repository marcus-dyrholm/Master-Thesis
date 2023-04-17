using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPipe : MonoBehaviour
{
    public GameObject waterVFX;
    public GameObject fixedJoint;
    public bool waterIsFlowing= false;

    void Update()
    {
        if(fixedJoint.GetComponent<FixedJoint>() == null)
        {
            waterVFX.SetActive(true);
            waterIsFlowing = true;
        }
    }
}
