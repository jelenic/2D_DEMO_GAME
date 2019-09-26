//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class ObjectPairList : MonoBehaviour
{
    [SerializeField]
    private GameObject[] structureObjects;

    public GameObject returnGameObject(string name) {

        Debug.Log("ObjectPairList (name): " + name);
        switch (name)
        {
            case "Structure":
                return structureObjects[0];
            case "StructureBlue":
                return structureObjects[1];
            case "ConstructionSite":
                //Debug.Log("constructionSite");
                return structureObjects[2];
            case "Structure3":
                return null;
            case "Structure4":
                return null;
            default:
                Debug.Log("default");
                return null;
        }
    }
}
