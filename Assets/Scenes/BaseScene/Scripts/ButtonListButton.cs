//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private Text buttonText;

    private ShipBuilding shipBuilding;

    private int CC;




    //ShipToShip
    private ShipData shipToInstantiate;

    public void setShipData(ShipData sd)
    {
        shipToInstantiate = sd;
    }

    public void setText(string textT)
    {
        buttonText.text = textT;
    }



    public void setComponentToChange(int i)
    {
        CC = i;
    }

    public void OnClick()
    {
        Debug.Log("Component to change:" + CC);
        shipBuilding.setComponentToChange(CC);
    }

    public void OnClickSTSscene()
    {
        Debug.Log("componentNumber:" + shipToInstantiate.componentNumber + "componentList" + shipToInstantiate.componentList);
        this.GetComponent<SpawnObject>().SpawnShip(shipToInstantiate);
    }

    // Start is called before the first frame update
    void Awake()
    {
        shipBuilding = GameObject.Find("SceneManager").GetComponent<ShipBuilding>();
    }

}
