using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResourcesScript : MonoBehaviour
{

    public Text resource1Text;
    public Text resource2Text;
    public Text resource3Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //increaseResource1(5);
        //increaseResource2(4);
        //increaseResource3(3);
    }

    public void increaseResource1(int value)
    {
        int x = 0;
        Int32.TryParse(resource1Text.text, out x);
        resource1Text.text =(x + value).ToString().Trim();
    }

    public void decreaseResource1(int value)
    {
        int x = 0;
        Int32.TryParse(resource1Text.text, out x);
        resource1Text.text = (x - value).ToString().Trim();
    }

    public void increaseResource2(int value)
    {
        int x = 0;
        Int32.TryParse(resource2Text.text, out x);
        resource2Text.text = (x + value).ToString().Trim();
    }

    public void decreaseResource2(int value)
    {
        int x = 0;
        Int32.TryParse(resource2Text.text, out x);
        resource2Text.text = (x - value).ToString().Trim();
    }

    public void increaseResource3(int value)
    {
        int x = 0;
        Int32.TryParse(resource3Text.text, out x);
        resource3Text.text = (x + value).ToString().Trim();
    }

    public void decreaseResource3(int value)
    {
        int x = 0;
        Int32.TryParse(resource3Text.text, out x);
        resource3Text.text = (x - value).ToString().Trim();
    }
}
