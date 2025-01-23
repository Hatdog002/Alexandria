using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorLevel2 : MonoBehaviour
{
    public LevelManager Manager;

    public bool Door1;
    public bool Door2;


    public TextMeshProUGUI txtInteract;

    public bool dooraccess;

    public QuestionUi state;
    // Start is called before the first frame update
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
            }
        }
    }
}
