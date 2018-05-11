using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Hand : MonoBehaviour
{
    public Text text;

    public OVRInput.Controller controller;
    public string buttonName;

    public float grabRadius;
    public LayerMask grabMask;

    public GameObject grabbedObject;
    private bool grabbing;

    private Quaternion lastRotation, currentRotation;
    public Shader original;

    public bool holding;
    public Shader shade;

    public Hand neighbor;
    public Transform parent;
    public void GrabObject()
    {

        grabbing = true;
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);
        if (hits.Length > 0)
        {
            int closestHit = 0;

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].distance < hits[closestHit].distance) closestHit = i;
            }

            grabbedObject = hits[closestHit].transform.gameObject;
            if (!grabbedObject.GetComponent<States>().isTransparent())
            {


                if (grabbedObject.GetComponent<Rigidbody>() != null)
                {
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                else
                {
                    print("Add rigid body to grabbable objects");
                }
                //        grabbedObject.transform.position = transform.position; //causes the grabbedobject to center arund hand leading to rendering issue with player inside the grabbedObject
                parent = grabbedObject.transform.parent;
                grabbedObject.transform.parent = transform;
                //for highlighting
                Renderer rend = grabbedObject.GetComponent<Renderer>();
                original = rend.material.shader;
                // rend.material.shader = Shader.Find("highlighter");
                rend.material.shader = shade;
                string txt = grabbedObject.transform.name.ToString();
                text.text = txt;

                holding = true;
                States s = grabbedObject.GetComponent<States>();
            }

        }
    }
    public void DropObject(bool bothGrab)
    {
        grabbing = false;

        if (grabbedObject != null && !bothGrab)
        {
            //for unhighlighting
            // Renderer rend = grabbedObject.GetComponent<Renderer>();
            // rend.material.shader = original;
            if (grabbedObject.GetComponent<resetColor>() != null)
            {
                resetColor col = grabbedObject.GetComponent<resetColor>();
                col.setColor();
            }
            //for actually dropping
            grabbedObject.transform.parent = null;
            //Destroy(grabbedObject.GetComponent<MeshCollider>());
            if (grabbedObject.GetComponent<MeshCollider>() == null)
            {
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            if (grabbedObject.GetComponent<Rigidbody>().isKinematic == true)
            {

            }
            grabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(controller);
            grabbedObject.GetComponent<Rigidbody>().angularVelocity = GetAngularVelocity();

            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject.transform.SetParent(parent);

            grabbedObject = null;

            text.text = "";
           
            holding = false;

        }
        else if (bothGrab && grabbedObject != null)
        {
            grabbedObject.transform.parent = null;
            holding = false;
            if (grabbedObject.GetComponent<resetColor>() != null)  //should remove this
            {
                resetColor col = grabbedObject.GetComponent<resetColor>();
                col.setColor();
            }
            grabbedObject = null;
        }


    }
    public Transform handName()
    {
        return transform;
    }

    Vector3 GetAngularVelocity()
    {

        Quaternion deltaRotation = currentRotation * Quaternion.Inverse(lastRotation);
        return new Vector3(Mathf.DeltaAngle(0, deltaRotation.eulerAngles.x), Mathf.DeltaAngle(0, deltaRotation.eulerAngles.y), Mathf.DeltaAngle(0, deltaRotation.eulerAngles.z));
    }
    public void Update()
    {
        bool bothGrab = false;
        float dist1;
        if (grabbedObject != null)
        {

            lastRotation = currentRotation;
            currentRotation = grabbedObject.transform.rotation;

        }
        if (holding && neighbor.holding)
        {
            if (neighbor.getName() == text.text)
            {
                bothGrab = true;
                dist1 = Vector3.Distance(this.transform.position, neighbor.transform.position);
                expand(dist1, grabbedObject);
            }
        }


        if (/*/!neighbor.holding &&/*/ !grabbing && Input.GetAxis(buttonName) == 1) GrabObject(); //just added the neighbor.holding part
        if (grabbing && Input.GetAxis(buttonName) < 1) {
            DropObject(bothGrab);
            if(neighbor.transform.GetChild(2) != null)
            {
                Transform neiChi = neighbor.transform.GetChild(2);
                resetScript neiChiRS = neiChi.GetComponent<resetScript>();
                if (neiChi.GetComponent<resetScript>() != null)
                {
                    neiChiRS.resetParent();
                }
            }
            
                };

    }
    float distOld;
    public void expand(float dis, GameObject obj)
    {
        if (distOld == 0.0f)  //should only occur for first defining 
        {
            distOld = dis;
        }
        else if (dis < distOld)
        {
            Vector3 orig = obj.transform.localScale;
            orig.x = orig.x * 0.995f;
            orig.y = orig.y * 0.995f;
            orig.z = orig.z * 0.995f;

            obj.transform.localScale =orig;
        }
        else if (distOld < dis)
        {
            Vector3 orig = obj.transform.localScale;
            orig.x = orig.x * 1.005f;
            orig.y = orig.y * 1.005f;
            orig.z = orig.z * 1.005f;

            obj.transform.localScale = orig;
        }
        distOld = dis;
    }

    public bool isHolding()
    {
        if (holding)
        {
            print("is holding called");
            return true;
        }
        else
        {
            return false;
        }
    }
    public void setName(string name)
    {
        string txt = name;
        text.text = txt;
     //   holding = true;  //this crude implementation may cause errors when laser is on and grab object at same time
    }
    public void removeName()
    {
        text.text = "";
        holding = false;
    }
    public string getName()
    {
        if (holding)
        {
            return text.text;
        }
        else
        {
            return null;
        }
    }
}


