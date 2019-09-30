using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentMovement : MonoBehaviour
{

    public float rotationSpeed;
    public Transform target;

    private GameObject ammo;

    // Object will follow parent transform automatically without additional commands


    // Start is called before the first frame update
    void Start()
    {
        ammo = GameObject.Find("SceneManager").GetComponent<ShipPairList>().returnAmmo(this.gameObject.name);
        InvokeRepeating("Fire", 1.0f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Instantiate(ammo, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
