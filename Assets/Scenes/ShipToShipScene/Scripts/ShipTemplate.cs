using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTemplate : MonoBehaviour
{

    [SerializeField]
    private GameObject finalObject;

    private Vector2 mousePos;

    [SerializeField]
    private LayerMask allTilesLayer;


    private ShipData shipData;
    // Start is called before the first frame update
    void Start()
    {
        shipData = new ShipData(1);
        shipData.setComponent(0, 1);
    }

    // Update is called once per frame
    public void SetShipData(ShipData sD)
    {
        shipData = sD;
    }

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

                if (rayHit.collider == null)
                {
                    GameObject instantiatedObject = Instantiate(finalObject, transform.position, Quaternion.identity);
                    //Ship script = instantiatedObject.GetComponent<StructureInfo>();
                    ShipDetails shipDetails = instantiatedObject.GetComponent<ShipDetails>();
                    shipDetails.ShipData = shipData;
                    shipDetails.SpawnComponents();
                }
                else if (rayHit.collider == null && this.gameObject.tag == "BuildableTemplate")
                {
                    Instantiate(finalObject, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
        
    }
}
