//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    private ShipBuilding shipBuilding;
    private int numberOfButtons;
    private GameObject[] buttonList;


    //shipInventory
    private List<ShipData> finishedShips;

    private void Start()
    {
        initButtonsShipInventory();
    }



    public void initButtons()
    {
        shipBuilding = GameObject.Find("SceneManager").GetComponent<ShipBuilding>();
        numberOfButtons = shipBuilding.getNumberOfComponents();
        buttonList = new GameObject[numberOfButtons];
        for (int i = 0; i < numberOfButtons; i++)
        {
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
        finishedShips = GameManager.instance.getFinishedShips();


        var listOfNumbers = finishedShips.GroupBy(x => x.componentNumber)
            .Select(g => new { Value = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);
        int i = 0;
        //Debug.Log("listOfNumbers count:" + listOfNumbers.Count());
        buttonList = new GameObject[listOfNumbers.Count()];
        foreach (var x in listOfNumbers)
        {
            Debug.Log("Value: " + x.Value + " Count: " + x.Count);
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);
            button.GetComponent<ButtonListButton>().setText("Ship:" + x.Value + "(" + x.Count + ")");
            button.GetComponent<ButtonListButton>().setShipData(new ShipData(x.Value));
            button.transform.SetParent(buttonTemplate.transform.parent, false);
            buttonList[i] = button;
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

}
