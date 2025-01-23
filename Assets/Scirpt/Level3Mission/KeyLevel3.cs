using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyLevel3 : MonoBehaviour
{
    public LevelManager Manager;

    public bool Key1;
    public bool Key2;
    public bool Key3;
    public bool Key4;
    public bool Key5;
    public bool Key6;

    public TextMeshProUGUI txtInteract;

    public QuestionUi state;

    public bool keyAccess;

    public AudioSource source;
    public AudioClip clip;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            keyAccess = true;
            txtInteract.text = "E";
        }
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            keyAccess = false;
            txtInteract.text = "";
        }
    }

    public void Update()
    {
        if (keyAccess)
        {
            if (state.states == BattleStates.Start)
            {
                if (Key1)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key1 = true;
                        Manager.key2 = true;
                        Manager.Ukey1 = true;
                        Manager.turnOn = true;
                        Destroy(this.gameObject);
                    }
                }

                if (Key2)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key3 = true;
                        Manager.Ukey3 = true;
                        Manager.turnOn = true;
                        Destroy(this.gameObject);
                    }
                }

                if (Key3)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key4 = true;
                        Manager.Ukey4 = true;
                        Manager.turnOn = true;
                        Destroy(this.gameObject);
                    }
                }

                if (Key4)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key5 = true;
                        Manager.Ukey5 = true;
                        Manager.turnOn = true;
                        Destroy(this.gameObject);
                    }
                }

                if (Key5)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key6 = true;
                        Manager.Ukey6 = true;
                        Manager.turnOn = true;
                        Destroy(this.gameObject);
                    }
                }
                if (Key6)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key7 = true;
                        Manager.Ukey7 = true;
                        Manager.turnOn = true;
                        Destroy(this.gameObject);
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
