using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class HintOpener : MonoBehaviour
{
    public bool IsGuessed = false;

    public GameObject ScrambleWordHint;

    public TextMeshProUGUI txt;

    public WordScramble isCorrect;

    public CamHolder freeLookCamera;

    public PlayerMovementTutorial canMove;

    public GameObject Guide;

    public GameObject VFX;

    public bool GuideOn;

    public FollowManager hintCounter;
    public Collider collider2;

    public Conversation convoCounter;

    public void OnTriggerEnter(Collider other)
    {
        if (!IsGuessed)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                txt.text = "Press E to Interact";
            }
        }
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (!IsGuessed)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    hintCounter.HintCounter += 1;

                    collider2.enabled = false;
                    canMove.canMove = false;
                    freeLookCamera.canLook = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    ScrambleWordHint.gameObject.SetActive(true);
                    txt.text = "";
                   
                    if (hintCounter.HintCounter == 1)
                    {
                        isCorrect.tutorial();
                    }
                    else if(hintCounter.HintCounter >= 2)
                    {
                        isCorrect.Show();
                    }
                  
                }
            }
        }

    }
    public void OnTriggerExit(Collider other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
                txt.text = "";
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
    }

    public void OnClickEx()
    {
        convoCounter.counterConvo = 7;
        VFX.gameObject.SetActive(false);
        GuideOn = true;
        ScrambleWordHint.gameObject.SetActive(false);
        freeLookCamera.canLook = true;
        canMove.canMove = true;
        IsGuessed = true;
    }

    public void onClick()
    {
        collider2.enabled = true;
        VFX.gameObject.SetActive(false);
        ScrambleWordHint.gameObject.SetActive(false);
        freeLookCamera.canLook = true;
        canMove.canMove = true;
        IsGuessed = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void Update()
    {
        if (!GuideOn)
        {
            Guide.gameObject.SetActive(false);
        }
        else
        {
            Guide.gameObject.SetActive(true);
        }
        if (isCorrect.correctanswer == true)
        {
            Invoke("OnClickEx", .5f);
            isCorrect.correctanswer = false;
        }
    }
}
