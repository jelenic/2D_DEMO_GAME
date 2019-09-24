﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null; //Static instance of GameManager which allows it to be accessed by any other script.

    private ResourcesScript resourcesScript;

    private int[] resourceQ;

    private StructureData[] structureState;

    private List<ShipData> ships;

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
        resourceqInit ();
        updateStructureState ();
        resourcesScript = GameObject.Find ("MainCanvas").GetComponent<ResourcesScript> ();
        InvokeRepeating ("increaseResourcesTick", 0.2f, 2f);
        //gmBtn = GameObject.Find("MainCanvas").transform.Find("gmBtn").gameObject.GetComponent<Button>();

        //gmBtn.onClick.AddListener(delegate { setResourceText1("lol"); });

        ships = new List<ShipData>();

    }

    public void addShip (ShipData ship) {
        Debug.Log ("adding ship: " + ship.componentNumber);
        ships.Add (ship);
    }

    public List<ShipData> getShips () {
        Debug.Log("printing ships start");
        foreach (var ship in ships) 
        {
            Debug.Log("shipp: " + ship.componentNumber);
        }
        Debug.Log("printing ships end");
        return ships;
    }

    public bool SpentResources (int R1, int R2, int R3) {
        if (R1 <= resourceQ[0] && R2 <= resourceQ[1] && R3 <= resourceQ[2]) {
            resourceQ[0] = resourceQ[0] - R1;
            resourceQ[1] = resourceQ[1] - R2;
            resourceQ[2] = resourceQ[2] - R3;
            resourcesScript.setResource1 (resourceQ[0].ToString ());
            resourcesScript.setResource2 (resourceQ[1].ToString ());
            resourcesScript.setResource3 (resourceQ[2].ToString ());
            return true;
        } else {
            return false;
        }
    }

    public void IncreaseResources (int R1, int R2, int R3) {
        resourceQ[0] = resourceQ[0] + R1;
        resourceQ[1] = resourceQ[1] + R2;
        resourceQ[2] = resourceQ[2] + R3;
        resourcesScript.setResource1 (resourceQ[0].ToString ());
        resourcesScript.setResource2 (resourceQ[1].ToString ());
        resourcesScript.setResource3 (resourceQ[2].ToString ());
    }

    public void updateStructureState () {
        GameObject[] structures = GameObject.FindGameObjectsWithTag ("StructureTile");
        structureState = new StructureData[structures.Length];
        int i = 0;

        foreach (GameObject go in structures) {
            structureState[i] = new StructureData (go);
            i++;
        }
    }

    public void listStructureStateInConsole () {
        foreach (StructureData sd in structureState) {
            Debug.Log (" Current Structure:" + sd.name + "-::" + sd.position[0] + "," + sd.position[1]);
        }
    }

    public void increaseResourcesTick () {
        int R1 = 5;
        int R2 = 5;
        int R3 = 0;
        foreach (StructureData sd in structureState) {
            //Debug.Log("debug name: " + sd.name + " " + sd.duration);
            if (sd.name == "Structure" && sd.duration == 0) {
                R1 += sd.level * 5;
            } else if (sd.name == "StructureBlue" && sd.duration == 0) {
                R2 += sd.level * 5;
            }
        }

        Debug.Log ("increasingResources:" + R1 + " " + R2 + " " + R3);

        resourceQ[0] = resourceQ[0] + R1;
        resourceQ[1] = resourceQ[1] + R2;
        resourceQ[2] = resourceQ[2] + R3;
        resourcesScript.setResource1 (resourceQ[0].ToString ());
        resourcesScript.setResource2 (resourceQ[1].ToString ());
        resourcesScript.setResource3 (resourceQ[2].ToString ());
    }

    private void resourceqInit () {
        resourceQ = new int[3];
    }

    public int[] getResources () {
        return resourceQ;
    }

    public void setResources (int resource0, int resource1, int resource2) {
        resourceQ[0] = resource0;
        resourceQ[1] = resource1;
        resourceQ[2] = resource2;
    }

}