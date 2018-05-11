using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFollowParent : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform parent = transform.parent;
        this.transform.position = parent.transform.position;
    }
}

