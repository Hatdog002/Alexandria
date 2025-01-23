using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PuzzleManager : MonoBehaviour
{
    public GameObject UIHealth;

    public GameObject MissionPanel;

    public FollowManager follow;

    public TextMeshProUGUI answerKey;

    public GameObject puzzleComplete;

    public PlayerLUnderstand playerL;
    public int foundCounter;
    public int mistakescounter;

    public GameObject puzzle;

    //Checking if the Puzzle Over

    public bool thePuzzleOver = false;

    public PlayerMovementTutorial move;

    public TextMeshProUGUI txtMistake;

    public GameObject volumeError;

    public bool Puzzle1;
    public bool Puzzle2;
  
    public LevelManager scene;


    public GameObject[] buttons;

    public float maxMistake;
    // Update is called once per frame

    private void Start()
    {
        if(scene.LevelAt == 1)
        {
            Puzzle1 = true;
            Puzzle2 = false;
        }
        else if(scene.LevelAt == 2)
        {
            Puzzle1 = false;
            Puzzle2 = true;
        }

        maxMistake = PlayerPrefs.GetFloat("MissionTimer");
    }
    void Update()
    {
        txtMistake.text = mistakescounter.ToString() + "/" + maxMistake.ToString();
        if (Puzzle1)
        {
            if (foundCounter == 13)
            {
                answerKey.text = "All words found!";
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].gameObject.SetActive(false);  // Deactivates each button in the array
                }
                //ViewBook.isBookDone = true;
                puzzleComplete.SetActive(true);
            }
            else if (mistakescounter == maxMistake)
            {
                follow.Gameover = true;
            }
        }
        else if (Puzzle2)
        {
            if (foundCounter == 26)
            {
                answerKey.text = "All words found!";
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].gameObject.SetActive(false);  // Deactivates each button in the array
                }
                //ViewBook.isBookDone = true;
                puzzleComplete.SetActive(true);
            }
            else if (mistakescounter == maxMistake)
            {
                follow.Gameover = true;
            }
        }
        
    }
    
    public void WordFound()
    {
       // wordChecker = true;
        foundCounter += 1;
    }

    public void WrongAns()
    {
        volumeError.gameObject.SetActive(true);
        mistakescounter += 1;
        Invoke("OffVol", .5f);
    }

    public void OffVol()
    {
        volumeError.gameObject.SetActive(false);
    }
    public void PuzzleOver()
    {
        MissionPanel.gameObject.SetActive(true);
        follow.canFollow = true;
        UIHealth.gameObject.SetActive(true);
        move.canMove = true;
        thePuzzleOver = true;
        puzzle.SetActive(false);
        ViewBook.isBookOpen = false;
    }

    
}
