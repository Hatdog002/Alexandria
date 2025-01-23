using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI txtDialouge;

    public Animator animatorMouse;

    public Animator animatorWASD;

    public Animator ArrowMission;

    public GameObject toActivate;
    public GameObject toDeactivate;

    public GameObject PanelActivation;

    public GameObject MissionPanel;
    public GameObject ArrowGuide;
    public Buttons missionArrow;
    public Buttons missionArrow2;

    public GameObject HPBar;

    public CamHolder Camera;
    public PlayerMovementTutorial canmove;
    public FollowManager pause;

    public QuestSetUp QuestCounter;

    public GameObject txtPanel;

    public GameObject NPC;



    public float timer;
    public bool Panel;
    public bool RightLeft;
    public bool Updown;
    public bool WASD1;
    public bool WASD2;
    public bool WASD3;
    public bool WASD4;
    public bool WASDShift;

    public bool WASD5andMouse;

    public bool MissionPanelbool;
    public bool Mission;

    public bool HealthBool;
    public bool HealthBoolAnim;

    public bool MiniMap;
    public GameObject MiniMapGp;
    public Animator Move;

    public bool tutorialDone;
    public bool Enemy;

    public string enemyTag = "Enemy";
    

    public bool EndTutorial;

    private List<GameObject> enemies = new List<GameObject>();

    public bool Istop = true;


    public GameObject Timeline;
    public GameObject Icon;


    public GameObject Naming;
    public bool name1;

    public bool namedone;

    public TMP_InputField txtname;

    public GameObject errormsg;

    public GameObject LevelCheck;

    public bool checkLevel;

    public bool pause1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag(enemyTag);
        enemies.AddRange(enemyArray);

        canmove.movement();
        timer = 3;
        Panel = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if(!pause.pause)
        {
            if (Panel == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    PanelActivation.gameObject.SetActive(true);
                    timer = 0.5f;
                    RightLeft = true;
                    Panel = false;
                }
            }
            if (RightLeft == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 5;
                    MouseLeftRight();
                    EndTutorial = true;
                    RightLeft = false;
                    Updown = true;
                }
            }

            if (Updown == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 6;
                    MouseUpDown();
                    Updown = false;
                    WASD1 = true;
                }
            }

            if (WASD1 == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 3;
                    W();
                    WASD1 = false;
                    WASD2 = true;
                }
            }
            if (WASD2 == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 3;
                    S();
                    WASD2 = false;
                    WASD3 = true;
                }
            }

            if (WASD3 == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 3;
                    A();
                    WASD3 = false;
                    WASD4 = true;
                }
            }
            if (WASD4 == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 4;
                    D();
                    WASD4 = false;
                    WASDShift = true;
                }
            }
            if (WASDShift == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 4;
                    Shift();
                    WASDShift = false;
                    WASD5andMouse = true;
                }
            }

            if (WASD5andMouse == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 3;
                    MoveandDirection();
                    WASD5andMouse = false;
                    MissionPanelbool = true;
                }
            }

            if (MissionPanelbool == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 3;
                    checkingMission();
                    MissionPanelbool = false;
                    Mission = true;
                    MiniMap = true;
                }
            }

            if(MiniMap == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 3;
                    MinimapShow();
                    MiniMap = false;
                    HealthBool = true;
                }
            }

            if (HealthBool == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = .5f;
                    HealthBarShow();
                    HealthBool = false;
                    HealthBoolAnim = true;
                }

            }

            if (HealthBoolAnim == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 3;
                    HealthAnim();
                    HealthBoolAnim = false;
                    checkLevel = true;
                    pause1 = true;
                }
            }
            if (checkLevel)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    checking();
                    checkLevel = false;
                }
            }
            if (name1)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    currentlyNaming();
                    name1 = false;
                }
            }
            if (tutorialDone == true)
            {
                QuestCounter.QuestCounter = 1;
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 3;
                    Tutorial();
                    tutorialDone = false;
                    Enemy = true;
                    //Icon.gameObject.SetActive(true);
                }
            }




            if (Enemy == true)
            {
                Timeline.gameObject.SetActive(true);
                ToggleEnemies(true);
                Debug.Log("EnemyTrue");
            }
            else
            {
                ToggleEnemies(false);
                Debug.Log("Enemyfalse");
            }

        }

    }

    public void W()
    {
        canmove.Movement1();
        animatorMouse.SetBool("IsUpDown", false);
        toActivate.gameObject.SetActive(true);
        toDeactivate.gameObject.SetActive(false);
        animatorWASD.SetBool("isPlaying", true);
        txtDialouge.text = "To walk forward Press W";
    }

    public void A()
    {
        animatorWASD.SetBool("isPlayingS", false);
        animatorWASD.SetBool("isPlayingA", true);
        txtDialouge.text = "To walk left Press A";
    }

    public void S()
    {
        animatorWASD.SetBool("isPlaying", false);
        animatorWASD.SetBool("isPlayingS", true);
        txtDialouge.text = "To walk backward Press S";
    }

    public void D()
    {
        animatorWASD.SetBool("isPlayingA", false);
        animatorWASD.SetBool("isPlayingD", true);
        txtDialouge.text = "To walk right Press D";
    }
    public void Shift()
    {
        animatorWASD.SetBool("isPlayingD", false);
        animatorWASD.SetBool("isPlaying", true);
        txtDialouge.text = "To run Press [Shift]";
    }

    public void MouseLeftRight()
    {
        Camera.canLook = true;
        animatorMouse.SetBool("IsLeftRight", true);
        txtDialouge.text = "Rotate your mouse to change camera direction";
    }

    public void MouseUpDown()
    {
        animatorMouse.SetBool("IsLeftRight", false);
        animatorMouse.SetBool("IsUpDown", true);
        txtDialouge.text = "Move your mouse up and down to change camera angle";
    }

    public void MoveandDirection()
    {
        toDeactivate.gameObject.SetActive(true);
        animatorWASD.SetBool("isPlayingD", false);
        animatorWASD.SetBool("isPlaying", true);
        animatorMouse.SetBool("IsUpDown", false);
        animatorMouse.SetBool("IsLeftRight", true);
        txtDialouge.text = "Rotate your mouse and press W to change player direction";
    }

    public void checkingMission()
    {
        toActivate.gameObject.SetActive(false);
        toDeactivate.gameObject.SetActive(false);
        MissionPanel.gameObject.SetActive(true);
        ArrowGuide.gameObject.SetActive(false);
        txtDialouge.text = "For checking your mission list Hold [Tab].";
    }

    public void Mision()
    {
        if (missionArrow.tutorialArrow == true)
        {
            ArrowGuide.gameObject.SetActive(false);
            ArrowMission.SetBool("isGuide", false);
            txtDialouge.text = "Close the Mission Tab";
        }
        else
        {
            ArrowMission.SetBool("isGuide", true);
            txtDialouge.text = "For checking your mission list Press [Tab] for showing your cursor and press this button";
        }
        
    }

    public void HealthBarShow()
    {
        HPBar.gameObject.SetActive(true);
        ArrowGuide.gameObject.SetActive(true);
    }

    public void HealthAnim()
    {
        ArrowGuide.gameObject.SetActive(true);
        ArrowMission.SetBool("isGuide2", true);
        txtDialouge.text = "On the left side of your screen you will see your Health bar";
    }

    public void currentlyNaming()
    {
        //ArrowGuide.gameObject.SetActive(false);
        //txtDialouge.text = "";
        LevelCheck.gameObject.SetActive(false);
        Naming.gameObject.SetActive(true);
        //canmove.movement();
    }

    public void checking()
    {
        ArrowGuide.gameObject.SetActive(false);
        txtDialouge.text = "";
        LevelCheck.gameObject.SetActive(true);
        canmove.movement();
    }
    public void checkingDone()
    {
        //pause1 = false;
        name1 = true;
    }
    public void Tutorial()
    {
        Naming.gameObject.SetActive(false);
        //ArrowGuide.gameObject.SetActive(false);
        txtDialouge.text = "Congratulations, you're done with the tutorial!";

        Invoke("ClosePanel", 3f);
    }

    public void ClosePanel()
    {
        txtPanel.gameObject.SetActive(false);
        NPC.gameObject.SetActive(true);
        txtDialouge.text = "";
    }

    public void MinimapShow()
    {
        Move.SetBool("IsMove", true);
        MiniMapGp.gameObject.SetActive(true);
        txtDialouge.text = "On the right side of the screen you will see your Minimap";
    }
    public void ToggleEnemies(bool activate)
    {
        // Iterate through the list of enemies
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            GameObject enemy = enemies[i];

            // Check if the enemy is still valid (not destroyed)
            if (enemy != null)
            {
                // Activate or deactivate the enemy based on the 'activate' parameter
                enemy.SetActive(activate);
            }
            else
            {
                // Remove the destroyed enemy from the list
                enemies.RemoveAt(i);
            }
        }
    }


    public void buttonenter()
    {
        if (txtname == null || errormsg == null || canmove == null)
        {
            Debug.LogError("Missing component references! Ensure all are assigned in the Inspector.");
            return;
        }

        string name = txtname.text;
        // Check if the input is null, empty, or whitespace
        if (string.IsNullOrWhiteSpace(name) || txtname.text.Trim() == "")
        {
            Debug.LogError("No Name");
            errormsg.gameObject.SetActive(true); // Show error message
            Invoke(nameof(errorMsgoff), 3f); // Turn off error after 3 seconds
        }
        else
        {
            pause1 = false;
            namedone = true;
            tutorialDone = true;
            // Call movement logic
            if (canmove != null)
            {
                canmove.Movement1();
            }
            else
            {
                Debug.LogError("CanMove reference is missing!");
            }

            // Save the player's name
            PlayerPrefs.SetString("NamingConvention", name.Trim());
            PlayerPrefs.Save();
            Debug.Log("Name saved: " + txtname.text.Trim());
        }
    }

    private void errorMsgoff()
    {
        if (errormsg != null)
        {
            errormsg.gameObject.SetActive(false); // Hide error message
        }
        else
        {
            Debug.LogWarning("Error message GameObject is not assigned!");
        }
    }
}
