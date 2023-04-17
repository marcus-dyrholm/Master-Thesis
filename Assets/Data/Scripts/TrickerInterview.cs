using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickerInterview : MonoBehaviour
{
    public GameObject Data;
    // Start is called before the first frame update
    void Start()
    {
        Data.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ambulance")
        {
            Data.SetActive(true);
        }

    }
}
