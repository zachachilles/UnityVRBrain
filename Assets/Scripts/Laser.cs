using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Laser : MonoBehaviour {
    public GameObject daLaser;
    public Material laserColor;
    public Material laserHitColor;
    public float thickness = 0.005f;
    public float length = 50.0f;
    bool laserActive = false;
    Ray raycast;
    public Color ogColor;
   // public bool originalColor = true;
    public GameObject originalObject;
    public Hand grabStuff;
    public GameObject grabbedObject;

    public Material test;
    public bool full;
    public int floatHer;
    float timer;
    float timerLimit;

    float time;
    // Use this for initialization
    void Start () {
        Vector3 size = new Vector3(0.0001f, 0.0001f,0.0001f); // size very small so cant see sphere
        daLaser = GameObject.CreatePrimitive(PrimitiveType.Sphere); //sphere to hold the laser
        daLaser.transform.parent = this.transform;
        daLaser.transform.localScale = size;
        daLaser.GetComponent<MeshRenderer>().material = laserColor;
        daLaser.GetComponent<SphereCollider>().enabled = false; //try making true to allow to detect collisions!!
        raycast = new Ray(size, size);  //changed from Ray raycast
      //  full = false;
        timerLimit = 1f;
}   
	// Update is called once per frame
	void Update () {
        if (this.name == "hand_left" && OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick) && !laserActive)
        {
            laserOn();
            createLaser();
        }
        else if (this.name == "hand_right" && OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick) && !laserActive)
        {
            laserOn();
            createLaser();
        }
        else if (laserActive && (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick) && this.name == "hand_left"))
        {
            laserOn();
            destroyLaser();
        }
        else if (laserActive && (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick)) && this.name == "hand_right")
        {
            laserOn();
            destroyLaser();
        }
        if (laserActive/*/ &&!full /*/ && this.name=="hand_right")
        {
            bool raseText = false;
            if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
            {
                starttimer();
                raseText = true;

            }
            else if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            {
                floatHer = 0;
                timer = 0;
            }
            laserCollide(raycast, raseText);
        }
        if (laserActive/*/ &&!full /*/ && this.name=="hand_left")
        {
            bool raseText = false;
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) )
            {
                starttimer();
                raseText = true;

            }
            else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) )
            {
                floatHer = 0;
                timer = 0;
            }
            laserCollide(raycast, raseText);
        }
    }

    void starttimer()
    {
        timer = timer += Time.deltaTime;
    }

    void createLaser()
    {
        raycast = new Ray(transform.position, transform.forward); //sets up laser 
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(raycast, out hitInfo, length);
        float distance = hit ? hitInfo.distance : length;
        daLaser.transform.localScale = new Vector3(thickness, thickness, distance);
        daLaser.transform.localPosition = new Vector3(0f, 0f, distance / 2f);

        daLaser.GetComponent<MeshRenderer>().material = laserColor; //shifts laser color back to normal after turned off
    }
    void destroyLaser()
    {
        daLaser.transform.localScale = new Vector3(0f, 0f, 0f); //makes laser invisible - doesnt actually turn off -- maybe alter so laser actually turns off
        daLaser.transform.localPosition = new Vector3(0f, 0f, 0f);
        if(/*/!originalColor && /*/originalObject != null)
        {
            laserDeactivate();
        }
    }
    public bool laserOn()
    {
        if (laserActive)
        {
            laserActive = false;
            return true;
        }
        else
        {
            laserActive = true;
            return false;
        }
    }
    public void laserCollide(Ray cast, bool txtON)
    {
        raycast = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(cast, out hitInfo, length);
        if (hitInfo.collider !=null && hitInfo.collider.gameObject != null)
        {
            if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("grabbable"))
            {
                if (hitInfo.collider.gameObject.GetComponent<States>() != null)
                {
                    States s = hitInfo.collider.gameObject.GetComponent<States>();  //just tried adding this section to test for transparency - if transparent should do essentially nothing
                    if (!s.isTransparent()) {
                        daLaser.GetComponent<MeshRenderer>().material = laserHitColor;
                        GameObject touchedObject = hitInfo.collider.gameObject;

                        if (/*/originalColor &&/*/ originalObject == null)
                        {
                            //       full = true;
                            laserActivity(touchedObject, txtON);
                            
                        }
                        else if (touchedObject.name != originalObject.name)  //this checks to see if new object reached that is touching old object
                        {
                            resetName();
                            laserDeactivate();
                            laserActivity(touchedObject, txtON);
                            
                        }

                        if (OVRInput.Get(OVRInput.Button.One))  //raises the object in chunks
                        {
                            Vector3 m = touchedObject.transform.position;
                            float y = m.y;
                            y = y + 0.006f;
                            m.y = y;
                            touchedObject.transform.position = m;
                            touchedObject.GetComponent<Rigidbody>().useGravity = false;
                            touchedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                            touchedObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                            //    touchedObject.transform.parent = transform;
                            //    touchedObject.transform.position = transform.position;
                        }
                        if (OVRInput.Get(OVRInput.Button.Two))  //moves object to the hand with the laser
                        {
                            grabbedObject = touchedObject;
                            grabbedObject.transform.parent = transform;
                            //   grabbedObject.transform.position = transform.position;
                            //print(Vector3.MoveTowards(grabbedObject.transform.position, transform.position, 0.05f));
                            grabbedObject.transform.position = Vector3.MoveTowards(grabbedObject.transform.position, transform.position, 0.05f);

                            grabbedObject.transform.parent = null;
                            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                            grabbedObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                            grabbedObject.GetComponent<Rigidbody>().useGravity = false;
                        }
                        if (OVRInput.Get(OVRInput.Button.Three)) //this activates the reset script so the object returns to its original position
                        {
                            resetScript go = touchedObject.GetComponent<resetScript>();
                            go.activate();

                        }
                        if(touchedObject.GetComponent<TMPro.Examples.FloatText>() != null)
                        {
                   //         Destroy(touchedObject.GetComponent<TMPro.Examples.FloatText>(), 2);
                        }
                        if (txtON&& floatHer<1 && touchedObject.GetComponent<TMPro.Examples.FloatText>() == null)
                        {
                            touchedObject.AddComponent<TMPro.Examples.FloatText>();
                            TMPro.Examples.FloatText t = touchedObject.GetComponent<TMPro.Examples.FloatText>();
                            t.floatStart(touchedObject.name, touchedObject.GetComponent<Renderer>().material.color);
                            floatHer = floatHer += 1;
                        } 
                    } 
                    else
                    {
                        daLaser.GetComponent<Renderer>().material = laserColor;
                        if (/*/!originalColor&&/*/ originalObject != null)
                        {
                            resetName();   //these were commented out on 2/12/2018
                            laserDeactivate();


                        }
                    }
                }
            }
        }
        else if (/*/!originalColor &&/*/ originalObject !=null)
            {
            laserDeactivate();
            resetName();
        }
        if(hitInfo.collider == null || hitInfo.collider.gameObject == null)
        {
            daLaser.GetComponent<MeshRenderer>().material = laserColor;
            
        }

    }
    public void laserDeactivate()
    {
        resetColor col = originalObject.GetComponent<resetColor>();
        // originalObject.GetComponent<Renderer>().material.color = ogColor;
        // col.setColor();
        //  resetName();
        if (originalObject.GetComponent<TMPro.Examples.FloatText>() != null)   //potentially wrong because did not check original object all the way trhiugh
        {
            Destroy(originalObject.GetComponent<TMPro.Examples.FloatText>(), 2f);
            col.setColor();
            col.colorSet();
            //Invoke("setColor", 0.1f);
            resetName();
           // Invoke("resetName", 0.1f);
            originalObject = null;
        //    originalColor = true;
           // Invoke("resetColor", 0.1f);

        }
        else
        {
            originalObject = null;
            col.setColor();
            col.colorSet();
    //        originalColor = true;
        }
        if (grabbedObject != null)
        {
            grabbedObject.transform.parent = null;
        }
    }
    public void laserActivity(GameObject chunk, bool txtON)  //this method is called when a grabbale game object is highlighted
    {
        resetColor chunkCol = chunk.GetComponent<resetColor>();
        Color newColor;
        if(chunk.GetComponent<Renderer>() != null)
        {

            if (/*/originalColor/*/ chunkCol.originalColor())
            {
                Color objectColor = chunk.GetComponent<Renderer>().material.color;
                ogColor = chunk.GetComponent<Renderer>().material.color;
                originalObject = chunk;
                

                float opaque = objectColor.a * 0.5f;
                float blue = objectColor.b * 0.5f;
                float green = objectColor.g * 0.5f;
                float red = objectColor.r * 0.5f;
                float opaqueness = opaque * 0.1f;
                newColor = new Vector4(red, green, blue, opaqueness);
                if (txtON&&chunk.GetComponent<TMPro.Examples.FloatText>()==null && floatHer<1)// && timer<1/*/timer>timerLimit &&(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)|| OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger)/*/)
                {
         /*/           print("hello");
                    chunk.AddComponent<TMPro.Examples.FloatText>();
                    TMPro.Examples.FloatText t = chunk.GetComponent<TMPro.Examples.FloatText>();
                    t.floatStart(chunk.name, newColor);
                    chunk.AddComponent<TimeHold>();
                    floatHer = floatHer += 1;   /*/
                }

                chunk.GetComponent<Renderer>().material.color = newColor; //changed from object color so far this block does nothing

                //    originalColor = false;
                chunkCol.colorSet();

                States s = chunk.GetComponent<States>();
                if(this.name == "hand_left" && !s.isTransparent())
                {
                    GameObject hand = GameObject.Find("hand_left");
                    Hand h = hand.GetComponent<Hand>();
                    h.setName(chunk.name);
                }
                else if (this.name == "hand_right" && !s.isTransparent())
                {
                    GameObject hand = GameObject.Find("hand_right");
                    Hand h = hand.GetComponent<Hand>();
                    h.setName(chunk.name.ToString());
                }

                //   chunk.GetComponent<Renderer>().material = laserHitColor;

            }
        }


        
    }
    public void resetName()
    {
        if(this.name == "hand_right")
        {
            GameObject hand = GameObject.Find("hand_right");
            Hand h = hand.GetComponent<Hand>();
            h.removeName();
        }
        if (this.name == "hand_left")
        {
            GameObject hand = GameObject.Find("hand_left");
            Hand h = hand.GetComponent<Hand>();
            h.removeName();
        }
    }
   /*/ public void resetColor()
    {
        originalObject = null;

    //    originalColor = true;
        full = false;
        
    }
    /*/
    public void setColor()
    {
        resetColor col = originalObject.GetComponent<resetColor>();
        col.setColor();
        col.colorSet();
    }
  
}
