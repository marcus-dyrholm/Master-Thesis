using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public GameObject TheEnd;

    // Start is called before the first frame update
    void Start()
    {
        TheEnd.SetActive(false);

    }

    // Update is called once per frame


    public void SeeNum()
    {
        TheEnd.SetActive(true);
    }

}
