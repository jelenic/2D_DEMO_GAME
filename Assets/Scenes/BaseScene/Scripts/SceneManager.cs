using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private int fieldSize;

    [SerializeField]
    private GameObject finalObject;

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

    void LoadSceneObjects()
    {

    }
}
