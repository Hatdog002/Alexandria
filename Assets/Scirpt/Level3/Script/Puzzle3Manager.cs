using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle3Manager : MonoBehaviour
{
    public float correctCount;
    public bool Puzzle3IsOver;

    public bool PuzzleIsDone;

    public GameObject X;

    public float mistakeCounter;
    public TextMeshProUGUI txtMistakes;

    public float MaxM;

    public FollowManager gameober;
    public void Start()
    {
        MaxM = PlayerPrefs.GetFloat("MissionTimer");
    }
    public void Update()
    {
       if(correctCount == 33)
        {
            PuzzleIsDone = true;
        }
        else if(mistakeCounter == MaxM)
        {
            gameober.Gameover = true;
        }


        if (PuzzleIsDone)
        {
            X.gameObject.SetActive(true);
        }


        txtMistakes.text = mistakeCounter.ToString() + "/" + MaxM.ToString();
    }


    public void exit()
    {
        Puzzle3IsOver = true;
    }
}
