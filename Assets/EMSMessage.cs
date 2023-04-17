using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMSMessage : MonoBehaviour
{


    public EMSScript EMSScript;
    public EMSScript2 EMSScript2;

    public Telekinesis telekinesisRight;
    public string command_to_stimulate_this_player = "C0I100T1000G";
    private string message_to_stimulate_this_player;

    float time1;
    float timeOut = 0.050f;

    float time2;

    bool channel1Sent, channel2Sent = false;

    int num = 50;




    void Start()
    {
        message_to_stimulate_this_player = command_to_stimulate_this_player;
    }

    public void message()
    {

        EMSScript.sendMessage(message_to_stimulate_this_player);

    }

    void FixedUpdate()
    {
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;
        if (telekinesisRight.m_ActiveObject != null)
        {
            int intensity = Mathf.RoundToInt(map(telekinesisRight.force.y, -200f, 800f, 0, 100));
            int clampedIntensity = Mathf.Clamp(intensity, 0, 100);

            Vector3 inverseTransform = telekinesisRight.transform.InverseTransformDirection(telekinesisRight.force);

            int intensityX = Mathf.RoundToInt(map(inverseTransform.x, -200f, 200f, -100, 100));
            int clampedIntensityX = Mathf.Clamp(intensityX, -100, 100);

            


            if (time1 >= 0.025f && !channel1Sent)
            {
                EMSScript.sendMessage("C0I" + clampedIntensity + "T100G");
                channel1Sent = true;
            }
            else if (time1 >= timeOut)
            {
                EMSScript.sendMessage("C1I" + clampedIntensity + "T100G");
                time1 = 0;
                channel1Sent = false;

            }

            if (time2 >= timeOut)
            {
                if (intensityX >= 20)
                {

                    EMSScript2.sendMessage("C0I" + clampedIntensityX + "T100G");
                    time2 = 0;
                }
                else if (intensityX <= -10)
                {

                    EMSScript2.sendMessage("C1I" + Mathf.Abs(clampedIntensityX) + "T100G");
                    time2 = 0;
                }

                time2 = 0;
            }


            /*   if (intensityX > 10)
              {
                  Debug.Log("Right");
              }
              else if (intensityX < -10)
              {
                  Debug.Log("Left");
              } */


        }


    }

//   C1I50T1000G
//   C1I20T1000G
//   C1I100T1000G

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }





}
