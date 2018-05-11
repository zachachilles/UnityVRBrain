using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class parseTrigger : MonoBehaviour {
    public GameObject parent;
    public Material mat;
    public Material transparent;
    public Color col;
    public GameObject child;
    public bool trig;
    public Material orig;

    public GameObject auditory;
    public GameObject visual;
    public GameObject gustatory;
    public GameObject ss;

    public Transform[] levs;  //need to add lever to this array before it is functional
    // Use this for initialization
    void Start()
    {
        trig = false;
        
    }
    public List<string> trim(List<string> arr) 
    {
        if(arr == null)
        {
            return null;

        }
        for (int i = 0; i < arr.Count; i++)
        {
            arr[i] = arr[i].Substring(0, arr[i].Length - 1);
        }
        return arr;
    }

	public void transformation (List<string> arr) {
        this.gameObject.AddComponent<resetScript>();
        resetScript r = this.GetComponent<resetScript>();
        int numchild = parent.transform.childCount;

        /*/  for(int i = 0; i < arr.Count; i++)
          {

                  arr[i]= arr[i].TrimEnd();   delete this section

          } /*/

        arr = trim(arr);
        List<Transform> finalcut = new List<Transform>();
        for (int i = 0; i<numchild; i++)
        {
            Transform child = parent.transform.GetChild(i);
            for (int x = 0; x < child.childCount; x++)
            {
                for (int y = 0; y < arr.Count; y++) {
                    Transform real = child.GetChild(x).GetChild(0); //gets the actual surface file 
                    if (child.GetChild(x).name.Contains(arr[y].TrimEnd()) || (arr[y].TrimEnd()).Contains(child.GetChild(x).name) || string.Equals(arr[y], child.GetChild(x).name)  || arr[y].Contains("Lever")) {
                        if (arr[y].Contains("Lever"))
                        {
                            for (int m = 0; m < levs.Length; m++)
                            {
                                if (arr[y] == levs[m].name)
                                {
                                    finalcut.Add(levs[m]);
                                }
                            }
                        }
                        else
                        {
                            finalcut.Add(real);
                        }
                     //   real.GetComponent<Renderer>().material = mat; //sets the material off the component 
                     //   real.GetComponent<Renderer>().material.color = col;
                    }
                    else
                    {
                   //     print(child.GetChild(x).name);
                    //    print(real.name);
                        real.GetComponent<Renderer>().material = transparent;
                        States s = real.GetComponent<States>();
                        s.setTransparent(true);  //sets the surface to transparent to prevent laser or hand interaction
                    }
                }
            }
        }
        for (int i = 0; i < finalcut.Count; i++)
        {
            // Color coler = col;

            if (finalcut[i].name.Contains("Lever"))
            {
                for (int x = 0; x < levs.Length; x++)
                {
                    if (levs[x].name == finalcut[i].name)
                    {
                        col = levs[x].GetComponent<TextMesh>().color;
           //             print("proper lever");
                    }
                }
            }
            //    print(coler);
            else
            {
                States s = finalcut[i].GetComponent<States>();
                s.setTransparent(false);
                finalcut[i].GetComponent<Renderer>().material = mat;
                finalcut[i].GetComponent<Renderer>().material.color = col;
                resetColor res = finalcut[i].GetComponent<resetColor>();
                res.initialColor();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
   //     resetScript r = this.GetComponent<resetScript>();

        VRTK_Lever l = child.GetComponent<VRTK_Lever>();

        VRTK_Lever aud = auditory.GetComponent<VRTK_Lever>();

        VRTK_Lever vis = visual.GetComponent<VRTK_Lever>();

        VRTK_Lever sos = ss.GetComponent<VRTK_Lever>();

        VRTK_Lever gus = gustatory.GetComponent<VRTK_Lever>();
        
        textParse txt = parent.GetComponent<textParse>();

        List<string> arr = new List<string>();

        if (aud.CalculateValue() > 45 && trig == false)
        {
           
            List<string> arrr = txt.auditory();
            for(int i = 0; i<arrr.Count; i++)
            {
                arr.Add(arrr[i]);
            }
        }

        if (vis.CalculateValue() > 45 && trig == false)
        {
            List<string> arrr = txt.visual();
            for (int i = 0; i < arrr.Count; i++)
            {
                arr.Add(arrr[i]);
            }
        }
        if(sos.CalculateValue() > 45 && trig == false)
        {
            List<string> arrr = txt.somatosensory();
            for (int i = 0; i < arrr.Count; i++)
            {
                arr.Add(arrr[i]);
            }
        }
        if(gus.CalculateValue() > 45 && trig == false)
        {
            List<string> arrr = txt.gustatory();
            for (int i = 0; i < arrr.Count; i++)
            {
                arr.Add(arrr[i]);
            }
        }


        //  List<string> arr = txt.parse();
        //float angle = lev.

        if (l.CalculateValue() > 45 && trig == false)
        {
            trig = true;
            transformation(arr);
            for(int i = 0; i<arr.Count; i++)
            {
            //    print(arr[i]);
            }
        }
        if (l.CalculateValue()<10 && trig == true)
        {
            trig = false;
            reset(arr);
        }

    }
    public void reset(List<string> arr)
    {


        this.gameObject.AddComponent<resetScript>();
        resetScript r = this.GetComponent<resetScript>();
        int numchild = parent.transform.childCount;

        for (int i = 0; i < numchild; i++)
        {
            Transform child = parent.transform.GetChild(i);
            for (int x = 0; x < child.childCount; x++)
            {

                    Transform real = child.GetChild(x).GetChild(0); //gets the actual surface file 

                    real.GetComponent<Renderer>().material = orig;

                    States s = real.GetComponent<States>();
                    s.setTransparent(false);
                
            }
        }

    }
    /*/ junk:
 *          //   resetScript res = this.gameObject.GetComponent<resetScript>();
        //    res.resetPos();
            
           // textParse txt = parent.GetComponent<textParse>(); <- delete these two lines later if all goes well
            //List<string> arr = txt.parse();
            /*/
}




