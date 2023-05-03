using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GoGoController : MonoBehaviour {

    public enum EIndex
    {
        None = -1,
        Hmd = (int)OpenVR.k_unTrackedDeviceIndex_Hmd,
        Device1,
        Device2,
        Device3,
        Device4,
        Device5,
        Device6,
        Device7,
        Device8,
        Device9,
        Device10,
        Device11,
        Device12,
        Device13,
        Device14,
        Device15
    }

    public EIndex index;
    public Transform origin; // if not set, relative to parent
    public bool isValid = false;
    public SteamVR_Input_Sources Controller = SteamVR_Input_Sources.Any;
    // 1
    public GameObject collidingObject;
    // 2
    private GameObject objectInHand = null; 

    private void OnNewPoses(TrackedDevicePose_t[] poses)
    {
        if (index == EIndex.None)
            return;

        var i = (int)index;

        isValid = false;
        if (poses.Length <= i)
            return;

        if (!poses[i].bDeviceIsConnected)
            return;

        if (!poses[i].bPoseIsValid)
            return;

        isValid = true;

        var pose = new SteamVR_Utils.RigidTransform(poses[i].mDeviceToAbsoluteTracking);
        var HMDpose = new SteamVR_Utils.RigidTransform(poses[(int)EIndex.Hmd].mDeviceToAbsoluteTracking);

        if (origin != null)
        {

            transform.position = origin.transform.TransformPoint(pose.pos);
            transform.rotation = origin.rotation * pose.rot;
        }
        else
        {
            var distance = Vector3.Distance(HMDpose.pos, pose.pos);
            
            if (distance > threshold)
            {
                if (initPose == Vector3.zero)
                {
                    Debug.LogError("Initiate controller Pos");
                    transform.localPosition = pose.pos;
                    transform.localRotation = pose.rot;
                    return;
                }

                float k =  25;
                var diffPos =  pose.pos - initPose ;
                diffPos *= (1f + k*Mathf.Pow(distance,2));
                //print((1f + k * Mathf.Pow(distance, 2)));
              //  print(Mathf.Pow((Mathf.Abs(diff.z) - threshold), 2));
                pose.pos += diffPos;

            }

            transform.localPosition = pose.pos;
            transform.localRotation = pose.rot;

        }
    }

    SteamVR_Events.Action newPosesAction;
    private float threshold = 0.2f;
    public Vector3 initPose = Vector3.zero;
    private Vector3 m_DropVel;
    private float m_ThrowForce = 0.15f;
    private float m_InitialDrag;
    private bool m_OriginalGravity;
    private readonly float m_InitialAngularDrag;

    void Awake()
    {
        newPosesAction = SteamVR_Events.NewPosesAction(OnNewPoses);
    }

    void OnEnable()
    {
        var render = SteamVR_Render.instance;
        if (render == null)
        {
            enabled = false;
            return;
        }

        newPosesAction.enabled = true;
    }

    void OnDisable()
    {
        newPosesAction.enabled = false;
        isValid = false;
    }
    /*
    public void SetDeviceIndex(int index)
    {
        if (System.Enum.IsDefined(typeof(EIndex), index))
            this.index = (EIndex)index;
    }

    private SteamVR_Input_Sources.Hand Controller
    {
        get { return SteamVR_Controller.Input((int)index); }
        SteamVR
    }
    */
    void Update()
    {
        if (initPose == Vector3.zero && SteamVR_Actions.default_InteractUI.GetStateDown(Controller))
        {
            initPose = transform.localPosition;
            return;
        }

        if (SteamVR_Actions.default_InteractUI.GetStateDown(Controller))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        // 2
        if (SteamVR_Actions.default_InteractUI.GetStateUp(Controller))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }

        if (SteamVR_Actions.default_SetDistanceClose.GetStateDown(Controller))
        {
            initPose = Vector3.zero;
        }
    }

   


    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    // 1
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

        Rigidbody rigidBody = objectInHand.gameObject.GetComponent<Rigidbody>();

        rigidBody.drag = m_InitialDrag;
        rigidBody.angularDrag = m_InitialAngularDrag;
        rigidBody.useGravity = m_OriginalGravity;
        rigidBody.collisionDetectionMode = CollisionDetectionMode.Discrete;
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (objectInHand != null && GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            Rigidbody rigidBody = objectInHand.GetComponent<Rigidbody>();

            rigidBody.drag = m_InitialDrag;
            rigidBody.angularDrag = m_InitialAngularDrag;
            rigidBody.useGravity = !m_OriginalGravity;
            rigidBody.collisionDetectionMode = CollisionDetectionMode.Discrete;
            //m_fDistance = 0f;

            rigidBody.AddForce(m_DropVel.x * m_ThrowForce, m_DropVel.y * m_ThrowForce, m_DropVel.z * m_ThrowForce, ForceMode.Impulse);
        }
        /*
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        // 4
        objectInHand = null;
        */
    }
}
