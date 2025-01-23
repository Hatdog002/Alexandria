using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyLevel5 : MonoBehaviour
{
    public LevelManager Manager;

    public bool key1;
    public bool key2;
    public bool key3;
    public bool key4;
    public bool key5;
    public bool key6;
    public bool key7;
    public TextMeshProUGUI txtInteract;

    public QuestionUi states;

    public bool keyget;

    public AudioSource source;
    public AudioClip clip;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txtInteract.text = "E";
            keyget = true;
        }
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            keyget = false;
            txtInteract.text = "";
        }
    }

    public void Update()
    {
        if (keyget)
        {
            if (states.states == BattleStates.Start)
            {
                if (key1)
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

                if (key2)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key2 = true;
                        Manager.Ukey2 = true;
                        Manager.turnOn = true; // Set Manager's turnOn to true
                        Destroy(this.gameObject, 1f);  // 1-second delay before destruction
                    }
                }

                if (key3)
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

                if (key4)
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

                if (key5)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key5 = true;
                        Manager.Ukey5 = true;
                        Manager.turnOn = true; // Set Manager's turnOn to true
                        Destroy(this.gameObject, 1f);  // 1-second delay before destruction
                    }
                }

                if (key6)
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

                if (key7)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Manager.key3 && Manager.key4 && Manager.key5 && Manager.key6) // Ensure prerequisites are met
                        {
                            PlayAudio();
                            txtInteract.text = "";
                            Manager.key7 = true;
                            Manager.Ukey7 = true;
                            Manager.turnOn = true; // Set Manager's turnOn to true
                            Destroy(this.gameObject, 1f);  // 1-second delay before destruction
                        }
                        else
                        {
                            txtInteract.text = "Bomb is incomplete";
                        }
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
