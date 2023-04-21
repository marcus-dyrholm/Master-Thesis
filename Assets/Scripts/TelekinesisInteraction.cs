using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TelekinesisInteraction : MonoBehaviour
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

    public TelekinesisInteraction otherHand;


    private Quaternion _initialRotation;
    private Vector3 grabPoint;
    bool isRotating;
    private Transform otherHandObject;
    Transform palm;

    public enum ControllerAsignment
    {
        mainHand,
        offHand,
        either
    }
    
    public ControllerAsignment controllerAsignment;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("RightShoulder");
        controllerAsignment = ControllerAsignment.either;
        telekinesis.telekinesisEnded.AddListener(ResetControllerStates);
        //maxArmDistance = PlayerPrefs.GetFloat("MaxArmDistance");
        //minArmDistance = PlayerPrefs.GetFloat("MinArmDistance");

    }

    private void Update()
    {
        distance = Vector3.Distance(this.transform.position, _player.transform.position);
        //Debug.Log(distance);

        localVelocity = transform.InverseTransformDirection(this.GetComponent<HandPhysics>().handCollider.GetComponent<Rigidbody>().velocity);

        if (telekinesis.m_ActiveObject != null)
        {
            controllerAsignment = ControllerAsignment.mainHand;
            otherHand.controllerAsignment = ControllerAsignment.offHand;

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

            //Rotation

            if (!otherHand.isRotating)
            {
                GameObject ActiveGO = telekinesis.m_ActiveObject.gameObject;
            
                Vector3 playerToObject = ActiveGO.transform.position - player.transform.position;
                float rotationAngle = transform.rotation.eulerAngles.z;
                if (rotationAngle > 180)
                {
                    rotationAngle -= 360;
                }
                ActiveGO.transform.RotateAround(ActiveGO.transform.position, playerToObject, rotationAngle * 2 * Time.deltaTime);
            }

        }
        
        if (controllerAsignment == ControllerAsignment.either || otherHand.controllerAsignment == ControllerAsignment.either || SteamVR_Actions._default.GrabPinch.GetStateUp(inputSource) )
        {
            isRotating = false;
            telekinesis.enabled = true;
        }

        if (SteamVR_Actions._default.GrabPinch.GetStateDown(inputSource) && controllerAsignment == ControllerAsignment.offHand)
        {
            GrabbedForRotation();
        }
        
        if (controllerAsignment == ControllerAsignment.offHand && isRotating)
        {
            telekinesis.enabled = false;
            Rotate();
        }

        if (SteamVR_Actions._default.SetDistance.GetStateDown(inputSource))
        {
            distanceSet();
        }
        if (SteamVR_Actions._default.SetDistanceClose.GetStateDown(inputSource))
        {
            distanceCloseSet();
        }








        //telekinesis.m_fDistance = map(localVelocity.z, -10, 10, -0.1f, 0.1f);
    }

    private Vector3 initialForward;
    public void Rotate()
    {
        
        
        Vector3 handDirection = palm.position - otherHand.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(handDirection, Vector3.up);
        //Quaternion finalRotation = Quaternion.Euler(Vector3.Cross(lookRotation.eulerAngles,  _initialRotation.eulerAngles));
        otherHandObject.rotation = lookRotation * quaternion.Euler(initialForward);

    }

    public void GrabbedForRotation()
    {
        if (controllerAsignment == ControllerAsignment.offHand)
        {
            
            // Get the rotation for the grabbed object from the other hand
            otherHandObject = otherHand.telekinesis.m_ActiveObject.transform;
            _initialRotation = otherHandObject.rotation;
            palm = this.GetComponent<HandPhysics>().handCollider.transform.GetChild(0).GetChild(3);
            initialForward = otherHandObject.forward;
            grabPoint = palm.GetComponent<Collider>().ClosestPoint(otherHand.transform.position);
            isRotating = true;
        }

    }

    public void ResetControllerStates()
    {
        controllerAsignment = ControllerAsignment.either;
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
