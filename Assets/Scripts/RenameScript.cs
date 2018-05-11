using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public string reName(string name, string hemisphere)
    {
        string newName = "blank";
        if (name.Contains("bankssts"))
        {
            newName = hemisphere + " Banks of the Superior Temporal Sulcus";
        }
        if (name.Contains("caudalanteriorcingulate"))
        {
            newName = hemisphere + " Caudal Anterior Cingulate Cortex";
        }
        if (name.Contains("caudalmiddlefrontal"))
        {
            newName = hemisphere + " Caudal Middle Frontal Gyrus";
        }
        if (name.Contains("cuneus"))
        {
            newName = hemisphere + " Cuneus";
        }
        if (name.Contains("entorhinal"))
        {
            newName = hemisphere + " Entorhinal Cortex";
        }
        if (name.Contains("frontalpole"))
        {
            newName = hemisphere + " Frontopolar Prefrontal Cortex";
        }
        if (name.Contains("fusiform"))
        {
            newName = hemisphere + " Fusiform Gyrus";
        }
        if (name.Contains("inferiorparietal"))
        {
            newName = hemisphere + " Inferior Parietal Lobule";
        }
        if (name.Contains("inferiortemporal"))
        {
            newName = hemisphere + " Inferior Temporal Gyrus";
        }
        if (name.Contains("insula"))
        {
            newName = hemisphere + " Insular Cortex";
        }
        if (name.Contains("muscing"))
        {
            newName = hemisphere + " Isthmus of the Cingulate Gyrus";
        }
        if (name.Contains("lateraloccipital"))
        {
            newName = hemisphere + " Lateral Occipital Lobe";
        }
        if (name.Contains("lateralorbitofrontal"))
        {
            newName = hemisphere + " Lateral Orbitofrontal Cortex";
        }
        if (name.Contains("lingual"))
        {
            newName = hemisphere + " Lingual Gyrus";
        }
        if (name.Contains("medialorbitofrontal"))
        {
            newName = hemisphere + " Middle Orbitofrontal Cortex";
        }
        if (name.Contains("middletemporal"))
        {
            newName = hemisphere + " Middle Temporal Lobe";
        }
        if (name.Contains("paracentral"))
        {
            newName = hemisphere + " Paracentral Lobule";
        }
        if (name.Contains("parahippocampal"))
        {
            newName = hemisphere + " Parahippocampal Gyrus";
        }
        if (name.Contains("parsopercularis"))  //this region i found is brodmann area but dont know what called on right hemisphere
        {
            newName = "Brodmann Area 44";
        }
        if (name.Contains("parsorbit"))
        {
            newName = hemisphere + " Parsorbitalis";
        }
        if (name.Contains("parstriangularis"))
        {
            newName = "Brodmann Area 45";
        }
        if (name.Contains("pericalcarine")) //also not sure about this one
        {
            newName = hemisphere + " Pericalcarine Sulcus Region";
        }
        if (name.Contains("postcentral"))
        {
            newName = hemisphere + " Postcentral Gyrus";
        }
        if (name.Contains("posteriorcingulate"))
        {
            newName = hemisphere + " Posterior Cingulate Cortex";
        }
        if (name.Contains("precentral"))
        {
            newName = hemisphere + " Precentral Gyrus";
        }
        if (name.Contains("precuneus"))
        {
            newName = hemisphere + " Precuneus";
        }
        if (name.Contains("rostralanteriorcingulate"))
        {
            newName = hemisphere + " Rostral Anterior Cingulate";
        }
        if (name.Contains("rostralmiddlefrontal"))
        {
            newName = "Brodmann Area 10";
        }
        if (name.Contains("superiorfrontal"))
        {
            newName = hemisphere + " Superior Frontal Gyrus";
        }
        if (name.Contains("superiorparietal"))
        {
            newName = hemisphere + " Superior Parietal Lobule";
        }
        if (name.Contains("superiortemporal"))
        {
            newName = hemisphere + " Superior Temporal Gyrus";
        }
        if (name.Contains("supramarginal"))
        {
            newName = hemisphere + " Supramarginal Gyrus";
        }
        if (name.Contains("temporalpole"))
        {
            newName = hemisphere + " Temporal Pole";
        }
        if (name.Contains("transversetemporal"))
        {
            newName = hemisphere + " Transverse Temporal Gyrus";
        }
        if (name.Contains("unlabelled"))
        {
            newName = "Unlabelled";
        }
        return newName;
    }
}
