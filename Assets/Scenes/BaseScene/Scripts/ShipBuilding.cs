using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipBuilding : MonoBehaviour
{

    public ShipData ship;
    private int componentToChange;

    public Text ComponentText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newShip(int num)
    {
        ship = null;
        Debug.Log(num.ToString());
        ship = new ShipData(num);
        Debug.Log("ship is new");
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
        // Debug.Log("FinishedShip:" + "numberOfComponents:" + ship.componentNumber + ";;");
        // foreach (int component in ship.componentList)
        // {
        //     Debug.Log("component:" + component);
        // }

        GameManager.instance.addShip(ship);


        
    }
}
