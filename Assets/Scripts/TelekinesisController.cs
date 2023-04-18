using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TelekinesisController : MonoBehaviour
{
    public Player player;

    public bool palmOpen = false;

    public TelekinesisInteraction left, right;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.hands[1].transform.localEulerAngles.normalized);
        if (player.hands[0] != null)
        {
            SteamVR_Behaviour_Skeleton skeleton = Player.instance.hands[0].skeleton;

            foreach(var fingerCurl in skeleton.fingerCurls)
            {
                palmOpen = false;
                if (fingerCurl <= 0.1)
                {
                    palmOpen = true;
                }
            }

            if (palmOpen == true)
            {
                Debug.Log("Palm open");
            }
            
        }
    }
}
