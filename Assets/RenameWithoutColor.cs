using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenameWithoutColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.AddComponent<RenameScript>();
        RenameScript ren = this.gameObject.GetComponent<RenameScript>();
        int childNum = this.gameObject.transform.childCount;
        for(int i = 0; i<childNum; i++)
        {
            Transform child = this.gameObject.transform.GetChild(i);
            Transform newChild = child.GetChild(0);
            string hemisphere;
            if (this.gameObject.name.Contains("LH"))
            {
                hemisphere = "Left";
            }
            else 
            {
                hemisphere = "Right";
            }
            child.name = ren.reName(child.name, hemisphere);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
