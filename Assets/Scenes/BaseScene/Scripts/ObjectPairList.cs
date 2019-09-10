using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPairList : MonoBehaviour
{
    [SerializeField]
    private GameObject[] structureObjects;

    public GameObject returnGameObject(string name) {

        Debug.Log("returnnn " + name);
        switch (name)
        {
            case "Structure":
                Debug.Log("1 ");
                return structureObjects[0];
            case "StructureBlue":
                Debug.Log("2 ");
                return structureObjects[1];
            case "ConstructionSite":
                Debug.Log("constructionSite");
                return structureObjects[2];
            case "Structure3":
                Debug.Log("nulll");
                return null;
            case "Structure4":
                Debug.Log("nulll");
                return null;
            default:
                Debug.Log("default");
                return null;
        }
    }
}
