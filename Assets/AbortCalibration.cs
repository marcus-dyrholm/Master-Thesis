using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbortCalibration : MonoBehaviour
{

    public Toggle[] Toggles;
    public Slider[] Sliders;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 3; i++)
            {
                Toggles[i].isOn = false;
                Sliders[i].value = 0;
            }
        }
    }
}
