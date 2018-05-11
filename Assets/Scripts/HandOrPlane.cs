using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOrPlane : MonoBehaviour
{
    public Hand handClassRight;
    public Hand handClassLeft;
    public Hand handName;
    public GameObject rightHand;
    public GameObject leftHand;
    public Renderer plate;
    public Canvas can;
    // Use this for initialization
    void Start()
    {
        can.enabled = false;
        plate.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (handClassRight.isHolding() || handClassLeft.isHolding())
        {
            Transform hand = null;
            if (handClassRight.isHolding())
            {
                hand = handClassLeft.handName();
            }
            else if (handClassLeft.isHolding())
            {
                hand = handClassRight.handName();
            }
            transform.parent = hand; // sets the canvas and plane to be the child of the hand doing the grabbing
            GameObject parentHand = hand.gameObject;
            int childNum = parentHand.transform.childCount;
            for (int i = 0; i < childNum; i++)
            {
                Transform child = parentHand.transform.GetChild(i);
                if (child.name == "hand_left_renderPart_0" || child.name ==  "hand_right_renderPart_0")  //try deleting later
                {

                  //  SkinnedMeshRenderer handRend = child.GetComponent<SkinnedMeshRenderer>(); //turns off the hand renderer
                  //  handRend.enabled = false;

                 //   plate.enabled = true;

                    can.enabled = true;
                }
            }
        }
     else
        {
            Transform handR = null;
            Transform handL = null;
            handR = handClassRight.handName();
            handL = handClassLeft.handName();
            enableChildMesh(handL);
            enableChildMesh(handR);
        }
    }
    void enableChildMesh(Transform gobject)   //turns on the skinnedmeshrenderer if it is turned off for l and r hands
    {
        GameObject gaobject = gobject.transform.gameObject;
        int childNum = gaobject.transform.childCount;
        for(int i= 0; i<childNum; i++)
        {
            Transform child = gaobject.transform.GetChild(i);
            if(child.name == "hand_left_renderPart_0" || child.name == "hand_right_renderPart_0") //could modify to simply check for any skinned mesh renderers if necessary
            {
                SkinnedMeshRenderer handrend = child.GetComponent<SkinnedMeshRenderer>();
                handrend.enabled = true;
            }
        }
            }
}

