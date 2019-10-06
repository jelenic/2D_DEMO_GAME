//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    private ShipBuilding shipBuilding;
    private int numberOfButtons;
    private GameObject[] buttonList;


    //shipInventory
    private List<ShipData> finishedShips;
    private GameObject[] buttonList2;

    private void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "ShipToShipScene")
        {
            initButtonsShipInventory();
        }
    }



    public void initButtons()
    {
        //deleteButtonsShip();
        Debug.Log("called initButtons");
        shipBuilding = GameObject.Find("SceneManager").GetComponent<ShipBuilding>();
        numberOfButtons = shipBuilding.getNumberOfComponents();
        buttonList = new GameObject[numberOfButtons];
        for (int i = 0; i < numberOfButtons; i++)
        {

            //Debug.Log("initButtons: i:" + i);
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().setText("C:" + i);
            button.GetComponent<ButtonListButton>().setComponentToChange(i);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
            buttonList[i] = button;
        }
    }

    public void initButtonsShipInventory()
    {
        //deleteButtonsShip();
        Debug.Log("called initButtonsShipInventory");
        finishedShips = GameManager.instance.getFinishedShips();



        var listOfNumbers = finishedShips.GroupBy(x => x.name)
            .Select(x => new { Value = x.Key, Count = x.Count() })
            .OrderByDescending(x => x.Count);
        int i = 0;
        //Debug.Log("listOfNumbers count:" + listOfNumbers.Count());
        buttonList2 = new GameObject[listOfNumbers.Count()];
        foreach (var x in listOfNumbers)
        {
            //Debug.Log("Value: " + x.Value + " Count: " + x.Count);
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<ButtonListButton>().setText("Ship:" + x.Value + "(" + x.Count + ")");
            ShipData sd = new ShipData(x.Value);
            button.GetComponent<ButtonListButton>().setShipData(sd);
            button.GetComponent<ButtonListButton>().setNumberOfStoredUnits(x.Count);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
            buttonList2[i] = button;
            i++;
        }

    }


    public void deleteButtons()
    {
        foreach (GameObject button in buttonList)
        {
            Destroy(button);
        }
    }

    public void deleteButtonsShip()
    {
        foreach (GameObject button in buttonList2)
        {
            Destroy(button);
        }
    }

}
