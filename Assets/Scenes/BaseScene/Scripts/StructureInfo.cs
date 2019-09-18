using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StructureInfo : MonoBehaviour
{

    private Transform transform;
    private string id;
    private int x, y, level;
    private string name, type;
    private int constructionTimeBase, constructionScaling;
    private int mainValue, valueScaling;
    private int health, healthScaling;
    private float duration;

    //private GameObject mainCanvas;
    private GameObject singleStructureMenu;
    private Text levelText, nameText;
    private Button upgradeBtn;

    private Transform selectedObject;

    public Transform Transform { get => transform; set => transform = value; }
    public string Id { get => id; set => id = value; }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    public int Level { get => level; set => level = value; }
    public float Duration { get => duration; set => duration = value; }
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
        if (objName != "ConstructionSite")
        {
            name = objName;
        }
        Debug.Log(name + " " + level.ToString() + " " + x.ToString() + " " + y.ToString());

        //mainCanvas = GameObject.Find("MainCanvas");
        singleStructureMenu = GameObject.Find("MainCanvas").transform.Find("SingleStructureMenu").gameObject;
        levelText = singleStructureMenu.transform.Find("LevelText").gameObject.GetComponent<Text>();
        nameText = singleStructureMenu.transform.Find("NameText").gameObject.GetComponent<Text>();
        upgradeBtn = singleStructureMenu.transform.Find("UpgradeBtn").gameObject.GetComponent<Button>();

        upgradeBtn.onClick.AddListener(delegate { upgradeBuilding(); });

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseDown()
    {
        if (singleStructureMenu != null)
        {
            levelText.text = "StructureLevel:" + level;
            nameText.text = "StructureName:" + name;
            singleStructureMenu.SetActive(true);
            Debug.Log("StructureLevel:" + level + "StructureName:" + name);
            selectedObject = gameObject.transform;

        }
        else
        {
            Debug.Log("singleStructureMenu je null");
        }
    }

    void upgradeBuilding()
    {
        if (gameObject.name.Contains("ConstructionSite") || selectedObject != gameObject.transform)
        {

            return;
        }
        Debug.Log("Name of the object:" + gameObject.name);
        ObjectPairList other = GameObject.Find("SceneManager").GetComponent(typeof(ObjectPairList)) as ObjectPairList;
        GameObject constructionObject = other.returnGameObject("ConstructionSite");
        GameObject instantiatedObject = Instantiate(constructionObject, gameObject.transform.position, Quaternion.identity);
        StructureInfo script = instantiatedObject.GetComponent<StructureInfo>();
        script.X = x;
        script.Y = y;
        //Debug.Log("UpgradingObject");
        script.Name = name;
        script.Level = level + 1;
        Destroy(gameObject);
        singleStructureMenu.SetActive(false);

    }






}
