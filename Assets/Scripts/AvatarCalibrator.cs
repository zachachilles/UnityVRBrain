using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarCalibrator : MonoBehaviour
    {

        public GameObject LeftHand;
        public GameObject LeftHandAvatar;

    // Use this for initialization
    void Start()
    {
        if (LeftHand == null)
            LeftHand = GameObject.Find("LeftHandAnchor");
        if (LeftHandAvatar == null)
            LeftHandAvatar = GameObject.Find("hand_left");
        if (LeftHandAvatar == null)
        {
 //           print("mn");
        }
    }
    void Update()
        {
     //   print(LeftHandAvatar.transform.position);
     //   print(LeftHandAvatar.transform.position);
  //      if (LeftHand.transform.position != LeftHandAvatar.transform.position)
        {
 //           transform.position += LeftHand.transform.position - LeftHandAvatar.transform.position;
        }
        }
    }
