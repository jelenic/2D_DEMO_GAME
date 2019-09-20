using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null; //Static instance of GameManager which allows it to be accessed by any other script.

    private ResourcesScript resourcesScript;

    private int[] resourceQ;

    private StructureData[] structureState;

    



    //private Button gmBtn;


    //Awake is always called before any Start functions
    void Awake () {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy (gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad (gameObject);

    }

    void Start () {
        resourcesScript = GameObject.Find("MainCanvas").GetComponent<ResourcesScript> ();
        //gmBtn = GameObject.Find("MainCanvas").transform.Find("gmBtn").gameObject.GetComponent<Button>();

        //gmBtn.onClick.AddListener(delegate { setResourceText1("lol"); });

        
    }

    public bool SpentResources(int R1, int R2, int R3)
    {
        if (R1 <= resourceQ[0] && R2 <= resourceQ[1] && R3 <= resourceQ[2])
        {
            resourceQ[0] = resourceQ[0] - R1;
            resourceQ[1] = resourceQ[1] - R2;
            resourceQ[2] = resourceQ[2] - R3;
            resourcesScript.setResource1(resourceQ[0].ToString());
            resourcesScript.setResource2(resourceQ[1].ToString());
            resourcesScript.setResource3(resourceQ[2].ToString());
            return true;
        }
        else
        {
            return false;
        }
    }

    public void IncreaseResources(int R1, int R2, int R3)
    {
        resourceQ[0] = resourceQ[0] + R1;
        resourceQ[1] = resourceQ[1] + R2;
        resourceQ[2] = resourceQ[2] + R3;
        resourcesScript.setResource1(resourceQ[0].ToString());
        resourcesScript.setResource2(resourceQ[1].ToString());
        resourcesScript.setResource3(resourceQ[2].ToString());
    }

    public void updateStructureState()
    {
        GameObject[] structures = GameObject.FindGameObjectsWithTag("StructureTile");
        structureState = new StructureData[structures.Length];
        int i = 0;

        foreach (GameObject go in structures)
        {
            structureState[i] = new StructureData(go);
            i++;
        }
    }

    public void listStructureStateInConsole()
    {
        foreach (StructureData sd in structureState)
        {
            Debug.Log(" Current Structure:" +
            sd.name + "-::" + sd.position[0] + "," + sd.position[1]);
        }
    }



    

}