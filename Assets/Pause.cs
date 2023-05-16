using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Pause : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions._default.SetDistanceClose.GetStateUp(inputSource))
        {
            Time.timeScale = 0;
        }

        if (SteamVR_Actions._default.SetDistance.GetStateUp(inputSource))
        {
            Time.timeScale = 1;
        }
    }
}
