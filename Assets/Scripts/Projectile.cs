using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private GameObject Explosion;

    private float force = 500;
    private Rigidbody rb;
    private bool landed = false; // the collisionEnter triggers twice sometimes
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * force);

    }

    void Update()
    {
        if (this.transform.position.y < -50)
        {
            GameObject.Find("TurnController").GetComponent<Turn>().SwapPlayer();
            GameObject.Find("TurnController").GetComponent<Turn>().Action();
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (!landed)
        {
            Instantiate(Explosion, this.transform.position, this.transform.rotation);
            landed = true;
            Destroy(this.gameObject);

        }
    }
}
