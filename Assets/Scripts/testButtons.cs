using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            print("primary thumbstick down");
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick))
        {
            print("secondary thumbstick down");
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            print("secondary index trigger");
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            print("primary index trigger");
        }
        if (Input.GetButton("Oculus_GearVR_LIndexTrigger")){
            print("trigger");
        }
        if (Input.GetButton("Oculus_GearVR_RIndexTrigger"))
        {
            print("indextrogger");
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
        {
            print("bitton One");
        }
	}
}
