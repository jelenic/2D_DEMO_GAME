using UnityEngine;
using System.Collections;

public class TemplateScript : MonoBehaviour
{

    [SerializeField]
    private GameObject finalObject;

    private Vector2 mousePos;

    [SerializeField]
    private LayerMask allTilesLayer;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, allTilesLayer);

            if (rayHit.collider != null)
            {
                Debug.Log(rayHit.collider.gameObject.tag.ToString());
                if (rayHit.collider.gameObject.tag == "BuildableTile")
                {
                    Debug.Log("BuildableTile");
                }
                if (rayHit.collider.gameObject.tag == "BuildableTile" && this.gameObject.tag == "StructureTemplate")
                {
                    Instantiate(finalObject, transform.position, Quaternion.identity);
                }
            }
            else if (rayHit.collider == null && this.gameObject.tag == "BuildableTemplate")
            {
                Instantiate(finalObject, transform.position, Quaternion.identity);
            }
        }
    }
}
