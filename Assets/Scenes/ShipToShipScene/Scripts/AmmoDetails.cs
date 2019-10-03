using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDetails : MonoBehaviour
{
    private float BulletForce;
    //private float maxVelocity;
    private Rigidbody2D rb;
    private Transform bullet;
    //public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        BulletForce = 500;
        //maxVelocity = 1400;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
        rb.AddForce(transform.up * BulletForce);
        bullet = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Hostile")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.name);

        if (collision.gameObject.tag == "Hostile")
        {
            Destroy(gameObject, 0.0f);
        }


    }


    /*private void OnDestroy()
    {
        Instantiate(explosion, bullet.position, bullet.rotation);
    }*/

}
