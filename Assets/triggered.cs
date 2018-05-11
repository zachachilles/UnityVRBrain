using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggered : MonoBehaviour {
    public GameObject[] a;
    public Color32 col;
    public Material mat;
    public Material transparent;
    public GameObject lh;
    public GameObject rh;
	// Use this for initialization
	void Start () {
        this.gameObject.AddComponent<resetScript>();
        resetScript r = this.GetComponent<resetScript>();
    }
	
	// Update is called once per frame
	void Update () {
        resetScript r = this.GetComponent<resetScript>();
		if(this.gameObject.transform.position != r.returninitPos() || this.gameObject.transform.rotation !=r.returnRot())
        {
            highlightRegions(lh);
            highlightRegions(rh);
            resetScript res = this.gameObject.GetComponent<resetScript>();
            res.resetPos();
        }
        
	}
    public void highlightRegions(GameObject t)
    {
        for(int i = 0; i<a.Length; i++)
        {
            Transform child = a[i].transform.GetChild(0);

        //    child.GetComponent<Renderer>().material = (Material)Instantiate(mat);
            child.GetComponent<Renderer>().material.color = col;
            resetColor c = child.GetComponent<resetColor>();
            c.initialColor();

        }
        for(int i = 0; i < t.transform.childCount; i++)
        {
            Transform child = t.transform.GetChild(i);
            bool contains = false;
            for(int x = 0; x < a.Length; x++)
            {
                if (child.name == a[x].transform.name)
                {
                    contains = true;
                }
            }
            if (!contains)
            {
                child.GetChild(0).GetComponent<Renderer>().material = transparent;
                States s = child.GetChild(0).GetComponent<States>();
                resetColor c = child.GetChild(0).GetComponent<resetColor>();
                c.initialColor();
                s.setTransparent(true);
            }
        }
    }
}
