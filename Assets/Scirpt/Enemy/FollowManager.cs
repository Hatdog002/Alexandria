using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
public class FollowManager : MonoBehaviour
{
    public LevelManager count;
    public bool canFollow = true;


    public float EnemyCounter;

    public int CounterENEMY;

    public float HintCounter;

    public GameObject Pause;
    public GameObject MPause;
    public GameObject Settings;
    public GameObject YN;


    public bool pause;

    public PuzzleManager puzzleOver;

    public Puzzle3Manager puzzleOver3;

    public Puzzle4Man puzzleOver4;

    public CookBookManager cook;

    public Puzzle5Man done;

    public DoneScript Okay;

    public float SceneCounter;

    public GameObject Battle;

    public PlayerMovementTutorial movemnet;

    public QuestionUi states;

    public GameObject DebugUI;
    private bool DebugQ;

    public bool book;

    public GameObject SceneOutside;
    public GameObject SceneInside;

    public Camera camera1;
    public Camera camera2;

    public bool code;

    public TextMeshProUGUI txtname;
    public TextMeshProUGUI txtname2;


    public bool Gameover = false;

    public TutorialManager tut;

    public void Start()
    {
        Gameover = false;
        if (PlayerPrefs.GetString("NamingConvention") == null)
        {
            txtname.text = "Playmaker";
            txtname2.text = "Playmaker";
        }
        else
        {
            txtname.text = PlayerPrefs.GetString("NamingConvention");
            txtname2.text = PlayerPrefs.GetString("NamingConvention");
        }
        canFollow = true;
        Time.timeScale = 1;
        EnemyCounter = PlayerPrefs.GetFloat("EnemyCount");
    }
    public void Update()
    {
        if(PlayerPrefs.GetString("NamingConvention") == null)
        {
            txtname.text = "Playmaker";
            txtname2.text = "Playmaker";
        }
        else
        {
            txtname.text = PlayerPrefs.GetString("NamingConvention");
            txtname2.text = PlayerPrefs.GetString("NamingConvention");
        }
        
        if (Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.Z))
        {
            if (!DebugQ)
            {
                DebugUI.gameObject.SetActive(true);
                DebugQ = true;
            }
            else
            {
                DebugUI.gameObject.SetActive(false);
                DebugQ = false;
            }
        }
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (states.states == BattleStates.Start)
            {
                if (!pause)
                {
                    pause = true;
                    Time.timeScale = 0;
                    Debug.LogWarning("Time.timeScale: " + Time.timeScale);
                    Pause.gameObject.SetActive(true);
                    Battle.gameObject.SetActive(false);
                    movemnet.movement();
                }
                else if (pause)
                {
                    pause = false;
                    Time.timeScale = 1;
                    Debug.LogWarning("Time.timeScale: " + Time.timeScale);
                    off();
                    Pause.gameObject.SetActive(false);
                    Battle.gameObject.SetActive(true);

                    if (count.LevelAt >= 1)
                    {
                        if (!book && !code)
                        {
                            movemnet.Movement1();
                        }
                    }
                    else if (count.LevelAt == 0)
                    {
                        if (tut.pause1)
                        {
                            movemnet.movement();
                        }
                        else
                        {
                            movemnet.Movement1();
                        }
                        
                    }
                 

                }
            }
        }

        if (!count.PlayerInside)
        {
            camera1.enabled = true;
            camera2.enabled = false;
            SceneInside.gameObject.SetActive(false);
            SceneOutside.gameObject.SetActive(true);
        }
        else
        {
            camera1.enabled = false;
            camera2.enabled = true;
            SceneInside.gameObject.SetActive(true);
            SceneOutside.gameObject.SetActive(false);
        }

        if (count.LevelAt == 1 )
        {
            if (puzzleOver.thePuzzleOver)
            {
                PlayerPrefs.SetInt("LevelReached", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene("CutS3");
            }
        }

        if (count.LevelAt == 2)
        {
            if (puzzleOver.thePuzzleOver)
            {
                PlayerPrefs.SetInt("LevelReached", 2);
                PlayerPrefs.Save();
                SceneManager.LoadScene("CutS5");
            }
        }

        if (count.LevelAt == 3)
        {
            if (puzzleOver3.Puzzle3IsOver)
            {
                PlayerPrefs.SetInt("LevelReached", 3);
                PlayerPrefs.Save();
                SceneManager.LoadScene("CutS7");
            }
        }

        if (count.LevelAt == 4)
        {
            if (puzzleOver4.PuzzleOevr)
            {
                PlayerPrefs.SetInt("LevelReached", 4);
                PlayerPrefs.Save();
                SceneManager.LoadScene("CutS9");
            }
        }

        if(count.LevelAt == 5)
        {
            if (cook.PuzzleDone)
            {
                PlayerPrefs.SetInt("LevelReached", 5);
                PlayerPrefs.Save();
                SceneManager.LoadScene("CutS11");
            }
        }

        if (count.LevelAt == 6)
        {
            if (done.done)
            {
                PlayerPrefs.SetInt("LevelReached", 6);
                PlayerPrefs.Save();
                SceneManager.LoadScene("CutS14");
            }
        }
        if(count.LevelAt == 7)
        {
            if (Okay.Okay)
            {
                PlayerPrefs.SetInt("LevelReached", 7);
                PlayerPrefs.Save();
                SceneManager.LoadScene("CutS16");
            }
        }


        PlayerPrefs.SetFloat("EnemyCount", EnemyCounter);
        PlayerPrefs.Save();


        if (Gameover)
        {
            PlayerPrefs.SetInt("LoadScene", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOber");
        }
    }


    public void Continue()
    {
        Time.timeScale = 1;
        Pause.gameObject.SetActive(false);
        Battle.gameObject.SetActive(true);
        pause = false;

        if (count.LevelAt >= 1)
        {
            if (!book && !code)
            {
                movemnet.Movement1();
            }
        }
        else if (count.LevelAt == 0)
        {
            if (tut.pause1)
            {
                movemnet.movement();
            }
            else
            {
                movemnet.Movement1();
            }

        }
    }

    void off()
    {
        MPause.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);
        YN.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
