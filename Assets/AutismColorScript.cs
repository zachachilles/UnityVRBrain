using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutismColorScript : MonoBehaviour {
    GameObject thisObject;
    public Material culloff;

    // Use this for initialization
    void Start () {
        thisObject = this.gameObject;
        int childNum = thisObject.transform.childCount;
        for (int i = 0; i < childNum; i++)
        {
            Transform child = thisObject.transform.GetChild(i);
            Transform newchild = child.GetChild(0);
            newchild.gameObject.AddComponent<Rigidbody>();
            newchild.gameObject.GetComponent<Rigidbody>().useGravity = true;
            newchild.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            newchild.gameObject.AddComponent<MeshCollider>();
            //  newchild.gameObject.GetComponent<SphereCollider>().radius = 4;
            newchild.transform.name = child.name;
     //       newchild.GetComponent<MeshRenderer>().material = culloff;

            //for adding original position script
            newchild.gameObject.AddComponent<resetScript>();
            newchild.gameObject.AddComponent<resetColor>();
            resetScript go = newchild.GetComponent<resetScript>();
            resetColor col = newchild.GetComponent<resetColor>();
            col.initialColor();
            go.initialPosition();


        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
