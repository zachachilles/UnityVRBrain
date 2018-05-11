using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPrinter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        print(other.GetComponent<Collider>().name);
    }
}
