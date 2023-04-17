using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguish : MonoBehaviour
{
    private bool decreaseFire = false;
    private float time = 10;

    // Update is called once per frame
    void Update()
    {
        if (decreaseFire)
        {
            time -= (Time.deltaTime * 6);
            transform.localScale = new Vector3(time,time,time);
            if (time <= 1)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            if (other.GetComponent<WaterFill>().waterIsActive)
            {
                decreaseFire = true;
            }
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        decreaseFire = false;
    }
}
