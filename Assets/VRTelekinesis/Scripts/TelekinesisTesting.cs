using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
using UnityEngine.Events;

[System.Serializable]
public class TelekinesisTesting : MonoBehaviour
{
    /*
    [SerializeField]
    private LayerMask m_ExclusionLayers;
    [SerializeField]
    private float m_MaxDistance = 100;

    [Range(.05f, 15f)]
    private float m_FollowSpeed = 5;
    [SerializeField]
    [Range(.05f, .2f)]
    private float m_DepthSpeed = .1f;
    [SerializeField]

    public float _additionalForce = 1;

    private bool m_AllowRotate = true;
    public float _rotateSpeed;
    private float finalRot;
    public Hand _teleHand;
    // private SteamVR_Controller.Device _handDevice;
    [SerializeField] bool _telekinesisActive;
    public TelekinesisObject m_ActiveObject;
    private int m_PathParticleCount = 20;
    private Vector3[] m_MagicBeamPoints;
    private GameObject m_ParticleHolder;
    private GameObject m_PathParticle;
    private float m_InitialDrag;
    private float m_InitialAngularDrag;
    [SerializeField] private float m_fDistance;
    private Vector3 m_DropVel;
    private bool m_OriginalGravity;
    private Queue<Vector3> lastPositionQueue = new Queue<Vector3>();
    private float m_LastControllerAngle;

    private BezierCurveRenderer _line;


    private float m_ThrowForce = .15f;


    public event Action<TelekinesisObject> OnAttach;             
    public event Action<TelekinesisObject> OnDetach;            
    public BoolEvent _activeStatus;

    [SerializeField]bool _trigger;
    
    


    void Start()
    {
        m_MagicBeamPoints = new Vector3[3];
        if (GetComponent<BezierCurveRenderer>() != null)
        {
            _line = GetComponent<BezierCurveRenderer>();
        }

        if (_additionalForce < 1)
        {
            _additionalForce = 1;
        }
    }

    void Update()
    {
        if (_teleHand != null)
        {
            transform.position = _teleHand.transform.position;
            transform.rotation = _teleHand.transform.rotation;
            // if (_handDevice == null)
            // {
            //     _handDevice = _teleHand.controller;
            // }
            
        }
    }

    public void OnTelekinesis()
    {
        if (_telekinesisActive)
        {
            _activeStatus.Invoke(true);
            if (_line != null && m_ActiveObject != null)
            {
                _line.Attached(m_ActiveObject.transform);
            }

            m_FollowSpeed = 5 / m_fDistance;

            if (m_AllowRotate)
            {
                float RotateZAmount = Mathf.DeltaAngle(m_LastControllerAngle, transform.eulerAngles.z);
                finalRot = Mathf.Lerp(finalRot, RotateZAmount, _rotateSpeed * Time.deltaTime);
                if (m_ActiveObject != null)
                {

                    m_ActiveObject.transform.Rotate(transform.forward, finalRot, Space.World);
                }
                m_LastControllerAngle = transform.eulerAngles.z;
            }


            if (m_ActiveObject != null)
            {

                m_MagicBeamPoints[0] = transform.position;
                m_MagicBeamPoints[1] = transform.position + (transform.forward * Vector3.Distance(m_ActiveObject.transform.position, transform.position) / 2);
                m_MagicBeamPoints[2] = m_ActiveObject.transform.position;

                Vector3[] Curve = QuadraticBezierCurve(m_MagicBeamPoints[0], m_MagicBeamPoints[1], m_MagicBeamPoints[2], m_PathParticleCount);
            }


            Rigidbody rigidBody = m_ActiveObject.gameObject.GetComponent<Rigidbody>();
            Vector3 targetPos = (transform.position + (transform.forward * m_fDistance));
            float travelDistance = Vector3.Distance(targetPos, m_ActiveObject.transform.position);
            rigidBody.drag = Remap(Mathf.Min(travelDistance, .1f), m_InitialDrag, 5, 5, m_InitialDrag);
            rigidBody.AddForce((targetPos - m_ActiveObject.transform.position) * (travelDistance * m_FollowSpeed) * _additionalForce);
            


            if (!_trigger && !Input.GetMouseButton(0))
            {
                Detach();

            }

            // if (_teleHand.controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            // {
            //     Vector2 touchpad = (_teleHand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));

            //     if (touchpad.y > 0.7f)
            //     {
            //         IncreaseDistance();
            //     }

            //     else if (touchpad.y < -0.7f)
            //     {
            //         DecreaseDistance();
            //     }
            // }

        }
        else
        {
            _activeStatus.Invoke(false);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, m_MaxDistance, ~m_ExclusionLayers))
            {
                if (_trigger)
                {
                    if (hit.collider.gameObject.GetComponent<TelekinesisObject>() != null && hit.collider.gameObject.GetComponent<TelekinesisObject>()._attachedTeleHand == null)
                        Attach(hit.collider.gameObject.GetComponent<TelekinesisObject>());
                }

            }

        }
    }

    private Vector3 GetMeanVector(Queue<Vector3> positions)
    {
        if (positions.Count == 0)
            return Vector3.zero;
        float x = 0f;
        float y = 0f;
        float z = 0f;
        foreach (Vector3 pos in positions)
        {
            x += pos.x;
            y += pos.y;
            z += pos.z;
        }
        return new Vector3(x / positions.Count, y / positions.Count, z / positions.Count);
    }

    private Vector3[] QuadraticBezierCurve(Vector3 origin, Vector3 influence, Vector3 destination, int pointCount)
    {
        Vector3[] result = new Vector3[pointCount];
        if (pointCount == 0)
            return result;

        result[0] = origin;
        for (int i = 1; i < pointCount - 1; i++)
        {
            float percent = (1f / pointCount) * i;
            Vector3 point1 = Vector3.Lerp(origin, influence, percent);
            Vector3 point2 = Vector3.Lerp(influence, destination, percent);
            result[i] = Vector3.Lerp(point1, point2, percent);
        }
        result[pointCount - 1] = destination;

        return result;
    }

    private float Remap(float value, float sourceMin, float sourceMax, float destMin, float destMax)
    {
        return Mathf.Lerp(destMin, destMax, Mathf.InverseLerp(sourceMin, sourceMax, value));
    }

    private void ParticleSetEnabled(bool enable)
    {
    }

    void Attach(TelekinesisObject obj)
    {
        if (!_telekinesisActive)
        {
            if (OnAttach != null)
            {

                OnAttach(m_ActiveObject);
            }


            _telekinesisActive = true;
            m_ActiveObject = obj;

            if (m_ActiveObject != null)
            {
                m_ActiveObject._attachedTeleHand = this;
                Rigidbody rigidBody = m_ActiveObject.gameObject.GetComponent<Rigidbody>();
                m_InitialDrag = rigidBody.drag;
                m_InitialAngularDrag = rigidBody.angularDrag;
                m_OriginalGravity = rigidBody.useGravity;
                rigidBody.angularDrag = float.MaxValue;
                rigidBody.useGravity = false;
                rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;

                
                m_fDistance = Vector3.Distance(m_ActiveObject.transform.position, transform.position);
            }



        }

    }

    public void Detach()
    {
        if (_telekinesisActive)
        {
            if (_line != null)
            {
                _line.Detached();
            }
            _telekinesisActive = false;

            if (m_ActiveObject != null)
            {
                m_ActiveObject._attachedTeleHand = null;

                Rigidbody rigidBody = m_ActiveObject.gameObject.GetComponent<Rigidbody>();

                rigidBody.drag = m_InitialDrag;
                rigidBody.angularDrag = m_InitialAngularDrag;
                rigidBody.useGravity = m_OriginalGravity;
                rigidBody.collisionDetectionMode = CollisionDetectionMode.Discrete;
                m_fDistance = 0f;

                rigidBody.AddForce(m_DropVel.x * m_ThrowForce, m_DropVel.y * m_ThrowForce, m_DropVel.z * m_ThrowForce, ForceMode.Impulse);
            }
            ParticleSetEnabled(false);

            if (OnDetach != null)
                OnDetach(m_ActiveObject);

            m_ActiveObject = null;
            _activeStatus.Invoke(false);
        }
    }

    public void IncreaseDistance()
    {
        if (m_fDistance < 10)
        {

            m_fDistance += 0.1f;
        }
    }
    public void DecreaseDistance()
    {
        if (m_fDistance > 1)
        {

            m_fDistance -= 0.1f;
        }
    }

    public void ButtonTrigger(bool b){
        _trigger = b;
    }
*/
}
