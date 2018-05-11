using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHColor : MonoBehaviour {
    GameObject thisObject;
    public Material culloff;
   // public resetScript reset;
    // Use this for initialization
    void Start()
    {
        thisObject = this.gameObject;
        int childNum = thisObject.transform.childCount;
        for(int i = 0; i < childNum; i++)
        {
            Transform child = thisObject.transform.GetChild(i);
            Transform newchild = child.GetChild(0);
            newchild.gameObject.AddComponent<Rigidbody>();
            newchild.gameObject.GetComponent<Rigidbody>().useGravity = true;
            newchild.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            newchild.gameObject.AddComponent<MeshCollider>();
          //  newchild.gameObject.GetComponent<SphereCollider>().radius = 4;
            newchild.transform.name = child.name;
            newchild.GetComponent<MeshRenderer>().material = culloff;

            //for adding original position script
            newchild.gameObject.AddComponent<resetScript>();
            newchild.gameObject.AddComponent<resetColor>();
            newchild.gameObject.AddComponent<RenameScript>();
            newchild.gameObject.AddComponent<States>();  
            resetScript go = newchild.GetComponent<resetScript>();
            RenameScript rename = newchild.GetComponent<RenameScript>();
            go.initialPosition();
 

        }
        for (int i = 0; i < childNum; i++)
        {
            Transform child= thisObject.transform.GetChild(i);
            Transform newchild = child.GetChild(0);
            if (child.name == "lh.bankssts")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(25,100,40,0 );
            }
            else if (child.name == "lh.caudalanteriorcingulate")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(125,100,160,0);
            }
            else if (child.name == "lh.caudalmiddlefrontal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(100, 25, 0, 0);
            }
            else if (child.name == "lh.corpuscallosum")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(120, 70, 50, 0);
            }
            else if (child.name == "lh.cuneus")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 20, 100, 0);

            }
            else if (child.name == "lh.entorhinal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 20, 10, 0);
            }
            else if (child.name == "lh.fusiform")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(180, 220, 140, 0);
            }
            else if (child.name == "lh.inferiorparietal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 60, 220, 0);
            }
            else if (child.name == "lh.inferiortemporal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(180, 40, 120,0);
            }
            else if (child.name == "lh.isthmuscingulate")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(140, 20, 140, 0);

            }
            else if (child.name == "lh.lateraloccipital")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(20, 30, 140, 0);
            }
            else if (child.name == "lh.lateralorbitofrontal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(35, 75, 50, 0);
            }
            else if (child.name == "lh.lingual")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(225, 140, 140, 0);
            }
            else if (child.name == "lh.medialorbitofrontal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(200, 35, 75, 0);
            }
            else if (child.name == "lh.middletemporal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(160, 100, 50, 0);
            }
            else if (child.name == "lh.parahippocampal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(20, 220, 60, 0);
            }
            else if (child.name == "lh.paracentral")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(60, 220, 60, 0);
            }
            else if (child.name == "lh.parsopercularis")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 180, 140, 0);
            }
            else if (child.name == "lh.parsorbitalis")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(20, 100, 50, 0);
            
            }
            else if (child.name == "lh.parstriangularis")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 60, 20, 0);
            }
            else if (child.name == "lh.pericalcarine")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(120, 100, 60, 0);
            }
            else if (child.name == "lh.postcentral")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 20, 20, 0);
            }
            else if (child.name == "lh.posteriorcingulate")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 180, 220, 0);
            }
            else if (child.name == "lh.precentral")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(60, 20, 220, 0);
            }
            else if (child.name == "lh.precuneus")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(160, 140, 180, 0);
            }
            else if (child.name == "lh.rostralanteriorcingulate")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(80, 20, 140, 0);
            }
            else if (child.name == "lh.rostralmiddlefrontal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(75, 50, 125, 0);
            }
            else if (child.name == "lh.superiorfrontal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(20, 220, 160, 0);
            }
            else if (child.name == "lh.superiorparietal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(20, 180, 140, 0);
            }
            else if (child.name == "lh.superiortemporal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(140, 220, 220, 0);
            }
            else if (child.name == "lh.supramarginal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(80, 160, 20, 0);
            }
            else if (child.name == "lh.frontalpole")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(100, 0, 100, 0);
            }
            else if (child.name == "lh.temporalpole")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(70, 70, 70, 0);
            }
            else if (child.name == "lh.transversetemporal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(150, 150, 200, 0);
            }
            else if (child.name == "lh.insula")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(255, 192, 32, 0);
            }
            else if (child.name == "lh.unlabelled")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(25, 5, 25, 0);
            }
            resetColor col = newchild.GetComponent<resetColor>();
            RenameScript rename = newchild.GetComponent<RenameScript>();
            col.initialColor();
            newchild.name=rename.reName(newchild.name,"Left");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
