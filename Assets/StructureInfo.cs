using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureInfo : MonoBehaviour
{

    private Transform transform;
    private string id;
    private int x, y, level;
    private string name, type;
    private int constructionTimeBase, constructionScaling;
    private int mainValue, valueScaling;
    private int health, healthScaling;

    public Transform Transform { get => transform; set => transform = value; }
    public string Id { get => id; set => id = value; }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    public int Level { get => level; set => level = value; }
    public string Name { get => name; set => name = value; }
    public string Type { get => type; set => type = value; }
    public int ConstructionTimeBase { get => constructionTimeBase; set => constructionTimeBase = value; }
    public int ConstructionScaling { get => constructionScaling; set => constructionScaling = value; }
    public int MainValue { get => mainValue; set => mainValue = value; }
    public int ValueScaling { get => valueScaling; set => valueScaling = value; }
    public int Health { get => health; set => health = value; }
    public int HealthScaling { get => healthScaling; set => healthScaling = value; }

    // Start is called before the first frame update
    void Start()
    {
        string objName = gameObject.name.Split('(')[0].Trim();
        name = objName;
        Debug.Log(name + " " + level.ToString() + " " + x.ToString() + " " + y.ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    



}
