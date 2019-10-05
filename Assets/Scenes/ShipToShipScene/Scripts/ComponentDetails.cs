using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentDetails : MonoBehaviour
{
    private string type;
    private string name;
    private float value1; // damage, health or shield
    private float value2; // rateOfFire or regen
    private GameObject component;

    private void Start()
    {
        component = this.gameObject;
        name = gameObject.name;
        
        switch (name)
        {
            case "SimpleTurretComponent(Clone)":
                type = "kineticDmg";
                value1 = 5f;
                value2 = 5f;
                return;
            /*case "Ship2":
                return shipObjects[1];
            case "Ship3":
                return shipObjects[2];*/
            default:
                Debug.Log("ComponentDetails: default");
                type = "empty";
                return;
        }
    }

}
