using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetScript : MonoBehaviour {
    private Vector3 initpos;
    private Quaternion initrot;
    private bool activated;
    private Transform ogParent;
	// Use this for initialization
	void Start () {
        activated = false;
        this.initialPosition(); //just added this when trying to get trigger from movement
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.transform.rotation == initrot && this.gameObject.transform.position == initpos)
        {
            activated = false;
        }
        if (activated)
        {
            resetPos();
        }
	}
   public void initialPosition()
    {
        Transform thistransform = this.gameObject.transform;
        initpos = thistransform.position;
        initrot = thistransform.rotation;
        ogParent = thistransform.parent;
    }
    public void resetPos()
    {
        this.transform.parent = transform;
        this.transform.rotation = Quaternion.RotateTowards(this.gameObject.transform.rotation, initrot, 0.25f);
        this.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, initpos, 0.05f);
            //   this.transform.rotation = Quaternion.RotateTowards(this.gameObject.transform.rotation, initrot, 0.25f); 
        

        Transform thistransform = this.gameObject.transform;

   //     thistransform.position = initpos;
   //     thistransform.rotation = initrot;

    }
    public void activate()
    {
        activated = true;
    }
    public Vector3 returninitPos()
    {
        return initpos;
    }
    public Quaternion returnRot()
    {
        return initrot;
    }
    public void resetParent()
    {
        this.transform.parent = ogParent;
    }

}
