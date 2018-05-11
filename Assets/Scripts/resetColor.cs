using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetColor : MonoBehaviour {
    private Color initCol;
    private Shader initShad;
    private bool orig;
	// Use this for initialization
	void Start () {
        orig = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void initialColor()
    {
        initCol = this.transform.GetComponent<MeshRenderer>().material.color;
        initShad = this.transform.GetComponent<MeshRenderer>().material.shader;
    }
    public void setColor()
    {
        this.transform.GetComponent<MeshRenderer>().material.color = initCol;
        this.transform.GetComponent<MeshRenderer>().material.shader = initShad;
    }
    public bool originalColor()
    {
        return orig;
    }
    public void colorSet()
    {
        if (orig)
        {
            orig = false;
        }
        else
        {
            orig = true;
        }
    }
}
