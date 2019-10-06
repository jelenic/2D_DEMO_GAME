using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipTemplate : MonoBehaviour
{

    [SerializeField]
    private GameObject finalObject;

    private Vector2 mousePos;

    [SerializeField]
    private LayerMask allTilesLayer;


    private ShipData shipData;

    //btn text
    private ButtonListButton btb;


    public ButtonListButton Btb { get => btb; set => btb = value; }
    public ShipData ShipData { get => shipData; set => shipData = value; }

    private Text buttonText;
    private string textForBtn;
    private int maxSpawnableObjects;
    // Start is called before the first frame update
    void Start()
    {
        buttonText = Btb.getText();
        textForBtn = buttonText.text.Split('(')[0];
        maxSpawnableObjects = Btb.getNumberOfStoredUnits();
        Debug.Log("maxSpawnableObjects:" + maxSpawnableObjects);

    }

    // Update is called once per frame
    /*public void SetShipData(ShipData sD)
    {
        shipData = sD;
    }*/

    void Update()
    {

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {

        }
        else
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, allTilesLayer);

                if (rayHit.collider == null && maxSpawnableObjects>0)
                {
                    GameObject instantiatedObject = Instantiate(finalObject, transform.position, Quaternion.identity);
                    ShipDetails shipDetails = instantiatedObject.GetComponent<ShipDetails>();
                    shipDetails.ShipData = shipData;
                    shipDetails.SpawnComponents();
                    maxSpawnableObjects--;
                    Btb.setText(textForBtn + "(" + maxSpawnableObjects + ")");
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
        
    }
}
