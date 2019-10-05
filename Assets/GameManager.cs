using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    #region GameManager
    public static GameManager instance = null; //Static instance of GameManager which allows it to be accessed by any other script.

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
        InvokeRepeating ("increaseResourcesTick", 0.2f, 2f);

        resourcesScript = GameObject.Find ("MainCanvas").GetComponent<ResourcesScript> ();
        finishedShips = new List<ShipData>();
        shipsInProgress = new List<ShipData>();

    }

    #endregion

    #region ShipState
    private List<ShipData> finishedShips;

    private List<ShipData> shipsInProgress;


    public void addShipBuild(ShipData ship) {
        if (shipsInProgress.Count == 0) {
            InvokeRepeating("updateShipQueue", 0.2f, 1f);
            Debug.Log("invoking repeating");
        } 
        shipsInProgress.Add(ship);
        Debug.Log("adding ship to queue " + ship.componentNumber + " : " + ship.duration);
    }

    private void updateShipQueue() {
        shipsInProgress[0].duration -= 1;
        if (shipsInProgress[0].duration == 0) {
            addFinishedShip(shipsInProgress[0]);
            Debug.Log("adding finished ship to inventory " + shipsInProgress[0].componentNumber);
            shipsInProgress.RemoveAt(0);
            if (shipsInProgress.Count == 0) {
                CancelInvoke("updateShipQueue");
                Debug.Log("canceling repeating");
            }
        }
    }

    public void addFinishedShip (ShipData ship) {
        Debug.Log ("adding finished ship: " + ship.componentNumber);
        finishedShips.Add (ship);
    }

    public void printShips () {
        Debug.Log("printing finishedShips start " );
        foreach (var ship in finishedShips) 
        {
            Debug.Log("shipp: " + ship.componentNumber);
        }
        Debug.Log("printing finishedShips end");

        Debug.Log("printing shipsInProgress start " );
        foreach (var ship in shipsInProgress) 
        {
            Debug.Log("shipp: " + ship.componentNumber + " : " + ship.duration);
        }
        Debug.Log("printing shipsInProgress end");
    }

    public List<ShipData> getShipsInProgress() {
        return shipsInProgress;
    }

    public List<ShipData> getFinishedShips() {
        return finishedShips;
    }

    public void setShipsInProgress(List<ShipData> ships) {
        if (ships.Count > 0) {
            shipsInProgress = ships;
            InvokeRepeating("updateShipQueue", 0.2f, 1f);
        }
    }

    public void setFinishedShips(List<ShipData> ships) {
        if (ships.Count > 0) {
            finishedShips = ships;
        }
    }

    #endregion

    #region ResourcesState
    private ResourcesScript resourcesScript;

    private int[] resourceQ;

    public bool SpentResources (int R1, int R2, int R3) {
        if (R1 <= resourceQ[0] && R2 <= resourceQ[1] && R3 <= resourceQ[2]) {
            resourceQ[0] = resourceQ[0] - R1;
            resourceQ[1] = resourceQ[1] - R2;
            resourceQ[2] = resourceQ[2] - R3;
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BaseScene")
            {
                resourcesScript.setResource1(resourceQ[0].ToString());
                resourcesScript.setResource2(resourceQ[1].ToString());
                resourcesScript.setResource3(resourceQ[2].ToString());
            }
            return true;
        } else {
            return false;
        }
    }

    public void IncreaseResources (int R1, int R2, int R3) {
        resourceQ[0] = resourceQ[0] + R1;
        resourceQ[1] = resourceQ[1] + R2;
        resourceQ[2] = resourceQ[2] + R3;
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BaseScene")
        {
            resourcesScript.setResource1(resourceQ[0].ToString());
            resourcesScript.setResource2(resourceQ[1].ToString());
            resourcesScript.setResource3(resourceQ[2].ToString());
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
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BaseScene")
        {
            resourcesScript.setResource1(resourceQ[0].ToString());
            resourcesScript.setResource2(resourceQ[1].ToString());
            resourcesScript.setResource3(resourceQ[2].ToString());
        }
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
    #endregion

    #region StructureState
    private StructureData[] structureState;
    public void updateStructureState () {
        GameObject[] structures = GameObject.FindGameObjectsWithTag ("StructureTile");
        structureState = new StructureData[structures.Length];
        int i = 0;

        foreach (GameObject go in structures) {
            structureState[i] = new StructureData (go);
            i++;
        }
    }
    #endregion


    #region Scenes
    public void LoadSceneSTS()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ShipToShipScene");
        //GameObject.Find("ShipInventory").GetComponent<ButtonListControl>().initButtonsShipInventory();
    }
    #endregion Scenes
}
