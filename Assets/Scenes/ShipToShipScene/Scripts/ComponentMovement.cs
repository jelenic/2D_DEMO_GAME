using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentMovement : MonoBehaviour
{

    private float rotationSpeed;
    private Transform target;

    private GameObject ammo;

    private ShipPairList shipPairList;

    //private GameObject spawnPoint;

    // Object will follow parent transform automatically without additional commands


    // Start is called before the first frame update
    void Start()
    {
        shipPairList = GameObject.Find("SceneManager").GetComponent<ShipPairList>();
        ammo = shipPairList.returnAmmo(this.gameObject.name);
        InvokeRepeating("Fire", 1.0f, 0.6f);
        rotationSpeed = 3;
        Aim();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            rotateTowardTarget();
        }
    }

    private void rotateTowardTarget()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }


    void Fire()
    {
        Debug.Log("shipPairList:"+  shipPairList);
        Instantiate(ammo, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }

    void Aim()
    {
        Debug.Log("aiming");
        GameObject[] hostile = GameObject.FindGameObjectsWithTag("Hostile");
        float distance = Mathf.Infinity;
        foreach (GameObject singleObj in hostile)
        {
            Debug.Log("singleObj:"+ singleObj.name);
            float distance2 = Vector2.Distance(this.transform.position, singleObj.transform.position);
            if (distance2 < 0)
            {
                distance2 *= -1;
            }
            if (distance2 < distance)
            {
                distance = distance2;
                target = singleObj.transform;
            }
        }
    }
}
