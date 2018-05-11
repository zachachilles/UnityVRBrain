using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class EventManager : MonoBehaviour {
    public delegate void LeverAction();
    public static event LeverAction lever;
    public GameObject child;
	// Use this for initialization

	void Start () {
        VRTK_Lever l = child.GetComponent<VRTK_Lever>();

	}
    void lev()
    {
        bool triggered = false;
        VRTK_Lever l = child.GetComponent<VRTK_Lever>();
        float num = 45;
        if (l.CalculateValue() > num)
        {
            print("hello");
        }
    }

    // Update is called once per frame
    void Update () {
        VRTK_Lever l = child.GetComponent<VRTK_Lever>();
        float num = 45;
        
        if (l.CalculateValue() > num)
        {
            if (lever != null)
            {
                lever();
            }
        }
    }
}
