using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private float dragSpeed;
    private Vector2 dragOrigin;
    private Vector3 pos;

    private void Start()
    {
        pos = Camera.main.transform.position;
        dragSpeed = 0.7f;
    }


    void LateUpdate()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector2 pos = Camera.main.ScreenToViewportPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y) - dragOrigin);
        Vector2 move = new Vector2(pos.x * dragSpeed, pos.y * dragSpeed);

        transform.Translate(move, Space.World);*/

        if (Input.GetMouseButton(2))
        {
             pos -= new Vector3(Input.GetAxis("Mouse X") * dragSpeed, Input.GetAxis("Mouse Y") * dragSpeed,0);
        }
        Camera.main.transform.position = pos;
    }


}
