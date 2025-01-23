using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DoneScript : MonoBehaviour
{
    public Puzzke6Man done;

    public TextMeshProUGUI txtInteract;

    public bool Okay;

    public PlayerMovementTutorial movement;

    
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
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (done.Done)
                {
                    movement.movement();
                    Okay = true;
                }
                else
                {
                    txtInteract.text = "Find the Manual";
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
}
