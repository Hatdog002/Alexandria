using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG : MonoBehaviour
{
    public TutorialManager TutorialManager;

    public GameObject ButtonSkipTutorial;
    public GameObject ButtonAddHealth;

    public GameObject ButtonSkipBattle;

    public GameObject ButtonSkipPuzzle;

    public BattleStates states;

    public QuestionUi UI;

    public ViewBook isBook;
    // Start is called before the first frame update
    void Start()
    {
        states = UI.states;
    }

    // Update is called once per frame
    void Update()
    {
        if (TutorialManager.EndTutorial)
        {
            ButtonSkipTutorial.gameObject.SetActive(true);
        }
        else if (!TutorialManager.tutorialDone)
        {
            ButtonSkipTutorial.gameObject.SetActive(false);
        }

        if (TutorialManager.Enemy)
        {
            ButtonAddHealth.gameObject.SetActive(true);
        }

        if(UI.states == BattleStates.PlayerTurn)
        {
            ButtonSkipBattle.gameObject.SetActive(true);
        }

        if (isBook.Isbbook)
        {
            ButtonSkipPuzzle.gameObject.SetActive(true);
        }
    }
}
