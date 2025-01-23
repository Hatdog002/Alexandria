using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Level6Keys : MonoBehaviour
{
    public LevelManager Manager;

    public bool key1;
    public bool key2;
    public bool key3;
    public bool key4;
    public bool key5;
    public bool key6;
    public bool key7;

    public bool canPick;
    public TextMeshProUGUI txtInteract;

    public QuestionUi ui;

    public AudioSource source;
    public AudioClip clip;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPick = true;
            txtInteract.text = "E";
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPick = false;
            txtInteract.text = "";
        }
    }
    public void Update()
    {
        if (canPick)
        {
            if (ui.states == BattleStates.Start)
            {
                if (key1) //knife
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key1 = true;
                        Manager.Ukey1 = true;
                        Manager.turnOn = true; // Set Manager's turnOn to true
                        Destroy(this.gameObject, 1f);  // 1-second delay before destruction
                    }
                }


                if (key3) //Cr
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key3 = true;
                        Manager.Ukey3 = true;
                        Manager.turnOn = true; // Set Manager's turnOn to true
                        Destroy(this.gameObject, 1f);  // 1-second delay before destruction
                    }
                }

                if (key4) //Jar
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key4 = true;
                        Manager.Ukey4 = true;
                        Manager.turnOn = true; // Set Manager's turnOn to true
                        Destroy(this.gameObject, 1f);  // 1-second delay before destruction
                    }
                }

                if (key5) // Acid
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key4)
                        {
                            PlayAudio();
                            txtInteract.text = "";
                            Manager.key5 = true;
                            Manager.Ukey5 = true;
                            Manager.turnOn = true; // Set Manager's turnOn to true
                            Destroy(this.gameObject, 1f);  // 1-second delay before destruction
                        }
                        else
                        {
                            txtInteract.text = "Find a container";
                        }

                    }
                }

                if (key6)// Hammer
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key6 = true;
                        Manager.Ukey6 = true;
                        Manager.turnOn = true; // Set Manager's turnOn to true
                        Destroy(this.gameObject, 1f);  // 1-second delay before destruction
                    }
                }
            }
        }
    }
    public void PlayAudio()
    {
        float randomVolume = Random.Range(0.2f, 0.3f);
        source.PlayOneShot(clip, randomVolume);
    }

}
