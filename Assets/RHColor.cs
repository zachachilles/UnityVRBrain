using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RHColor : MonoBehaviour {
    GameObject thisObject;
    Component FlipMesh;
    public FlipMesh flipmesh;
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
           // newchild.gameObject.GetComponent<SphereCollider>().radius = 4;
            newchild.transform.name = child.name;
            newchild.GetComponent<MeshRenderer>().material = culloff;
            // newchild.gameObject.AddComponent<FlipMesh>();
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
            Transform child = thisObject.transform.GetChild(i);
            Transform newchild = child.GetChild(0);
            if (child.name == "rh.bankssts")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(25, 100, 40, 0);
                
            }
            else if (child.name == "rh.caudalanteriorcingulate")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(125, 100, 160, 0);
            }
            else if (child.name == "rh.caudalmiddlefrontal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(100, 25, 0, 0);
            }
            else if (child.name == "rh.corpuscallosum")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(120, 70, 50, 0);
            }
            else if (child.name == "rh.cuneus")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 20, 100, 0);

            }
            else if (child.name == "rh.entorhinal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 20, 10, 0);
            }
            else if (child.name == "rh.fusiform")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(180, 220, 140, 0);
            }
            else if (child.name == "rh.inferiorparietal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 60, 220, 0);
            }
            else if (child.name == "rh.inferiortemporal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(180, 40, 120, 0);
            }
            else if (child.name == "rh.isthmuscingulate")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(140, 20, 140, 0);

            }
            else if (child.name == "rh.lateraloccipital")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(20, 30, 140, 0);
            }
            else if (child.name == "rh.lateralorbitofrontal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(35, 75, 50, 0);
            }
            else if (child.name == "rh.lingual")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(225, 140, 140, 0);
            }
            else if (child.name == "rh.medialorbitofrontal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(200, 35, 75, 0);
            }
            else if (child.name == "rh.middletemporal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(160, 100, 50, 0);
            }
            else if (child.name == "rh.parahippocampal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(20, 220, 60, 0);
            }
            else if (child.name == "rh.paracentral")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(60, 220, 60, 0);
            }
            else if (child.name == "rh.parsopercularis")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 180, 140, 0);
            }
            else if (child.name == "rh.parsorbitalis")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(20, 100, 50, 0);

            }
            else if (child.name == "rh.parstriangularis")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 60, 20, 0);
            }
            else if (child.name == "rh.pericalcarine")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(120, 100, 60, 0);
            }
            else if (child.name == "rh.postcentral")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 20, 20, 0);
            }
            else if (child.name == "rh.posteriorcingulate")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(220, 180, 220, 0);
            }
            else if (child.name == "rh.precentral")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(60, 20, 220, 0);
            }
            else if (child.name == "rh.precuneus")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(160, 140, 180, 0);
            }
            else if (child.name == "rh.rostralanteriorcingulate")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(80, 20, 140, 0);
            }
            else if (child.name == "rh.rostralmiddlefrontal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(75, 50, 125, 0);
            }
            else if (child.name == "rh.superiorfrontal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(20, 220, 160, 0);
            }
            else if (child.name == "rh.superiorparietal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(20, 180, 140, 0);
            }
            else if (child.name == "rh.superiortemporal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(140, 220, 220, 0);
            }
            else if (child.name == "rh.supramarginal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(80, 160, 20, 0);
            }
            else if (child.name == "rh.frontalpole")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(100, 0, 100, 0);
            }
            else if (child.name == "rh.temporalpole")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(70, 70, 70, 0);
            }
            else if (child.name == "rh.transversetemporal")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(150, 150, 200, 0);
            }
            else if (child.name == "rh.insula")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(255, 192, 32, 0);
            }
            else if (child.name == "rh.unlabelled")
            {
                newchild.GetComponent<MeshRenderer>().material.color = new Color32(25, 5, 25, 0);
            }
            resetColor col = newchild.GetComponent<resetColor>();
            RenameScript rename = newchild.GetComponent<RenameScript>();
            newchild.name = rename.reName(newchild.name, "Right");
            col.initialColor();
        }
    }

}

// Update is called once per frame

