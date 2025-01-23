using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Puzzle4Man : MonoBehaviour
{

    public float Counter;

    public bool inish;

    public bool PuzzleOevr;

    public GameObject eX;

    public float mistakeCounter;
    public TextMeshProUGUI txtMistakes;

    public float maxM;

    public FollowManager gameober;
    // Start is called before the first frame update
    void Start()
    {
        maxM = PlayerPrefs.GetFloat("MissionTimer");
    }

    // Update is called once per frame
    void Update()
    {
        if(Counter == 27)
        {
            inish = true;
        }
        else if (mistakeCounter == maxM)
        {
            gameober.Gameover = true;
        }

        if (inish)
        {
            eX.gameObject.SetActive(true);
        }

        txtMistakes.text = mistakeCounter.ToString() + "/" + maxM.ToString();
    }


    public void exit()
    {
        PuzzleOevr = true;
    }
}
