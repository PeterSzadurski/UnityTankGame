using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float minSize = 1;
    private float radius = 2.5f;
    private Vector3 maxSize = new Vector3(2.5f, 2.5f, 2.5f);
    private float startTime = 0;
    private float endTime = 1f;
    private float precent;
    private bool finished = false;

    private bool p1Damaged = false;
    private bool p2Damaged = false;

    private float exposiveForce = 350;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (precent < 1)
        {
            startTime += Time.deltaTime;
            precent = startTime / endTime;
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, maxSize, precent);
        }
        else
        {
            if (!finished)
            {
                finished = true;
                GameObject.Find("TurnController").GetComponent<Turn>().SwapPlayer();
                GameObject.Find("TurnController").GetComponent<Turn>().Action();
                Destroy(this.gameObject);
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            Destroy(collision.gameObject);
        }
        if (!p1Damaged && collision.gameObject.tag == "Player1")
        {
            GameObject player = GameObject.Find("Player1");
            p1Damaged = true;
            player.GetComponent<Tank>().TakeDamage("Player1");
            player.GetComponent<Rigidbody>().AddExplosionForce(exposiveForce, transform.position, radius);
        }
        if (!p2Damaged && collision.gameObject.tag == "Player2")
        {
            GameObject player = GameObject.Find("Player2");
            p2Damaged = true;
            player.GetComponent<Tank>().TakeDamage("Player2");
        }
    }
}
