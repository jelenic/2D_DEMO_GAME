using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDetails : MonoBehaviour
{
    private ShipData shipData;

    public ShipData ShipData { get => shipData; set => shipData = value; }

    private ShipPairList shipPairList;




    // Start is called before the first frame update
    void Start()
    {
        //shipPairList = GameObject.Find("SceneManager").GetComponent<ShipPairList>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            GameObject componentObject = shipPairList.returnComponent("SimpleTurretComponent");
            GameObject pivotObject = shipPairList.returnPivot();
            Debug.Log("foreach component in shipDetails:" + componentObject.name);
            GameObject instantiatedComponent = Instantiate(componentObject, new Vector2((float)x,(float)y), Quaternion.identity);
            GameObject instantiatedPivot = Instantiate(pivotObject, new Vector2((float)x, (float)y), Quaternion.identity);
            instantiatedPivot.transform.SetParent(this.transform);
            instantiatedComponent.transform.SetParent(instantiatedPivot.transform);
            y -= 3;
            //instantiatedComponent.transform.position
        }
    }
}
