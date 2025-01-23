using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DoorLevel3 : MonoBehaviour
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

    private GameObject Ropes;

    public GameObject Book;

    public QuestionUi state;

    public bool dooraccess;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dooraccess = true;
            txtInteract.text = "E";
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dooraccess = false; 
            txtInteract.text = "";
        }
    }
    public void Update()
    {
        if (dooraccess)
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

                    Rope();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key3 == true)
                        {
                            txtInteract.text = "";
                            Ropes.gameObject.SetActive(false);
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
                            txtInteract.text = "Locked by ropes";
                        }
                    }

                }
                if (Door4)
                {
                    Animator D4 = GetComponent<Animator>();
                    Rope();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key4 == true)
                        {
                            txtInteract.text = "";
                            Ropes.gameObject.SetActive(false);
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
                            txtInteract.text = "Locked by ropes";
                        }
                    }

                }
                if (Door5)
                {
                    Animator D5 = GetComponent<Animator>();
                    Rope();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key5 == true)
                        {
                            txtInteract.text = "";
                            Ropes.gameObject.SetActive(false);
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
                            txtInteract.text = "Locked by ropes";
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

                if (Door7)
                {
                    Animator D7 = GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key7 == true)
                        {
                            txtInteract.text = "";
                            Invoke("delay", 1f);
                            if (D7.GetBool("IsOpen") == false)
                            {
                                D7.SetBool("IsOpen", true);
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
            }
        }
    }
    public void Rope()
    {
        Transform child = gameObject.transform.GetChild(0);

        Ropes = child.gameObject;
    }

    public void delay()
    {
        Book.gameObject.SetActive(true);
    }
}
