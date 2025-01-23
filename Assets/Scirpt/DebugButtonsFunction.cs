using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButtonsFunction : MonoBehaviour
{

    public TutorialManager manager;

    public QuestSetUp counter;

    public GameObject Tuto;

    public GameObject HP;

    public GameObject Mission;

    public Unit Player;

    public QuestionUi dEBUG;

    public PuzzleManager managerP;

    public GameObject arrow;
   public void SkipTutorial()
    {
        counter.QuestCounter = 1;
        manager.tutorialDone = true;
        HP.gameObject.SetActive(true);
        Mission.gameObject.SetActive(true);
        manager.ClosePanel();
        Tuto.gameObject.SetActive(false);
        manager.Istop = false;
        arrow.gameObject.SetActive(false);
        manager.Enemy = true;
    }

    public void HPADD()
    {
        Player.currentHp += 5;
    }

    public void SkipBattle()
    {
        dEBUG.states = BattleStates.Won;
        dEBUG.EndBattle();
    }

    public void SkipPuzzle()
    {
        managerP.thePuzzleOver = true;
    }
}
