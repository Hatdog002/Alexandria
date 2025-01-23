using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorLevel6 : MonoBehaviour
{
    public LevelManager Manager;

    public bool Door1;
    public bool Door2;
    public bool Door3;
    public bool Door4;
   

    public TextMeshProUGUI txtInteract;

    private GameObject Ropes;

    public GameObject key1;
    public GameObject Icon;

    public QuestionUi state;
    public bool doorOpen;
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txtInteract.text = "E";
            doorOpen = true;
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

    public void Update()
    {
        if (doorOpen)
        {
            if (state.states == BattleStates.Start)
            {
                if (Door1)
                {
                    Animator D1 = GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {

                        txtInteract.text = "";

                        Invoke("Delay", 1f);
                        Icon.gameObject.SetActive(false);
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
                }

                if (Door2)
                {
                    Animator D2 = GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key1 == true)
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
                        if (Manager.key7 == true)
                        {
                            txtInteract.text = "";

                            if (D3.GetBool("IsOpen") == false)
                            {
                                D3.SetBool("IsOpen", true);
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
                        if (Manager.key2 == true)
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
            }
        }
    }
    void Delay()
    {
        key1.gameObject.SetActive(true);
    }
}
