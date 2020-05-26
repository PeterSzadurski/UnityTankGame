using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{

    [SerializeField]
    public Text playerWinsText = null;

    [SerializeField]
    private GameObject m_CurrentPlayer;
    private bool StopActions = false;
    public static string result = "";


    void Start()
    {
        if (playerWinsText != null)
        {
            playerWinsText.text = result;
        }
    }

    public GameObject CurrentPlayer()
    {
        if (StopActions)
        {
            return null;
        }
        else
        {
            return m_CurrentPlayer;
        }
    }

    public void SwapPlayer()
    {
        Debug.Log("Turn Swap");
        if (m_CurrentPlayer == GameObject.Find("Player1")) {
            m_CurrentPlayer = GameObject.Find("Player2");
        }
        else
        {
            m_CurrentPlayer = GameObject.Find("Player1");
        }
    }

    public void Action()
    {
        StopActions = !StopActions;
    }

    public void SetResult(string str)
    {
        result = str;
    }


}
