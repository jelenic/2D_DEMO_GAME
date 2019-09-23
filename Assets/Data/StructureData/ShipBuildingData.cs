using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
/*public class ShipBuildingData 
{
    public ShipData[] data;
    public ShipSaveData(GameObject[] structures)
    {
        data = new ShipData[structures.Length];

        for (int i = 0; i < structures.Length; i++)
        {
            StructureData structureData = new StructureData(structures[i]);
            //Debug.Log("debug structrue saving " + i + ". " + structureData.name + "-::" + structureData.position[0] + "," + structureData.position[1] + "==== duration: " + structureData.duration );
            data[i] = structureData;

        }

    }
}*/

[System.Serializable]
public class ShipData
{
    public int componentNumber;
    public int[] componentList;


    public ShipData(int num)
    {
        componentNumber = num;
        componentList = new int[num];

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
