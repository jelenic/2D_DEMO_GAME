//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResourcesScript : MonoBehaviour
{

    public Text resource1Text;
    public Text resource2Text;
    public Text resource3Text;

    private int[] resourceQ;

    // Start is called before the first frame update
    void Start()
    {
        resourceQ = new int[3];
    }

    

    public void setResource1 (string text) {
        resource1Text.text = text;
        int x = 0;
        Int32.TryParse(text, out x);
        resourceQ[0] = x;
    }

    public void setResource2(string text)
    {
        resource2Text.text = text;
        int x = 0;
        Int32.TryParse(text, out x);
        resourceQ[1] = x;
    }

    public void setResource3(string text)
    {
        resource3Text.text = text;
        int x = 0;
        Int32.TryParse(text, out x);
        resourceQ[2] = x;
    }
}
