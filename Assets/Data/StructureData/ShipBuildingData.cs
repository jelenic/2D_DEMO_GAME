using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public class ShipsBuildingData 
{
    public List<ShipData> shipsInProgress;
    public List<ShipData> finishedShips;
    public ShipsBuildingData(List<ShipData> shipsInProgress, List<ShipData> finishedShips)
    {
        this.shipsInProgress = shipsInProgress;
        this.finishedShips = finishedShips;
    }
}

[System.Serializable]
public class ShipData
{
    public int componentNumber;
    public int[] componentList;

    public int duration;
    public string name;


    public ShipData(int num)
    {
        componentNumber = num;
        componentList = new int[num];
        duration = num * 5;
        name = "shipType: " + num.ToString() + String.Concat(Enumerable.Repeat("0", num));

    }

    public void setComponent(int num, int id)
    {
        componentList[num] = id;
        determineName();
    }

    public int getComponent(int num)
    {
        return componentList[num];
    }

    public void determineName()
    {
        string listPart = "";
        foreach (int i in componentList)
        {
            listPart += i;
        }
        name = "shipType: " + componentNumber + listPart;
    }
}
