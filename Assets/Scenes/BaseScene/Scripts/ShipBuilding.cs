//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipBuilding : MonoBehaviour
{

    public ShipData ship;
    private int componentToChange;

    public Text ComponentText;


    public void newShip(int num)
    {
        ship = null;
        ship = new ShipData(num);
        Debug.Log("newShipInstantiated:" + num);
    }

    public void setComponentToChange(int num)
    {
        componentToChange = num;
    }

    public void changeComponent(int id)
    {
        ship.setComponent(componentToChange, id);
    }

    public void setComponentInfoText()
    {
        string textForTextView = "";
        int num = 0;
        Debug.Log("componentNumber:" + ship.componentNumber.ToString());
        foreach (int i in ship.componentList){
            textForTextView += (num + ":" + i + ";;");
        }
        Debug.Log("textToChange:" + textForTextView);
        ComponentText.text = textForTextView;

    }

    public int getNumberOfComponents()
    {
        return ship.componentNumber;
    }

    public void finishShip()
    {
        if (GameManager.instance.SpentResources(ship.componentNumber *50, ship.componentNumber * 50, 0))
        {
            GameManager.instance.addShipBuild(ship);
        }
        else
        {
            Debug.Log("MissingResources");
        }

        
    }
}
