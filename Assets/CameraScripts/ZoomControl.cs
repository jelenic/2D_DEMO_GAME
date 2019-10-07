using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {

        }
        else
        {
            //up
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (GetComponent<Camera>().orthographicSize > 2)
                {
                    GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize - 0.2f;
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (GetComponent<Camera>().orthographicSize < 15)
                {
                    GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize + 0.2f;
                }
            }
        }
    }
}
