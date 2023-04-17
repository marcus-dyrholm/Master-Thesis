using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=tBYl-aSxUe0&t=1s&ab_channel=Valem 11:33 To Connect to VR
[System.Serializable]
public class VRMap //New class
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }

}

public class VRRig : MonoBehaviour
{
    [SerializeField]
    private float turnSmoothness = 5;
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstrainst;
    public Vector3 headBodyOffset;

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headConstrainst.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Position
        transform.position = headConstrainst.position + headBodyOffset;
        //Rotation
        transform.forward = Vector3.Lerp(transform.forward,
            Vector3.ProjectOnPlane(headConstrainst.up, Vector3.up).normalized,Time.deltaTime* turnSmoothness);
        transform.forward = Vector3.ProjectOnPlane(headConstrainst.up, Vector3.up).normalized;

        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
