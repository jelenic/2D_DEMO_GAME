//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject sampleObject;



    //shipProperties
    private ShipData shipData;
    private GameObject spawnedShip;

    public void AddObject()
    {
        Instantiate(sampleObject, Vector2.zero, Quaternion.identity);
    }

    public void SpawnShip(ShipData sd)
    {
        shipData = sd;
        sampleObject = GameObject.Find("SceneManager").GetComponent<ShipPairList>().returnShipTemplate(sd.componentNumber);
        //shipData.setComponent(0, 1);
        //shipData.setComponent(1, 1);
        spawnedShip = Instantiate(sampleObject, Vector2.zero, Quaternion.identity);
        spawnedShip.GetComponent<ShipTemplate>().ShipData = shipData;
        //Debug.Log("Button shipData:" + shipData.name + shipData.componentList);

    }

}
