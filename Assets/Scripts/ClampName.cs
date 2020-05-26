using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampName : MonoBehaviour
{
    [SerializeField]
    private Text player1Label;
    
    [SerializeField]
    private Text player2Label;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject nameTag1 = GameObject.Find("Player1").transform.Find("NameTag").gameObject;
        Vector3 namePos = Camera.main.WorldToScreenPoint(nameTag1.transform.position);
        player1Label.transform.position = namePos;

        GameObject nameTag2 = GameObject.Find("Player2").transform.Find("NameTag").gameObject;
        Vector3 namePos2 = Camera.main.WorldToScreenPoint(nameTag2.transform.position);
        player2Label.transform.position = namePos2;
    }
}
