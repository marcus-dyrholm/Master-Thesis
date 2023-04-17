using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMassManager : MonoBehaviour
{

    public Vector3 _centerOfMass;
	public Transform _centerOfMassWithTransform;
    private Rigidbody _rigidBody;

    void Start()
    {
		_rigidBody = GetComponent<Rigidbody>();
		if(_centerOfMassWithTransform == null){

		_rigidBody.centerOfMass = _centerOfMass;
		}else{
			_rigidBody.centerOfMass = _centerOfMassWithTransform.localPosition;
		}
    }
}
