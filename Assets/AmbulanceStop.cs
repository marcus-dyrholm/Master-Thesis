using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceStop : MonoBehaviour
{
    public bool isInTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Ambulance>().speed = 0;
        isInTrigger = true;
    }
}
