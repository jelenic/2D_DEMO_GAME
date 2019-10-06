using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDetails : MonoBehaviour
{
    private ShipData shipData;

    public ShipData ShipData { get => shipData; set => shipData = value; }

    private ShipPairList shipPairList;



    public void SpawnComponents()
    {
        shipPairList = GameObject.Find("SceneManager").GetComponent<ShipPairList>();

       // Debug.Log("ShipDetails shipPairList:" + shipPairList);
       // Debug.Log("ShipDetails shipData:" + shipData);
        int componentNumber = shipData.componentNumber;
        int[] componentList = shipData.componentList;

        double x,y;
        x = this.transform.position.x;

        if (componentList.Length % 2 == 0)
        {
            y = this.transform.position.y + 1.5 * (componentNumber - 1) * 2 - 0.75;
        }
        else
        {
            y = this.transform.position.y + 1.5 * (componentNumber -1) * 2;
        }

        foreach (int component in componentList)
        {
            //Debug.Log(shipPairList);
            //always sets simpleTurretComponent WRONG
            GameObject componentObject = shipPairList.returnComponentID(component);
            GameObject pivotObject = shipPairList.returnPivot();
            GameObject instantiatedPivot = Instantiate(pivotObject, new Vector2((float)x, (float)y), Quaternion.identity);
            instantiatedPivot.transform.SetParent(this.transform);
            if (componentObject != null)
            {
                Debug.Log("foreach component in shipDetails:" + componentObject.name);
                GameObject instantiatedComponent = Instantiate(componentObject, new Vector2((float)x, (float)y), Quaternion.identity);
                instantiatedComponent.transform.SetParent(instantiatedPivot.transform);
            }
            else
            {
                Debug.Log("foreach component in shipDetails:" + "null");
            }
            y -= 3;
        }
    }
}
