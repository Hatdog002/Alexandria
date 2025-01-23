using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorInteract : MonoBehaviour
{
    public LevelManager Manager;

    public bool Door1;
    public bool Door2;
    public bool Door3;
    public bool Door4;
    public bool Door5;
    public bool Door6;

    public TextMeshProUGUI txtInteract;

    public bool doorAccess;
    public QuestionUi state;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorAccess = true;
            txtInteract.text = "E"; 
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorAccess = false;
            txtInteract.text = "";
        }
    }

    public void Update()
    {
        if (doorAccess)
        {
            if(state.states == BattleStates.Start)
            {

                if (Door1)
                {
                    Animator D1 = GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key1 == true)
                        {
                            txtInteract.text = "";


                            if (D1.GetBool("IsOpen") == false)
                            {
                                D1.SetBool("IsOpen", true);
                            }
                            else
                            {
                                D1.SetBool("IsOpen", false);
                            }
                            Debug.LogError("E is Pressed");
                        }
                        else
                        {
                            txtInteract.text = "Locked";
                        }
                    }
                }

                if (Door2)
                {
                    Animator D2 = GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key2 == true)
                        {
                            txtInteract.text = "";


                            if (D2.GetBool("IsOpen") == false)
                            {
                                D2.SetBool("IsOpen", true);
                            }
                            else
                            {
                                D2.SetBool("IsOpen", false);
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
                    Animator D3 = GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key3 == true)
                        {
                            txtInteract.text = "";


                            if (D3.GetBool("IsOpen") == false)
                            {
                                D3.SetBool("IsOpen", true);
                            }
                            else
                            {
                                D3.SetBool("IsOpen", false);
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
                        if (Manager.key4 == true)
                        {
                            txtInteract.text = "";


                            if (D4.GetBool("IsOpen") == false)
                            {
                                D4.SetBool("IsOpen", true);
                            }
                            else
                            {
                                D4.SetBool("IsOpen", false);
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
                    Animator D5 = GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key5 == true)
                        {
                            txtInteract.text = "";


                            if (D5.GetBool("IsOpen") == false)
                            {
                                D5.SetBool("IsOpen", true);
                            }
                            else
                            {
                                D5.SetBool("IsOpen", false);
                            }
                            Debug.LogError("E is Pressed");
                        }
                        else
                        {
                            txtInteract.text = "Locked";
                        }
                    }

                }
                if (Door6)
                {
                    Animator D6 = GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key6 == true)
                        {
                            txtInteract.text = "";

                            if (D6.GetBool("IsOpen") == false)
                            {
                                D6.SetBool("IsOpen", true);
                            }
                            else
                            {
                                D6.SetBool("IsOpen", false);
                            }
                            Debug.LogError("E is Pressed");
                        }
                        else
                        {
                            txtInteract.text = "Locked";
                        }
                    }

                }
            }
        }
    }

}
