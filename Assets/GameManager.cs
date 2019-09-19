using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null; //Static instance of GameManager which allows it to be accessed by any other script.

    private ResourcesScript ResourcesScript;
    private string resourceText1 = "";
    private Button gmBtn;

    public void setResourceText1 (string text) {
        resourceText1 = text;
        ResourcesScript.setResource1 (text);
    }

    //Awake is always called before any Start functions
    void Awake () {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy (gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad (gameObject);

    }

    void Start () {
        ResourcesScript = GameObject.Find("MainCanvas").GetComponent<ResourcesScript> ();
        gmBtn = GameObject.Find("MainCanvas").transform.Find("gmBtn").gameObject.GetComponent<Button>();

        gmBtn.onClick.AddListener(delegate { setResourceText1("lol"); });

        
    }

    

}