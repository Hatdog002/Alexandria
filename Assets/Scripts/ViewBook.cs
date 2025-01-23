using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewBook : MonoBehaviour
{
    public GameObject textPrompt;
    public TextMeshProUGUI text;
    public GameObject text1;
    public GameObject puzzle;
    public GameObject UIHealth;
    public GameObject MissionPanel;
    public FollowManager follow;
    public bool isPlayerClose;
    public Animator animator;
    public static bool isBookOpen = false;

    public bool Isbbook = false;
    //public static bool isBookDone = false;
    public PlayerMovementTutorial playerController;

    public CamHolder holder;
    public GameObject BookTut;

    public GameObject helpButtons;

    public GameObject enemy;

    public FollowManager book;

    public bool EnemyIsClose;

    public GameObject MiniMap;

    public QuestionUi UI;

    public bool checker;
    public void Start()
    {
        isBookOpen = false;
    }
    public void Update()
    {
        if(UI.states == BattleStates.Won)
        {
            EnemyIsClose = false;
            Debug.LogError("EnemyClosefalse");
        }

      
        if (UI.states == BattleStates.Start)
        {
            if (checker)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.LogError("E Book");
                    if (!EnemyIsClose)
                    {
                        Debug.LogError("No Enemy");
                        if (!isBookOpen)
                        {
                            Debug.LogError("Book Open");
                            book.book = true;
                            enemy.gameObject.SetActive(false);
                            MiniMap.gameObject.SetActive(false);
                            textPrompt.SetActive(false);
                            tutorial();
                            Invoke("Book", 1f);
                        }
                    }
                    else
                    {
                        text.text = "There is an enemy nearby";
                        Invoke("Delay", 1f);
                    }

                }
            }
        }
        else
        {
            checker = false;
        }
        

    }
    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checker = true;
            textPrompt.SetActive(true);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(UI.states == BattleStates.Start)
            {
                if (!isBookOpen)
                {
                    checker = true;
                    textPrompt.SetActive(true);
                }
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checker = false;
            textPrompt.SetActive(false);
        }
    }
    public void tutorial()
    {
        isBookOpen = true;
        BookTut.gameObject.SetActive(true);
        
    }
    public void Book()
    {
        //UI In Mini Game
        helpButtons.gameObject.SetActive(true);
        BookTut.gameObject.SetActive(false);
        puzzle.SetActive(true);
        //Ui off
        MissionPanel.gameObject.SetActive(false);
        UIHealth.gameObject.SetActive(false);
       
        textPrompt.SetActive(false);
        text1.gameObject.SetActive(false);
        //PlayerMovement
        playerController.movement();
        animator.SetBool("isMoving", false);

        //book checker
        isBookOpen = true;
        Isbbook = true;

    }
    void Delay()
    {
        text.text = "";
    }
}
