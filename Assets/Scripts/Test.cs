using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour {
    public GameObject me;
    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "hello";
    //    string child = me.transform.GetComponentInChildren<GUIText>().text;
    //    child = "Hello";
     //   me.transform.GetComponentInChildren<GUIText>().text = "Hello";
    //    Canvas can = parent.GetComponentInParent<Canvas>();
    //   can.GetComponent<GUIText>().text = "Hello";
    //      this.GetComponentInParent.GetComponentInParent<Canvas>();

    }
}
