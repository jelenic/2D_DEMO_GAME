//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryText : MonoBehaviour
{

    [SerializeField]
    private Text text;


    public void setText(string textT)
    {
        text.text = textT;
    }

}
