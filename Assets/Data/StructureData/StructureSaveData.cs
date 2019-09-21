using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StructureSaveData
{
    public StructureData[] data;
    public StructureSaveData(GameObject[] structures){
        data = new StructureData[structures.Length];

        for (int i = 0; i < structures.Length; i++)
        {
            StructureData structureData = new StructureData(structures[i]);
            //Debug.Log("debug structrue saving " + i + ". " + structureData.name + "-::" + structureData.position[0] + "," + structureData.position[1] + "==== duration: " + structureData.duration );
            data[i] = structureData;
            
        }

    }
}

[System.Serializable]
public class StructureData {
    public float[] position;
    public string name;
    public int level;
    public float duration;

    public StructureData(GameObject structure) {
        StructureInfo structureInfo = structure.GetComponent<StructureInfo>();
        name = structureInfo.Name;
        if (structure.name.Contains("Construction")) {
            duration = structure.GetComponent<BuildProgressBar>().duration;
            name = structureInfo.Name;

        } else duration = 0.0f;
        level = structureInfo.Level; // structure.level;
        position = new float[2];
        position[0] = structure.transform.position.x;
        position[1] = structure.transform.position.y;

    }
}
