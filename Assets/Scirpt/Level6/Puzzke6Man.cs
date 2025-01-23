using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Puzzke6Man : MonoBehaviour
{
    public int Puzzle6Counter;

    public GameObject exit;

    public bool Done;

    public GameObject Book;

    public LevelManager manager;

    public PlayerMovementTutorial player;

    public GameObject Win;

    public float mistakeCounter;
    public TextMeshProUGUI txtMistakes;

    public float MaxM;

    public FollowManager gameober;
    public void Start()
    {
        MaxM = PlayerPrefs.GetFloat("MissionTimer");
    }
    public void Update()
    {
        if (Puzzle6Counter == 24)
        { 
            manager.turnOn = true;
            exit.gameObject.SetActive(true);
            Done = true;
            Book.gameObject.SetActive(false);
           
        }
        else if (mistakeCounter == MaxM)
        {
            gameober.Gameover = true;
        }

        txtMistakes.text = mistakeCounter.ToString() + "/" + MaxM.ToString();
    }

    public void WinShow()
    {
        Win.gameObject.SetActive(true);
        Invoke("OffWin", 2f);
    }
    public void counter()
    {
        Puzzle6Counter += 1;
    }

    public void Mistake()
    {
        mistakeCounter += 1;
    }

    public void Move()
    {
        gameober.book = false;
        player.Movement1();
    }

    public void OffWin()
    {
        Win.gameObject.SetActive(false);
    }
}
