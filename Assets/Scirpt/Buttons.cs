using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Deactivate;
    public GameObject Active;
    public GameObject QuestActive;

    public bool tutorialArrow;
    public bool tutorialArrow2;
    public PlayerController1 Movement;

    public Conversation counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void questOn()
    {
        Deactivate.gameObject.SetActive(false);
        Active.gameObject.SetActive(true);
        tutorialArrow = true;
    }
    public void questOff()
    {
        Deactivate.gameObject.SetActive(false);
        Active.gameObject.SetActive(true);
        tutorialArrow2 = true;
    }
    // Update is called once per frame
    public void nextButton()
    {
        if (gameManager.SceneAt == 1)
        {
            Deactivate.gameObject.SetActive(false);
            Active.gameObject.SetActive(true);
            Movement.canMove = true;
        }

        if (gameManager.SceneAt == 2)
        {
            Deactivate.gameObject.SetActive(false);
            Active.gameObject.SetActive(true);
            gameManager.DialougeAt += 1;
            
        }
        if (gameManager.SceneAt == 3)
        {
            Deactivate.gameObject.SetActive(false);
            QuestActive.gameObject.SetActive(true);
            Invoke("delayMovement", 3f);        
            gameManager.DialougeAt += 1;
        }
    }

    public void dialougeAt()
    {
        gameManager.DialougeAt += 1;

        if (gameManager.DialougeAt == 3)
        {
            Deactivate.gameObject.SetActive(false);
            Invoke("WaitMess", 2f);
            gameManager.SceneAt += 1;
        }
    }

    void WaitMess()
    {
        Active.gameObject.SetActive(true);
    }

    void delayMovement()
    {
        Movement.canMove = true;
    }

    public void Conversation()
    {
        counter.counterConvo += 1;
    }

    public void MissionOn()
    {
        Deactivate.gameObject.SetActive(false);
        Active.gameObject.SetActive(true);
    }
    public void MissionOff()
    {
        Deactivate.gameObject.SetActive(false);
        Active.gameObject.SetActive(true);
    }
}
