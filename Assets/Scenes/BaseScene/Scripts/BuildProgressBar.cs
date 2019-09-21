using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildProgressBar : MonoBehaviour {
    [Header ("Stuff")]
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
        currentBar.transform.position = Camera.main.WorldToScreenPoint ((Vector3.up * 0.3f) + transform.position);
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
    }

    private void OnDestroy () {
        Destroy (currentBar);
    }

    private void spawnObject () {
        ObjectPairList other = GameObject.Find ("SceneManager").GetComponent (typeof (ObjectPairList)) as ObjectPairList;
        StructureInfo script = this.GetComponent<StructureInfo> ();
        //Debug.Log("script.Name:" + script.Name + ";;" + script.name);
        GameObject loadedObject = other.returnGameObject (script.Name);
        Vector2 structurePosition = new Vector2 (script.X, script.Y);
        //Debug.Log("loadedObject:" + loadedObject.name);
        GameObject instantiatedObject = Instantiate (loadedObject, structurePosition, Quaternion.identity);
        StructureInfo script2 = instantiatedObject.GetComponent<StructureInfo> ();
        script2.X = (int) structurePosition.x;
        script2.Y = (int) structurePosition.y;
        //script.name = structure.name;
        script2.Level = script.Level;
        Destroy (gameObject);
        GameManager.instance.Invoke("updateStructureState", 1f);
    }

    
}