using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle5Man : MonoBehaviour
{
    public float Counter;
    public GameObject Anim;

    public bool finish;

    public GameObject Ex;

    public bool done;

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
        if(Counter == 42)
        {
            //Anim.gameObject.SetActive(true);
            finish = true;
        }
        else if (mistakeCounter == MaxM)
        {
            gameober.Gameover = true;
        }

        if (finish)
        {
            Ex.gameObject.SetActive(true);
        }

        txtMistakes.text = mistakeCounter.ToString() + "/" + MaxM.ToString();
    }


    public void ex()
    {
        done = true;
    }
}
