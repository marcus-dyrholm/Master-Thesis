using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class VelocityTesting : MonoBehaviour
{

    public Telekinesis telekinesis;
    public Player player;
    private Transform handPos;
    private GameObject hand;
    public Vector3 localVelocity;
    public float distance;
    public float maxArmDistance;
    public float minArmDistance;
    public float distanceScalar;
    public float velocityRange;
    public float velocityNewRange;

    public float distanceSpeed;
    private float acv = 30;

    private Vector3 velocity = Vector3.zero;

    private GameObject _player;

    private static float time;

    public SteamVR_Action_Boolean setdistance; //Grab Pinch is the trigger, select from inspecter
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("RightShoulder");
        //maxArmDistance = PlayerPrefs.GetFloat("MaxArmDistance");
        //minArmDistance = PlayerPrefs.GetFloat("MinArmDistance");

    }

    private void Update()
    {
        distance = Vector3.Distance(this.transform.position, _player.transform.position);
        //Debug.Log(distance);

        localVelocity = transform.InverseTransformDirection(this.GetComponent<HandPhysics>().handCollider.GetComponent<Rigidbody>().velocity);
        /*
                if (telekinesis.m_ActiveObject!= null && localVelocity.z >1)
                {
                    //telekinesis.m_ActiveObject.GetComponent<Rigidbody>().AddForce(Vector3.forward);
                    telekinesis.m_fDistance += 1;
                    Debug.Log("throwing");
                }
        */

        if (telekinesis.m_ActiveObject != null)
        {
            if (telekinesis.m_fDistance >= 0 && distance < maxArmDistance && distance > minArmDistance)
            {
                telekinesis.m_fDistance += map(localVelocity.z, -velocityRange, velocityRange, -velocityNewRange, velocityNewRange);
                time = 0;
            }

            if (distance >= maxArmDistance)
            {
                telekinesis.m_fDistance += distanceSpeed;
                //Debug.Log("aboveDistance");
            }

            if (distance <= minArmDistance && telekinesis.m_fDistance > 0)
            {
                telekinesis.m_fDistance -= distanceSpeed;
                /*
                time += 0.5f * Time.deltaTime;
                float lerpSpeed = Mathf.Lerp(10,1,time);
                Debug.Log(lerpSpeed);
                telekinesis.m_ActiveObject.transform.position = Vector3.SmoothDamp(telekinesis.m_ActiveObject.transform.position, _player.transform.position, ref velocity, lerpSpeed);
                telekinesis.m_fDistance = Vector3.Distance(telekinesis.m_ActiveObject.transform.position, _player.transform.position); 
                float newSpeed = telekinesis.m_fDistance * distanceSpeed;
                */
            }

            if (telekinesis.m_fDistance <= 0)
            {
                //telekinesis.m_fDistance -= map(localVelocity.z, -velocityRange, velocityRange, -velocityNewRange, velocityNewRange);
                telekinesis.m_fDistance = 0;
            }

        }

        if (SteamVR_Actions._default.SetDistance.GetStateDown(SteamVR_Input_Sources.Any))
        {
            distanceSet();
        }
        if (SteamVR_Actions._default.SetDistanceClose.GetStateDown(SteamVR_Input_Sources.Any))
        {
            distanceCloseSet();
        }






        //telekinesis.m_fDistance = map(localVelocity.z, -10, 10, -0.1f, 0.1f);
    }

    private void distanceSet()
    {
        maxArmDistance = Vector3.Distance(this.transform.position, _player.transform.position);
        maxArmDistance -= distanceScalar;
        Debug.Log("max arm distance = " + maxArmDistance);
        //PlayerPrefs.SetFloat("MaxArmDistance", maxArmDistance);
    }

    private void distanceCloseSet()
    {
        minArmDistance = Vector3.Distance(this.transform.position, _player.transform.position);
        minArmDistance += distanceScalar;
        Debug.Log("min arm distance = " + minArmDistance);
        //PlayerPrefs.SetFloat("MinArmDistance", minArmDistance);
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }


}
