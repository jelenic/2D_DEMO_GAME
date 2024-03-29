﻿using UnityEngine;
//using System.Collections;
using System;

public class TemplateScript : MonoBehaviour
{

    [SerializeField]
    private GameObject finalObject;

    [SerializeField]
    private GameObject constructionObject;

    private Vector2 mousePos;

    [SerializeField]
    private LayerMask allTilesLayer;

    // Update is called once per frame
    void Update()
    {

        //Compuet controls
        #region AndroidControls
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            //Debug.Log("MOBILE PLATFORM");
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, allTilesLayer);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                touchPosition.x = (float)Math.Round(touchPosition.x, 0);
                touchPosition.y = (float)Math.Round(touchPosition.y, 0);
                transform.position = touchPosition;

                // Handle finger movements based on touch phase.
                switch (touch.phase)
                {
                    // Report that a direction has been chosen when the finger is lifted.
                    case TouchPhase.Ended:
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
                            Destroy(gameObject);
                        }
                        else
                        {
                            Destroy(gameObject);
                        }
                        break;
                }
            }
        }
        #endregion AndroidControls
        else
        {
            //Debug.Log("PC PLATFORM");
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, allTilesLayer);

                if (rayHit.collider != null)
                {
                    Debug.Log(rayHit.collider.gameObject.tag.ToString());
                    if (rayHit.collider.gameObject.tag == "BuildableTile" && this.gameObject.tag == "StructureTemplate")
                    {
                        //Instantiate(finalObject, transform.position, Quaternion.identity);
                        if (GameManager.instance.SpentResources(5,5,0))
                        {
                            GameObject instantiatedObject = Instantiate(constructionObject, transform.position, Quaternion.identity);
                            StructureInfo script = instantiatedObject.GetComponent<StructureInfo>();
                            script.X = (int)transform.position.x;
                            script.Y = (int)transform.position.y;
                            Debug.Log("finalObject name:" + finalObject.name);
                            script.Name = finalObject.name;
                            script.Level = 1;
                        }
                        else
                        {
                            Debug.Log("MissingResources");
                        }
                        
                    }
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
