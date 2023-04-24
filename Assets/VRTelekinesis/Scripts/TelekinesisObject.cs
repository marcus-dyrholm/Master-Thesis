using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class TelekinesisObject : MonoBehaviour {

	public Telekinesis _attachedTeleHand;
	[Range (100, 2000)]
	public ushort _hapticStrength = 300;

	public bool frozen = false;

	private bool releasedAfterFrozen;
	void Start () {
		
	}
	
	void Update () {
		
		if(_attachedTeleHand != null){
			// _attachedTeleHand._teleHand.controller.TriggerHapticPulse(_hapticStrength);
		}

		if (_attachedTeleHand == null && frozen)
		{
			releasedAfterFrozen = true;
		}

		if (_attachedTeleHand != null && releasedAfterFrozen)
		{
			frozen = false;
			releasedAfterFrozen = false;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		}
		
		
	}
}
