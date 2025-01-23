using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CookBookManager : MonoBehaviour
{
    public float counter;

    public bool PuzzleOver;

    public GameObject ex;

    public bool PuzzleDone;
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
        if (counter == 9)
        {
            PuzzleOver = true;
        }
        else if (mistakeCounter == MaxM)
        {
            gameober.Gameover = true;
        }


        if (PuzzleOver)
        {
            ex.gameObject.SetActive(true);
        }

        txtMistakes.text = mistakeCounter.ToString() + "/" + MaxM.ToString();
    }


    public void Ex()
    {
        PuzzleDone = true;
    }
}
