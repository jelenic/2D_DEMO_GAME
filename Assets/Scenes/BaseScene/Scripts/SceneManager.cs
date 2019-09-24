using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {
    [SerializeField]
    private int fieldSize;

    [SerializeField]
    private GameObject finalObject;

    // [SerializeField]
    // private GameObject objectPairList;

    private Vector2 position;

    // Start is called before the first frame update
    void Start () {
        PrintFloor ();

    }

    // Update is called once per frame
    void Update () {

    }

    void PrintFloor () {

        int i;
        for (i = fieldSize * (-1); i <= fieldSize; i++) {
            int j;
            for (j = fieldSize * (-1); j <= fieldSize; j++) {
                position = new Vector2 (i, j);
                Instantiate (finalObject, position, Quaternion.identity);
            }
        }
    }

    public void SaveSceneObjects () {
        GameObject[] structures = GameObject.FindGameObjectsWithTag ("StructureTile");
        SaveSystem.SaveStructures (structures);

        GameManager.instance.updateStructureState ();
        GameManager.instance.listStructureStateInConsole ();

        // saving resources
        PlayerPrefs.SetInt ("Resource0", GameManager.instance.getResources()[0]);
        PlayerPrefs.SetInt ("Resource1", GameManager.instance.getResources()[1]);
        PlayerPrefs.SetInt ("Resource2", GameManager.instance.getResources()[2]);


        GameManager.instance.getShips();

    }

    public void LoadSceneObjects () {

        //getting resources
        GameManager.instance.setResources(PlayerPrefs.GetInt("Resource0"), 
                                            PlayerPrefs.GetInt("Resource1"), 
                                            PlayerPrefs.GetInt("Resource2"));        

        DeleteAll ("StructureTile");
        StructureData[] data = SaveSystem.LoadStructures ().data;

        foreach (StructureData structure in data) {
            //print ("name " + structure.name);
            Vector2 structurePosition = new Vector2 (structure.position[0], structure.position[1]);
            // GameObject go = GameObject.Find("SceneManager");
            ObjectPairList other = this.GetComponent (typeof (ObjectPairList)) as ObjectPairList;
            string nameToReturn = structure.name;
            GameObject loadedObject;
            //Debug.Log (nameToReturn);
            if (nameToReturn.EndsWith ("(Clone)")) {
                //Debug.Log(nameToReturn.Split('(')[0].Trim());
                loadedObject = other.returnGameObject (nameToReturn.Split ('(') [0].Trim ());
            } else {
                loadedObject = other.returnGameObject (nameToReturn);
            }
            //Modified
            if (structure.duration > 0) {
                loadedObject = other.returnGameObject ("ConstructionSite");
            }
            GameObject instantiatedObject = Instantiate (loadedObject, structurePosition, Quaternion.identity);
            StructureInfo script = instantiatedObject.GetComponent<StructureInfo> ();
            script.X = (int) structurePosition.x;
            script.Y = (int) structurePosition.y;
            script.Name = structure.name;
            script.Level = structure.level;
            script.Duration = structure.duration;

        }
        GameManager.instance.Invoke("updateStructureState", 0.1f);


    }

    public void DeleteAll (string tag) {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag (tag)) {
            Destroy (o);
        }
    }

}