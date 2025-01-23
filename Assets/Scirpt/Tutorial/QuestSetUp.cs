using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestSetUp : MonoBehaviour
{
    public TextMeshProUGUI txtQuest;

    public int QuestCounter;

    public LevelManager count;

    public TutorialManager End;

    public Animator missionUpdate;

    public TextMeshProUGUI updateTXt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count.LevelAt == 0)
        {
            if (End.Enemy)
            {
                txtQuest.text = "Roam around the area.";
            }

           
        }

        if (count.LevelAt == 1)
        {
            if (QuestCounter == 2)
            {
                missionUpdate.SetBool("IsOpen", false);
                Invoke("delay", 4f);
            }
            else if (QuestCounter ==3)
            {
                txtQuest.text = "Find the library";
                missionUpdate.SetBool("IsOpen", true);
                Invoke("animDelay", 7f);

            }
            else if(QuestCounter == 4)
            {
                missionUpdate.SetBool("IsOpen", false);
            }
            else if (QuestCounter == 5)
            {
                updateTXt.text = "Find the ABC book";
                txtQuest.text = "Find the ABC book";
                missionUpdate.SetBool("IsOpen", true);
            }

        }

        if (count.LevelAt == 2)
        {
            if (QuestCounter == 2)
            {
                updateTXt.text = "Find the bookstore";
                missionUpdate.SetBool("IsOpen", false);
                Invoke("delay", 4f);
            }
            else if (QuestCounter == 3)
            {
                txtQuest.text = "Find the bookstore";
                missionUpdate.SetBool("IsOpen", true);
                Invoke("animDelay", 7f);

            }
            else if (QuestCounter == 4)
            {
                missionUpdate.SetBool("IsOpen", false);
            }
            else if (QuestCounter == 5)
            {
                updateTXt.text = "Find the Dictionary book";
                txtQuest.text = "Find the Dictionary book";
                missionUpdate.SetBool("IsOpen", true);
            }
        }

        if (count.LevelAt == 3)
        {
            if (QuestCounter == 2)
            {
                updateTXt.text = "Find the hospital";
                missionUpdate.SetBool("IsOpen", false);
                Invoke("delay", 4f);
            }
            else if (QuestCounter == 3)
            {
                txtQuest.text = "Find the hospital";
                missionUpdate.SetBool("IsOpen", true);
                Invoke("animDelay", 7f);

            }
            else if (QuestCounter == 4)
            {
                missionUpdate.SetBool("IsOpen", false);
            }
            else if (QuestCounter == 5)
            {
                updateTXt.text = "Find the First Aid book";
                txtQuest.text = "Find the First Aid book";
                missionUpdate.SetBool("IsOpen", true);
            }
        }

        if (count.LevelAt == 4)
        {
            if (QuestCounter == 2)
            {
                updateTXt.text = "Find the car repair shop";
                missionUpdate.SetBool("IsOpen", false);
                Invoke("delay", 4f);
            }
            else if (QuestCounter == 3)
            {
                txtQuest.text = "Find the car repair shop";
                missionUpdate.SetBool("IsOpen", true);
                Invoke("animDelay", 7f);

            }
            else if (QuestCounter == 4)
            {
                missionUpdate.SetBool("IsOpen", false);
            }
            else if (QuestCounter == 5)
            {
                updateTXt.text = "Find the Mechanic book";
                txtQuest.text = "Find the Mechanic book";
                missionUpdate.SetBool("IsOpen", true);
            }
        }

        if (count.LevelAt == 5)
        {
            if (QuestCounter == 2)
            {
                updateTXt.text = "Find the restaurant";
                missionUpdate.SetBool("IsOpen", false);
                Invoke("delay", 4f);
            }
            else if (QuestCounter == 3)
            {
                txtQuest.text = "Find the car restaurant";
                missionUpdate.SetBool("IsOpen", true);
                Invoke("animDelay", 7f);

            }
            else if (QuestCounter == 4)
            {
                missionUpdate.SetBool("IsOpen", false);
            }
            else if (QuestCounter == 5)
            {
                updateTXt.text = "Find the Cook book";
                txtQuest.text = "Find the Cook book";
                missionUpdate.SetBool("IsOpen", true);
            }
        }

        if (count.LevelAt == 6)
        {
            if (QuestCounter == 2)
            {
                updateTXt.text = "Find the warehouse";
                missionUpdate.SetBool("IsOpen", false);
                Invoke("delay", 4f);
            }
            else if (QuestCounter == 3)
            {
                txtQuest.text = "Find the car warehouse";
                missionUpdate.SetBool("IsOpen", true);
                Invoke("animDelay", 7f);

            }
            else if (QuestCounter == 4)
            {
                missionUpdate.SetBool("IsOpen", false);
            }
            else if (QuestCounter == 5)
            {
                updateTXt.text = "Find the Defense book";
                txtQuest.text = "Find the Defense book";
                missionUpdate.SetBool("IsOpen", true);
            }
        }

        if (count.LevelAt == 7)
        {
            if (QuestCounter == 2)
            {
                updateTXt.text = "Find the generator";
                missionUpdate.SetBool("IsOpen", false);
                Invoke("delay", 4f);
            }
            else if (QuestCounter == 3)
            {
                txtQuest.text = "Find the generator";
                missionUpdate.SetBool("IsOpen", true);
                Invoke("animDelay", 7f);

            }
        }

    }

    public void delay()
    {
        QuestCounter = 3;
    }


    void animDelay()
    {
        QuestCounter = 4;
    }
}
