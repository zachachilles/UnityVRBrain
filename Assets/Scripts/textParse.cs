using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class textParse : MonoBehaviour {

    public TextAsset file;
    public TextAsset compare;
    public TextAsset audit;
    public TextAsset olfact;
    public TextAsset vis;
    public TextAsset gus; //gustatory system
    public TextAsset ss; //somatosensory system 
	// Use this for initialization
	void Start () {
        this.gameObject.AddComponent<resetScript>();
        resetScript r = this.GetComponent<resetScript>();
	}
	
	// Update is called once per frame
	void Update () {
        resetScript r = this.GetComponent<resetScript>();
        if (this.gameObject.transform.position != r.returninitPos() || this.gameObject.transform.rotation != r.returnRot())
        {
            resetScript res = this.gameObject.GetComponent<resetScript>();
            res.resetPos();
            parse();
        }

    }
    public List<string> parse()
    {
        List<string> selection = new List<string>();
        string f = file.text;
        string c = compare.text;
        string[] flines = Regex.Split(f, "\n");
        string[] names = Regex.Split(c, "\n");
        //remove newlines 
        for(int i = 0; i<flines.Length; i++)
        {
            flines[i].Replace("\n", "").Replace("\r", "").Replace(" ","");
        }
        for(int i = 0; i<names.Length; i++)
        {
            names[i].Replace("\n", "").Replace("\r", "").Replace(" ","");
        }

        for(int i =0; i<flines.Length; i++)
        {
            string line = flines[i];
            for(int x = 0; x<names.Length; x++)
            {
                if (line.Contains(names[x]) && names[x]!="" && names[x].Length>2)
                {
                    selection.Add(names[x]);
                }
            }
        }
        return selection;
    }
    public List<string> auditory()
    {
        List<string> selection = new List<string>();
        string f = audit.text;
        string[] flines = Regex.Split(f, "\n");
        for (int i = 0; i < flines.Length; i++)
        {
            flines[i].Replace("\n", "").Replace("\r", "").Replace(" ", "");
        }
        for(int i = 0; i<flines.Length; i++)
        {
            selection.Add(flines[i]);
        }
        return selection;
    }
    public List<string> gustatory()
    {
        List<string> selection = new List<string>();
        string f = gus.text;
        string[] flines = Regex.Split(f, "\n");
        for (int i = 0; i < flines.Length; i++)
        {
            flines[i].Replace("\n", "").Replace("\r", "").Replace(" ", "");
        }
        for (int i = 0; i < flines.Length; i++)
        {
            selection.Add(flines[i]);
        }
        return selection;
    }
    public List<string> visual()
    {
        List<string> selection = new List<string>();
        string f = vis.text;
        string[] flines = Regex.Split(f, "\n");
        for (int i = 0; i < flines.Length; i++)
        {
            flines[i].Replace("\n", "").Replace("\r", "").Replace(" ", "");
        }
        for (int i = 0; i < flines.Length; i++)
        {
            selection.Add(flines[i]);
        }
        return selection;
    }
    public List<string> somatosensory()
    {
        List<string> selection = new List<string>();
        string f = ss.text;
        string[] flines = Regex.Split(f, "\n");
        for (int i = 0; i < flines.Length; i++)
        {
            flines[i].Replace("\n", "").Replace("\r", "").Replace(" ", "");
        }
        for (int i = 0; i < flines.Length; i++)
        {
            selection.Add(flines[i]);
        }
        return selection;
    }
}