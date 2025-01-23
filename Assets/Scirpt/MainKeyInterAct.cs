using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainKeyInterAct : MonoBehaviour
{
    public LevelManager Lmanager;
    public bool keypickUp;

    public TextMeshProUGUI txtInteract;

    public QuestionUi ui;

    public GameObject Dobj;
    private void Start()
    {
        keypickUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (keypickUp)
        {
            if(ui.states == BattleStates.Start)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Lmanager.LevelAt == 1)
                    {
                        keypickUp = false;
                        Lmanager.key6 = true;
                        Lmanager.Ukey6 = true;
                        Lmanager.turnOn = true;
                        txtInteract.text = "";
                        Destroy(Dobj);
                    }
                    else if (Lmanager.LevelAt == 3)
                    {
                        keypickUp = false;
                        Lmanager.key7 = true;
                        Lmanager.Ukey7 = true;
                        Lmanager.turnOn = true;
                        txtInteract.text = "";
                        Destroy(Dobj);
                    }
                    else if (Lmanager.LevelAt == 4)
                    {
                        keypickUp = false;
                        Lmanager.key1 = true;
                        Lmanager.key2 = true;
                        Lmanager.Ukey1 = true;
                        Lmanager.turnOn = true;
                        txtInteract.text = "";
                        Destroy(Dobj);

                    }
                    else if (Lmanager.LevelAt == 5)
                    {
                        keypickUp = false;
                        Lmanager.key4 = true;
                        Lmanager.Ukey4 = true;
                        Lmanager.turnOn = true;
                        txtInteract.text = "";
                        Destroy(Dobj);
                    }
                    else if (Lmanager.LevelAt == 6)
                    {
                        keypickUp = false;
                        Lmanager.key2 = true;
                        Lmanager.Ukey2 = true;
                        Lmanager.turnOn = true;
                        txtInteract.text = "";
                        Destroy(Dobj);
                    }
                }
            }
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            txtInteract.text = "E";
            keypickUp = true;
            Dobj = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            txtInteract.text = "";
            keypickUp = false;
            Dobj = null;
        }
    }
}
