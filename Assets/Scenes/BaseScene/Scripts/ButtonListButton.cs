using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private Text buttonText;

    private ShipBuilding shipBuilding;

    private int CC;

    public void setText(string textT)
    {
        buttonText.text = textT;
    }

    public void setCC(int i)
    {
        CC = i;
    }

    public void OnClick()
    {
        Debug.Log("Component to change:" + CC);
        shipBuilding.setComponentToChange(CC);
    }

    // Start is called before the first frame update
    void Awake()
    {
        shipBuilding = GameObject.Find("SceneManager").GetComponent<ShipBuilding>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
