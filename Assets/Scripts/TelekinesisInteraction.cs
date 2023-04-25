using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
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

    //private static float time;

    public SteamVR_Action_Boolean setdistance; //Grab Pinch is the trigger, select from inspecter
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller

    public TelekinesisInteraction otherHand;


    private Quaternion _initialRotation;
    private Vector3 grabPoint;
    bool isRotating;
    public Transform otherHandObject;
    Transform palm;

    private bool palmOpen;
    private bool coneHitOnObject = false;
    public bool freezeRoutineRunning;
    private RaycastHit[] hits;
    private Physics physics;

    public enum ControllerAsignment
    {
        mainHand,
        offHand,
        either
    }
    
    public ControllerAsignment controllerAsignment;

    public GameObject hitObject;

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
        if (telekinesis.m_ActiveObject != null)
        {
            otherHand.otherHandObject = telekinesis.m_ActiveObject.transform;
        }
        else
        {
            otherHand.otherHandObject = null;
        }
        

        localVelocity = transform.InverseTransformDirection(this.GetComponent<HandPhysics>().handCollider.GetComponent<Rigidbody>().velocity);

        if (telekinesis.m_ActiveObject != null)
        {
            controllerAsignment = ControllerAsignment.mainHand;
            otherHand.controllerAsignment = ControllerAsignment.offHand;
            

            if (telekinesis.m_fDistance >= 0 && distance < maxArmDistance && distance > minArmDistance)
            {
                telekinesis.m_fDistance += map(localVelocity.z, -velocityRange, velocityRange, -velocityNewRange, velocityNewRange);
                //time = 0;
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

            if (!otherHand.isRotating && !telekinesis.m_ActiveObject.frozen)
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
        
        if (controllerAsignment == ControllerAsignment.either || otherHand.controllerAsignment == ControllerAsignment.either || SteamVR_Actions._default.GrabGrip.GetStateUp(inputSource) )
        {
            isRotating = false;
            telekinesis.enabled = true;
        }

        if (SteamVR_Actions._default.GrabGrip.GetStateDown(inputSource) && controllerAsignment == ControllerAsignment.offHand)
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

        if (controllerAsignment == ControllerAsignment.either)
        {
            otherHandObject = null;
        }

        if (telekinesis.m_ActiveObject == null && otherHandObject == null)
        {
            controllerAsignment = ControllerAsignment.either;
        }





        //telekinesis.m_fDistance = map(localVelocity.z, -10, 10, -0.1f, 0.1f);
    }

    private void FixedUpdate()
    {
        if (inputSource == SteamVR_Input_Sources.LeftHand && controllerAsignment == ControllerAsignment.offHand)
        {
            
            SteamVR_Behaviour_Skeleton skeleton = player.hands[0].skeleton;
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
                hits = physics.ConeCastAll(transform.position, 50, transform.TransformDirection(Vector3.right), 100, 5);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right)* 100, Color.red);

                foreach (var hit in hits)
                {
                    coneHitOnObject = false;
                    if (hit.collider.CompareTag("Telekinesis Object"))
                    {
                        coneHitOnObject = true;
                        hitObject = hit.transform.gameObject;
                        break;
                    }
                }
                
                if (coneHitOnObject && !freezeRoutineRunning)
                {
                    try
                    {
                        otherHandObject = otherHand.telekinesis.m_ActiveObject.transform;
                        StartCoroutine(FreezeObject(hitObject));
                    }
                    catch (NullReferenceException e)
                    {
                        freezeRoutineRunning = false;
                        Console.WriteLine(e);
                    }
                    
                }
            }

        }
        else if (inputSource == SteamVR_Input_Sources.RightHand && controllerAsignment == ControllerAsignment.offHand )
        {
            
            SteamVR_Behaviour_Skeleton skeleton = player.hands[1].skeleton;
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
                hits = physics.ConeCastAll(transform.position, 50, transform.TransformDirection(Vector3.left), 100, 5);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left)* 100, Color.red);

                foreach (var hit in hits)
                {
                    coneHitOnObject = false;
                    if (hit.collider.CompareTag("Telekinesis Object"))
                    {
                        coneHitOnObject = true;
                        hitObject = hit.transform.gameObject;
                        break;
                    }
                }
                
                if (coneHitOnObject && !freezeRoutineRunning)
                {
                    try
                    {
                        otherHandObject = otherHand.telekinesis.m_ActiveObject.transform;
                        StartCoroutine(FreezeObject(hitObject));
                    }
                    catch (NullReferenceException e)
                    {
                        freezeRoutineRunning = false;
                        Console.WriteLine(e);
                    }
                    
                }
            }
        }
    }

    private IEnumerator FreezeObject(GameObject obj)
    {
        freezeRoutineRunning = true;
        float time = 0;
        if (otherHandObject != null)
        {
            TelekinesisObject telekinesisObject = otherHand.telekinesis.m_ActiveObject;
            GameObject tObject = otherHandObject.gameObject;

            if (telekinesisObject.frozen)
            {
                freezeRoutineRunning = false;
                yield break;
            }
                

            GameObject sliderCanvas = GameObject.FindWithTag("Slider Canvas");
            Slider slider = sliderCanvas.GetComponentInChildren<Slider>(includeInactive: true);
            slider.GetComponentInParent<Canvas>(includeInactive: true).enabled = true;
            
            if (ReferenceEquals(obj, tObject) && tObject != null)
            {
                while (time < 1 && ReferenceEquals(obj, hitObject))
                {
                    slider.value = time;
                    sliderCanvas.transform.position = tObject.transform.position;
                    time += Time.deltaTime;
                    yield return null;
                }
                
                if (time >= 1)
                {
                    Rigidbody rb = obj.GetComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    telekinesisObject.frozen = true;
                }
                slider.GetComponentInParent<Canvas>(includeInactive: true).enabled = false;
            }
        }

        freezeRoutineRunning = false;
        yield return null;
    }
    
    

    private Vector3 initialForward;
    private Vector3 startPos;
    private Quaternion currentRot;
    public void Rotate()
    {

        
        Vector3 handDirection = Vector3.Normalize(transform.position - otherHand.transform.position);
        //Quaternion lookRotation =  //Quaternion.LookRotation(handDirection, Vector3.up);
        //Quaternion finalRotation = Quaternion.Euler(Vector3.Cross(lookRotation.eulerAngles,  _initialRotation.eulerAngles));
       // otherHandObject.rotation = lookRotation * quaternion.Euler(initialForward);
        otherHandObject.rotation = Quaternion.FromToRotation(startPos, handDirection) * currentRot;

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
            
            
            startPos = Vector3.Normalize(transform.position - otherHand.transform.position);
            currentRot = otherHandObject.rotation;
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
