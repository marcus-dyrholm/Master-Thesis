using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class TelekinesisObject : MonoBehaviour {

	public Telekinesis _attachedTeleHand;
	[Range (100, 2000)]
	public ushort _hapticStrength = 300;
	void Start () {
		
	}
	
	void Update () {
		
		if(_attachedTeleHand != null){
			// _attachedTeleHand._teleHand.controller.TriggerHapticPulse(_hapticStrength);
		}
	}
}
