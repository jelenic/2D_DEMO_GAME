//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildProgressBar : MonoBehaviour {
    [Header ("ProgressBar")]
    public Image progressBar;

    private GameObject barCanvas;

    private Image currentBar;
    private float maxDuration;
    public float duration;

    // Start is called before the first frame update
    void Start () {
        barCanvas = GameObject.Find ("BarsCanvas");
        maxDuration = 5f;
        float tempDuration = this.GetComponent<StructureInfo> ().Duration;
        if (tempDuration > 0) {
            duration = tempDuration;

        } else duration = 5f;

        displayBar ();

    }

    // Update is called once per frame
    void Update () {
        duration -= Time.deltaTime;
        setProgressBar (duration / maxDuration);

        if (duration <= 0) {
            spawnObject ();

        }
        //Debug.Log("currentBar:");
    }

    void setProgressBar (float value) {
        currentBar.fillAmount = value;
    }

    void displayBar () {
        currentBar = Instantiate (progressBar, transform.position, Quaternion.identity);
        currentBar.transform.SetParent (barCanvas.transform, false);
        currentBar.transform.position = Camera.main.WorldToScreenPoint ((Vector3.up * 0.3f) + transform.position);

    }

    private void OnDestroy () {
        Destroy (currentBar.gameObject);
    }

    private void spawnObject () {
        ObjectPairList objPairList = GameObject.Find ("SceneManager").GetComponent (typeof (ObjectPairList)) as ObjectPairList;
        StructureInfo constructionInfo = this.GetComponent<StructureInfo> ();
        //Debug.Log("script.Name:" + script.Name + ";;" + script.name);
        GameObject loadedObject = objPairList.returnGameObject (constructionInfo.Name);
        Vector2 structurePosition = new Vector2 (constructionInfo.X, constructionInfo.Y);
        //Debug.Log("loadedObject:" + loadedObject.name);
        GameObject instantiatedObject = Instantiate (loadedObject, structurePosition, Quaternion.identity);
        StructureInfo structureInfo = instantiatedObject.GetComponent<StructureInfo> ();
        structureInfo.X = (int) structurePosition.x;
        structureInfo.Y = (int) structurePosition.y;
        //script.name = structure.name;
        structureInfo.Level = constructionInfo.Level;
        Destroy (gameObject);
        GameManager.instance.Invoke("updateStructureState", 1f);
    }

    
}