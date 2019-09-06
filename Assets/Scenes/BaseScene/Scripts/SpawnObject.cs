using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject sampleObject;

    public void AddObject()
    {
        Instantiate(sampleObject, Vector2.zero, Quaternion.identity);
    }
}
