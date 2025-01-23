using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorLevel7 : MonoBehaviour
{
    public LevelManager Manager;

    public bool Door1;
    public bool Door2;
    public bool Door3;
    public bool Door4;
    public bool Door5;
    public bool Door6;
    public bool Door7;

    public TextMeshProUGUI txtInteract;

    public GameObject Key1;

    public QuestionUi ui;

    private bool doorOpen;

    public void FixedUpdate()
    {
        if (doorOpen)
        {
            if (ui.states == BattleStates.Start)
            {
                if (Door2)
                {
                    Animator D2 = GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key6 == true)
                        {
                            txtInteract.text = "";
                            if (D2.GetBool("IsOpen") == false)
                            {
                                D2.SetBool("IsOpen", true);
                            }
                            else
                            {
                                txtInteract.text = "Broken";
                            }

                            Debug.LogError("E is Pressed");
                        }
                        else
                        {
                            txtInteract.text = "Locked";
                        }
                    }

                }
                if (Door3)
                {
                    Animator D2 = GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key3 == true)
                        {
                            txtInteract.text = "";
                            if (D2.GetBool("IsOpen") == false)
                            {
                                D2.SetBool("IsOpen", true);
                            }
                            else
                            {
                                txtInteract.text = "Broken";
                            }

                            Debug.LogError("E is Pressed");
                        }
                        else
                        {
                            txtInteract.text = "Locked";
                        }
                    }

                }

                if (Door4)
                {
                    Animator D4 = GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key5 == true)
                        {
                            txtInteract.text = "";

                            if (D4.GetBool("IsOpen") == false)
                            {
                                D4.SetBool("IsOpen", true);
                            }
                            else
                            {
                                txtInteract.text = "Broken";
                            }

                            Debug.LogError("E is Pressed");
                        }
                        else
                        {
                            txtInteract.text = "Locked";
                        }
                    }

                }
                if (Door5)
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key1 == true)
                        {
                            txtInteract.text = "";
                            Key1.gameObject.SetActive(true);
                            Manager.turnOn = true;
                            Manager.key2 = true;
                            Manager.Ukey2 = true;
                            Debug.LogError("E is Pressed");
                        }
                        else
                        {
                            txtInteract.text = "Find a knife";
                        }
                    }


                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorOpen = true;
            txtInteract.text = "E";
        }
    }

   
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorOpen = false;
            txtInteract.text = "";
        }
    }
}
