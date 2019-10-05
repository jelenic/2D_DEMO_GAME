using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPairList : MonoBehaviour
{

    [SerializeField]
    private GameObject[] componentObjects;

    [SerializeField]
    private GameObject[] shipObjects;

    [SerializeField]
    private GameObject[] ammo;

    [SerializeField]
    private GameObject[] shipTemplates;

    [SerializeField]
    private GameObject emptyObj;

    public GameObject returnShip(string name)
    {

        Debug.Log("Ship (name): " + name);
        switch (name)
        {
            case "Ship1":
                return shipObjects[0];
            /*case "Ship2":
                return shipObjects[1];
            case "Ship3":
                return shipObjects[2];*/
            default:
                Debug.Log("default");
                return null;
        }
    }

    public GameObject returnComponent(string name)
    {

        Debug.Log("Component (name): " + name);
        switch (name)
        {
            case "SimpleTurretComponent":
                return componentObjects[0];
            /*case "Component2":
                return componentObjects[1];
            case "Component33":
                return componentObjects[2];*/
            default:
                Debug.Log("default");
                return null;
        }
    }

    public GameObject returnComponentID(int id)
    {

        Debug.Log("Component (id): " + id);
        switch (id)
        {
            case 1:
                return componentObjects[0];
            /*case "Component2":
                return componentObjects[1];
            case "Component33":
                return componentObjects[2];*/
            default:
                Debug.Log("default");
                return null;
        }
    }

    public GameObject returnAmmo(string name)
    {

        Debug.Log("Component (name) Ammo: " + name);
        switch (name)
        {
            case "SimpleTurretComponent(Clone)":
                return ammo[0];
            /*case "Component2":
                return ammo[1];
            case "Component33":
                return ammo[2];*/
            default:
                return ammo[0];
        }
    }

    public GameObject returnPivot()
    {
        return emptyObj;
    }

    public GameObject returnShipTemplate(int num)
    {
        switch (num)
        {
            case 1:
                return shipTemplates[0];
            case 2:
                return shipTemplates[1];
            /*case "Ship3":
                return shipObjects[2];*/
            default:
                Debug.Log("default");
                return null;
        }
    }
}
