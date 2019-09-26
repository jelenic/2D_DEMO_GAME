//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    private ShipBuilding shipBuilding;
    private int numberOfButtons;
    private GameObject[] buttonList;



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


    public void deleteButtons()
    {
        foreach (GameObject button in buttonList)
        {
            Destroy(button);
        }
    }

}
