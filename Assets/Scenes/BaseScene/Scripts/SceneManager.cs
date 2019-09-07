using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private int fieldSize;

    [SerializeField]
    private GameObject finalObject;

    [SerializeField]
    private GameObject structureObject;

    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        PrintFloor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void PrintFloor()
    {
        
        int i;
        for (i = fieldSize*(-1); i <= fieldSize; i++)
        {
            int j;
            for (j = fieldSize * (-1); j <= fieldSize; j++)
            {
                position = new Vector2(i, j);
                Instantiate(finalObject, position, Quaternion.identity);
            }
        }
    }

    public void SaveSceneObjects() {
        GameObject[] structures = GameObject.FindGameObjectsWithTag("StructureTile") ;
        SaveSystem.SaveStructures(structures);
    }
    public void LoadSceneObjects()
    {
        StructureData[] data = SaveSystem.LoadStructures().data;

        PrintFloor();
        foreach (StructureData structure in data)
        {
            Vector2 structurePosition = new Vector2(structure.position[0], structure.position[1]);
            Instantiate(structureObject, structurePosition, Quaternion.identity);
            
        }





    }


}
