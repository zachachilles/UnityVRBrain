using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour {
    private bool transparent;
    // Use this for initialization
    void Start() {
        transparent = false;
    }

    // Update is called once per frame
    void Update() {

    }
    public void setTransparent(bool yes)
    {
        transparent = yes;
    }
    public bool isTransparent()
    {
        return transparent;
    }
}
