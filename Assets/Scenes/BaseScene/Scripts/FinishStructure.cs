using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStructure : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        ObjectPairList other = GameObject.Find("SceneManager").GetComponent(typeof(ObjectPairList)) as ObjectPairList;
        StructureInfo script = this.GetComponent<StructureInfo>();
        Debug.Log("script.Name:" + script.Name + ";;" + script.name);
        GameObject loadedObject = other.returnGameObject(script.Name);
        Vector2 structurePosition = new Vector2(script.X, script.Y);
        Debug.Log("loadedObject:" + loadedObject.name);
        GameObject instantiatedObject = Instantiate(loadedObject, structurePosition, Quaternion.identity);
        StructureInfo script2 = instantiatedObject.GetComponent<StructureInfo>();
        script2.X = (int)structurePosition.x;
        script2.Y = (int)structurePosition.y;
        //script.name = structure.name;
        script2.Level = script.Level;
        Destroy(gameObject);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
