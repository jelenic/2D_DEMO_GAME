using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTextControll : MonoBehaviour
{
    [SerializeField]
    private GameObject textTemplate;

    private GameObject[] textList;
    private List<ShipData> finishedShips;
    private int numberOfTexts;


    public void initTexts()
    {
        finishedShips = GameManager.instance.getFinishedShips();
        numberOfTexts = finishedShips.Count;
        textList = new GameObject[numberOfTexts + 1];
        int i = 0;
        foreach (ShipData singleShip in finishedShips)
        {
            i++;
            GameObject simpleText = Instantiate(textTemplate) as GameObject;
            simpleText.SetActive(true);

            simpleText.GetComponent<InventoryText>().setText(singleShip.name);
            simpleText.transform.SetParent(textTemplate.transform.parent, false);
            textList[i] = simpleText;
        }
    }

    public void deleteTexts()
    {
        foreach (GameObject simpleText in textList)
        {
            //Debug.Log("Deleting text");
            Destroy(simpleText);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
