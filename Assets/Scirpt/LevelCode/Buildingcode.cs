using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buildingcode : MonoBehaviour
{
    public Transform teleportDestination;

    public TextMeshProUGUI txtInteract;

    public TextMeshProUGUI TxtAlert;

    public CameraFade fade;

    public float delay = 1.0f;

    public QuestSetUp quest;

    public HintOpener GuideOff;


    public LevelManager tutorial;

    public bool Door1;
    public bool Door2;
    public bool Door3;

    public GameObject DirectionalLight;
    public GameObject PointLight;
    public bool EnemyClose;
    private void OnTriggerEnter(Collider other)
    {
        if(quest.QuestCounter >= 3)
        {
            if (other.CompareTag("Player"))
            {
                txtInteract.text = "E";
                GuideOff.GuideOn = false;
            }
        }
       

    }
    private void OnTriggerStay(Collider other)
    {
        if (quest.QuestCounter >= 3)
        {
            if (other.CompareTag("Player"))
            { 
                if (!tutorial.PlayerInside)
                {
                    if (Door1)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            if (!EnemyClose)
                            {
                                tutorial.PlayerInside = true;
                                fade.FadeOut();
                                tutorial.turnOn = true;
                                tutorial.PlayerEnter = true;
                                quest.QuestCounter = 5;
                                Lightsoff();
                                // Teleport the player to the specified destination
                                StartCoroutine(TeleportAfterDelay(other.transform));

                                Invoke("fadeOut", 1f);
                            }
                            else
                            {
                                TxtAlert.text = "There is an enemy nearby";
                                Invoke("Delay", 1f);
                            }

                        }
                    }

                    if (Door3)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            if (tutorial.key2 && tutorial.key1)
                            {
                                if (!EnemyClose)
                                {
                                    tutorial.PlayerInside = true;
                                    fade.FadeOut();
                                    // Teleport the player to the specified destination
                                    StartCoroutine(TeleportAfterDelay(other.transform));
                                    Invoke("fadeOut", 1f);
                                }
                                else
                                {
                                    TxtAlert.text = "There is an enemy nearby";
                                    Invoke("Delay", 1f);
                                }

                            }
                            else if (tutorial.key1)
                            {
                                txtInteract.text = "Knife is too dull";
                            }
                            else
                            {
                                txtInteract.text = "Locked";
                            }
                        }

                    }
                }
                else
                {
                    if (Door2)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            if (!EnemyClose)
                            {
                                tutorial.PlayerInside = false;
                                fade.FadeOut();
                                tutorial.turnOn = false;
                                tutorial.PlayerEnter = false;
                                Lightson();
                                // Teleport the player to the specified destination
                                StartCoroutine(TeleportAfterDelay(other.transform));

                                Invoke("fadeOut", 1f);
                            }
                            else
                            {
                                TxtAlert.text = "There is an enemy nearby";
                                Invoke("Delay", 1f);
                            }
                        }
                    }
                }
               
            }
        }
         
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtInteract.text = "";
        }
    }

    void Delay()
    {
        TxtAlert.text = "";
    }
    public void fadeOut()
    {
        fade.FadeIn();
    }

    IEnumerator TeleportAfterDelay(Transform playerTransform)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Teleport the player to the specified destination
        playerTransform.GetComponent<TeleportController>().TeleportToPosition(teleportDestination.position, teleportDestination.rotation);
        GuideOff.GuideOn = false;
    }

    public void Lightsoff()
    {
        DirectionalLight.gameObject.SetActive(false);
        PointLight.gameObject.SetActive(true);
    }
    public void Lightson()
    {
        DirectionalLight.gameObject.SetActive(true);
        PointLight.gameObject.SetActive(false);
    }
}

