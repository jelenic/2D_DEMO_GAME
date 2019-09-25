using System.Collections;
using System.Collections.Generic;
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
        name = "shipType: " + num.ToString();

    }

    public void setComponent(int num, int id)
    {
        componentList[num] = id;
    }

    public int getComponent(int num)
    {
        return componentList[num];
    }
}
