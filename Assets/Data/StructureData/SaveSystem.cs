using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveStructures(GameObject[] structures) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/structures.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        StructureSaveData saveData = new StructureSaveData(structures);
        formatter.Serialize(stream, saveData);
        stream.Close();
    }
    public static StructureSaveData LoadStructures() {
        string path = Application.persistentDataPath + "/structures.data";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            StructureSaveData saveData = formatter.Deserialize(stream) as StructureSaveData;
            stream.Close();
            return saveData;

        } else {
            Debug.LogError("no file at " + path);
            return null;
        }
    }
    public static void SaveShips(List<ShipData> shipsInProgress, List<ShipData> finishedShips) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ships.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        ShipsBuildingData saveData = new ShipsBuildingData(shipsInProgress, finishedShips);
        formatter.Serialize(stream, saveData);
        stream.Close();
    }
    public static ShipsBuildingData LoadShips() {
        string path = Application.persistentDataPath + "/ships.data";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShipsBuildingData saveData = formatter.Deserialize(stream) as ShipsBuildingData;
            stream.Close();
            return saveData;

        } else {
            Debug.LogError("no file at " + path);
            return null;
        }
    }
}
