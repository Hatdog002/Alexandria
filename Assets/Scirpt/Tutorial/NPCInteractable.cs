using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NPCInteractable : MonoBehaviour
{
    public TextMeshProUGUI txtinteract;
    public PlayerMovementTutorial canMove;
    public CamHolder canLook;

    public Conversation convoCounter;

    public Collider collider2;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txtinteract.text = "Press E to interact";
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                canLook.canLook = false;
                canMove.canMove = false;
                collider2.enabled = false;
                txtinteract.text = "";
                convoCounter.counterConvo = 1;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txtinteract.text = "";
        }
    }

    
}
