using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChildren : MonoBehaviour {
    GameObject thisObject;
	// Use this for initialization
	void Start () {
        thisObject = this.gameObject;
        int childNum = thisObject.transform.childCount;
        Color[] childColors = new Color[childNum];
        int saturationIterator=0;
        bool valueAlternator = true; 
        for (int i = 0; i < childNum; i++)
        {
            float onehun = 100;
            Color color;
            float range = 100 / childNum;
            float hue = i * range;
            hue = hue / onehun;
            float saturation;
            float value = 1;
            if (saturationIterator<10)
            {
                saturation = saturationIterator * 7 + 30;
                saturation = saturation / onehun;                
            }
            else
            {
                saturationIterator = 0;
                saturation = 1.0f;
            }
            if (valueAlternator)
            {
                value = 0.5f;
                valueAlternator = false;
            }
            else
            {
                valueAlternator = true;
            }
            color = Color.HSVToRGB(hue, saturation, value);
            childColors[i] = color;
            saturationIterator++;
        }
        colorChildren(childColors);
    }
    void colorChildren (Color[] childColors)
    {
        int childNum = thisObject.transform.childCount;
        for(int i = 0; i<childNum; i++)
        {
            Transform firstChild = thisObject.transform.GetChild(i);
            findRenderer(firstChild, childColors[i]);
        }

    }
    public void findRenderer(Transform child, Color toColor)
    {
        if(child.GetComponent<Renderer>() != null)
        {
            child.GetComponent<Renderer>().material.color = toColor;
        }
        else
        {
            int numChild = child.transform.childCount;
            for(int i = 0; i<numChild; i++)
            {
                Transform children = child.GetChild(i);
                findRenderer(children, toColor);
            }
        }

    }
    // Update is called once per frame
    void Update()    {

    }
}
