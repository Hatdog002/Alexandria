using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Level4Key : MonoBehaviour
{
    public LevelManager Manager;

    public bool key1;
    public bool key2;
    public bool key3;
    public bool key4;
    public bool key5;

    public GameObject fire;
    public GameObject Icon;

    public TextMeshProUGUI txtInteract;

    public QuestionUi state;
    public bool getkey;

    public AudioSource source;
    public AudioClip clip;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            getkey = true;
            txtInteract.text = "E";
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            getkey = false;
            txtInteract.text = "";
        }
    }
    public void Update()
    {
        if (getkey)
        {
            if (state.states == BattleStates.Start)
            {
                if (key1)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key1 = true;
                        Manager.key2 = true;
                        Manager.Ukey1 = true;
                        Manager.Ukey2 = true;
                        Manager.turnOn = true;
                        Destroy(this.gameObject);
                    }
                }
                if (key2)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        Manager.key3 = true;
                        Manager.Ukey3 = true;
                        Manager.turnOn = true;
                        txtInteract.text = "";
                        Destroy(this.gameObject);
                    }
                }

                if (key3)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        Manager.key4 = true;
                        Manager.Ukey4 = true;
                        Manager.turnOn = true;
                        txtInteract.text = "";
                        Destroy(this.gameObject);
                    }
                }
                if (key4)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        Manager.key5 = true;
                        Manager.Ukey5 = true;
                        Manager.turnOn = true;
                        txtInteract.text = "";
                        Destroy(this.gameObject);
                    }
                }
                if (key5)
                {
                    if (Manager.key5)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            //PlayAudio();
                            Manager.key6 = true;
                            Manager.Ukey6 = true;
                            Manager.turnOn = true;
                            fire.gameObject.SetActive(true);
                            txtInteract.text = "";
                            Icon.gameObject.SetActive(false);
                        }
                    }
                    else
                    {
                        fire.gameObject.SetActive(false);
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
