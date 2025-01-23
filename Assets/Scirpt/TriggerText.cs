using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerText : MonoBehaviour
{
    public GameObject DialougePanel;
    public GameObject DialougePanelNPC;
    public GameObject QuestOff;
    public GameManager gameManager;
    public bool TriggerTXT1;
    public bool TriggerTXT2;
    public PlayerController1 Movement;

    public Animator playerAnims;
    public void OnTriggerEnter (Collider collision)
    {
        if (TriggerTXT1 == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerAnims.SetBool("isMoving", false);
                gameManager.SceneAt += 1;
                DialougePanel.gameObject.SetActive(true);
                Movement.canMove = false;
                Invoke("Destroy", .5f);
            }
        }

        if (TriggerTXT2 == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerAnims.SetBool("isMoving", false);
                gameManager.SceneAt += 1;
                DialougePanelNPC.gameObject.SetActive(true);
                QuestOff.gameObject.SetActive(false);
                Movement.canMove = false;
                Invoke("Destroy", .5f);
            }
        }
    }


     void Destroy()
    {
        Destroy(gameObject);
    }
}
