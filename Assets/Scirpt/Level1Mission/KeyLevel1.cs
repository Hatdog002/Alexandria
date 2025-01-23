using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyLevel1 : MonoBehaviour
{
    public LevelManager Manager;

    public bool key1;
    public bool key2;
    public bool key3;
    public bool key4;
    public bool key5;

    public GameObject OpenUiRiddles;

    public PlayerMovementTutorial canMove;
    public CamHolder canlook;

    public FollowManager Manager2;
    public TextMeshProUGUI txtInteract;

    public QuestionUi QuestionUi;

    public bool dooraccess;


    public AudioSource source;
    public AudioClip clip;

    public bool checker = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            if (QuestionUi.states == BattleStates.Start)
            {
                if (key1)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PlayAudio();
                        txtInteract.text = "";
                        Manager.key1 = true;
                        Manager.Ukey1 = true;
                        Manager.turnOn = true;
                        Destroy(this.gameObject);
                    }
                }
                if (key2)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (!checker)
                        {
                            playerMove();
                            PlayAudio();
                            Manager.key3 = true;
                            Manager.Ukey3 = true;
                            Manager.turnOn = true;
                            txtInteract.text = "";
                            Invoke("Delay", 3F);
                            checker = true;
                        }
                    }
                }

                if (key3)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (!checker)
                        {
                            playerMove();
                            PlayAudio();
                            Manager.key4 = true;
                            Manager.Ukey4 = true;
                            Manager.turnOn = true;
                            txtInteract.text = "";
                            Invoke("Delay", 3F);
                            checker = true;
                        }
                    }
                }
                if (key4)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (!checker)
                        {
                            playerMove();
                            PlayAudio();
                            Manager.key5 = true;
                            Manager.Ukey5 = true;
                            Manager.turnOn = true;
                            txtInteract.text = "";
                            Invoke("Delay", 3F);
                            checker = true;
                        }
                    }
                }
                if (key5)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (!checker)
                        {
                            playerMove();
                            PlayAudio();
                            Manager.key6 = true;
                            Manager.Ukey6 = true;
                            Manager.turnOn = true;
                            txtInteract.text = "";
                            Invoke("Delay", 3F);
                            checker = true;
                        }
                    }
                }
            }

        }
    }

    void Delay()
    {
        OpenUiRiddles.gameObject.SetActive(true);
    }


    void playerMove()
    {
        Manager2.code = true;
        Manager2.canFollow = false;
        canMove.movement();
    }

    public void PlayAudio()
    {
        float randomVolume = Random.Range(0.2f, 0.3f);
        source.PlayOneShot(clip, randomVolume);
    }
}
