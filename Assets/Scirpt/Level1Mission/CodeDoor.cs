using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeDoor : MonoBehaviour
{
    public GameObject CodeUI;

    public TMP_InputField input;

    public LevelManager Manager;

    private int password = 1221;

    public TextMeshProUGUI txtInteract;

    string input_value;

    public PlayerMovementTutorial canMove;

    public FollowManager Manager2;

    public QuestionUi QuestionUi;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txtInteract.text = "E";
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (QuestionUi.states == BattleStates.Start)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Manager2.canFollow = false;
                    Manager2.code = true;
                    Movement();
                    CodeUI.gameObject.SetActive(true);
                }
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txtInteract.text = "";
        }
    }


    public void Exit()
    {
        CanMove();
        CodeUI.gameObject.SetActive(false);
        Manager2.canFollow = true;
        Manager2.code = false;
    }

    public void checkAnswer()
    {
        string Inputtxt = input.text;

        if(int.TryParse(Inputtxt,out int IntValue))
        {
            if(IntValue == password)
            {
                Manager2.canFollow = true;
                Manager2.code = false;
                Manager.key2 = true;
                CodeUI.gameObject.SetActive(false);
                CanMove();
                Debug.Log("Correct");
            }
           
        }
    }

    void Movement()
    {
        canMove.movement();
    }

    void CanMove()
    {
        canMove.Movement1();
    }

    public void delete()
    {
        input_value = "";
        input.text = input_value.ToString();
    }
   
    public void one()
    {
        input_value = input_value + "1";
        input.text = input_value.ToString();
    }

    public void two()
    {
        input_value = input_value + "2";
        input.text = input_value.ToString();
    }
    public void three()
    {
        input_value = input_value + "3";
        input.text = input_value.ToString();
    }
    public void four()
    {
        input_value = input_value + "4";
        input.text = input_value.ToString();
    }
    public void five()
    {
        input_value = input_value + "5";
        input.text = input_value.ToString();
    }
    public void six()
    {
        input_value = input_value + "6";
        input.text = input_value.ToString();
    }
    public void seven()
    {
        input_value = input_value + "7";
        input.text = input_value.ToString();
    }
    public void eight()
    {
        input_value = input_value + "8";
        input.text = input_value.ToString();
    }
    public void nine()
    {
        input_value = input_value + "9";
        input.text = input_value.ToString();
    }
    public void ten()
    {
        input_value = input_value + "0";
        input.text = input_value.ToString();
    }

}
