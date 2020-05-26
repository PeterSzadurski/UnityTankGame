using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour
{
    [SerializeField]
    private GameObject currentPlayer;

    [SerializeField]
    private GameObject turn;

    [SerializeField]
    private GameObject Projectile;

    // players health 
    int currentHealthPlayer1 = 5;
    int currentHealthPlayer2 = 5;

    // players health bars
    public HealthBar player1HealthBar;
    public HealthBar player2HealthBar;

    public AudioSource audioSrc;
    [SerializeField]
    private AudioSource HitSound;

    // Start is called before the first frame update
    void Start()
    {
        player1HealthBar.SetHealth(5);
        player2HealthBar.SetHealth(5);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(currentPlayer.name + " | " + this.gameObject.name);
        CheckWin();
        if (turn.GetComponent<Turn>().CurrentPlayer() == this.gameObject)
        {
            MoveTank();
            MoveCannon();
            Shoot();
       }
    }

    private void PlayTankShotSound()
    {
        audioSrc.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Death")
        {
            if(gameObject.tag == "Player1")
            {
                turn.GetComponent<Turn>().SetResult("Player 2 Wins!");
                SceneManager.LoadScene(0);
            }
            if (gameObject.tag == "Player2")
            {
                turn.GetComponent<Turn>().SetResult("Player 1 Wins!");
                SceneManager.LoadScene(0);
            }
        }
    }

    void CheckWin()
    {
        if (currentHealthPlayer2 == 0)
        {
            turn.GetComponent<Turn>().SetResult("Player 1 Wins!");
            SceneManager.LoadScene(2);
        }
        else if (currentHealthPlayer1 == 0)
        {
            turn.GetComponent<Turn>().SetResult("Player 2 Wins!");
            SceneManager.LoadScene(2);
        }
    }

     void MoveTank()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
        }
    }

    void MoveCannon()
    {
        GameObject pivot = this.transform.Find("Cannon").transform.Find("Pivot").gameObject;
        if (Input.GetKey(KeyCode.A))
        {
            // rotate left
            // pivot.transform.rotation = new Vector3(0, 0, -1);
            pivot.transform.Rotate(0, 0, 1.0f, Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // rotate right
            pivot.transform.Rotate(0, 0, -1.0f, Space.Self);
        }
    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayTankShotSound();
            GameObject pivot = this.transform.Find("Cannon").transform.Find("Pivot").gameObject;

            GameObject FireOut = pivot.transform.Find("FireOut").gameObject;
            Instantiate(Projectile, FireOut.transform.position, pivot.transform.rotation);
            turn.GetComponent<Turn>().Action();
        }
    }

    public void TakeDamage(string player)
    {
        HitSound.Play();
        if(player == "Player1")
        {
            currentHealthPlayer1 -= 1;
            player1HealthBar.SetHealth(currentHealthPlayer1);
        } else
        {
            currentHealthPlayer2 -= 1;
            player2HealthBar.SetHealth(currentHealthPlayer2);
        }
    }
}
