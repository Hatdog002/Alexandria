using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Conversation : MonoBehaviour
{
    public TextMeshProUGUI enemyDialouge;

    public GameObject EnemyPanel;

    public TextMeshProUGUI PlayerDialouge;

    public GameObject PlayerPanel;

    public TextMeshProUGUI ComputerDialouge;

    public GameObject ComputerPanel;

    public QuestSetUp quest;
    public int counterConvo;

    public PlayerMovementTutorial move;
    public CamHolder cam;

    public GameObject uttons;

    public GameObject HINT;

    public GameObject convo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counterConvo ==1)
        {
            EnemyPanel.gameObject.SetActive(true);
            convo.gameObject.SetActive(true);
        }

        if(counterConvo == 2)
        {
            convo.gameObject.SetActive(false);
            EnemyPanel.gameObject.SetActive(false);
            PlayerPanel.gameObject.SetActive(true);
            PlayerDialouge.text = "What?";
        }

        if (counterConvo == 3)
        {
            ComputerPanel.gameObject.SetActive(true);
            EnemyPanel.gameObject.SetActive(false);
            PlayerPanel.gameObject.SetActive(false);

            ComputerDialouge.text = "It's look like you can't communicate right now";
        }
        if (counterConvo == 4)
        {
            ComputerDialouge.text = "Find a item that can help you to communicate";
            Invoke("nextConvo",2f);
        }

        if (quest.QuestCounter == 2 && counterConvo >= 5) 
        {
            ComputerPanel.gameObject.SetActive(false);
            EnemyPanel.gameObject.SetActive(false);
            PlayerPanel.gameObject.SetActive(false);
            cam.canLook = true;
            move.canMove = true;
            counterConvo = 6;
            HINT.gameObject.SetActive(true);
            quest.QuestCounter = 3;
        }

        if (counterConvo == 7)
        {
            uttons.gameObject.SetActive(false);
            ComputerPanel.gameObject.SetActive(true);
            ComputerDialouge.text = "Hint Obtained";
            Invoke("SlowCou", 2f);

        }

        if(counterConvo == 8)
        {
            gudie();
            Invoke("slowCounter", 2f);
        }

        if (counterConvo == 9)
        {
            clear();
            Invoke("slowCounter2", 2f);
        }

    }


    public void nextConvo()
    {
        quest.QuestCounter = 2;
    }

    public void gudie()
    {
        uttons.gameObject.SetActive(false);
        ComputerDialouge.text = "The arrow above your head will tell the location of the item you need";
    }

    public void clear()
    {
        ComputerPanel.gameObject.SetActive(false);
        uttons.gameObject.SetActive(true);
        ComputerDialouge.text = "";
    }
    public void SlowCou()
    {
        counterConvo = 8;
    }
    public void slowCounter()
    {
        counterConvo = 9;
    }

    public void slowCounter2()
    {
        counterConvo = 10;
    }
}
