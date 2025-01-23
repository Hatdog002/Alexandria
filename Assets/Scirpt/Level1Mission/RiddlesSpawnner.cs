using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceButton
{
    public Button button;
    public int correctAnswerIndex;
}
public class RiddlesSpawnner : MonoBehaviour
{
    public TextMeshProUGUI questionText;


    public Button[] choiceButtons;

    private List<ChoiceButton> choiceButtonDataList = new List<ChoiceButton>();

    public RandomQuestionGenerator questionGenerator;
    public bool correctAns;

    public GameObject toActivate;


    public PlayerMovementTutorial canMove;
    public CamHolder canlook;

    public GameObject toDeactivate;


    public GameObject UIRiddles;


    public LevelManager Manager;

    public FollowManager Manager2;

    public KeyLevel1 falseRiddle;
   
    public void Start()
    {
     
        DisplayRandomQuestion();
    }

    public void Update()
    {
       
    }
    public void DisplayRandomQuestion()
    {
        Question randomQuestion = questionGenerator.GetRandomQuestion();

        if (randomQuestion != null)
        {
            // Display the randomly selected question
            questionText.text = randomQuestion.questionText;

            foreach (ChoiceButton buttonData in choiceButtonDataList)
            {
                buttonData.button.onClick.RemoveAllListeners();
            }
            choiceButtonDataList.Clear();
            // Display the choices
            for (int i = 0; i < choiceButtons.Length; i++)
            {
                if (i < randomQuestion.choices.Length)
                {
                    // Set the choice text
                    choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = randomQuestion.choices[i];

                    // Add listener to the button to check if it's the correct answer
                    int correctAnswerIndex = randomQuestion.correctAnswerIndex;
                    choiceButtons[i].onClick.AddListener(() => CheckAnswer(correctAnswerIndex));

                    ChoiceButton buttonData = new ChoiceButton();
                    buttonData.button = choiceButtons[i];
                    buttonData.correctAnswerIndex = correctAnswerIndex;
                    choiceButtonDataList.Add(buttonData);
                }
                else
                {
                    // Clear any extra choice texts
                    choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
                }
                

            }
        }
    }
    void CheckAnswer(int correctAnswerIndex)
    {
        int selectedChoiceIndex = -1;
        for (int i = 0; i < choiceButtonDataList.Count; i++)
        {
            if (choiceButtonDataList[i].button == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>())
            {
                selectedChoiceIndex = i;
                break;
            }
        }

        if (selectedChoiceIndex == correctAnswerIndex)
        {
            toDeactivate.gameObject.SetActive(false);
            toActivate.gameObject.SetActive(true);
               
            


        }
        else
        {
            DisplayRandomQuestion();
        }
    }

    public void Exit()
    {
        DisplayRandomQuestion();

        toActivate.gameObject.SetActive(false);
      
        toDeactivate.gameObject.SetActive(true);

        UIRiddles.gameObject.SetActive(false);

        playerMoves();

        falseRiddle.checker = false;
        
        Manager.key3 = false;
        Manager.key4 = false;
        Manager.key5 = false;
        Manager.key6 = false;

    }

    void Delay()
    {
        DisplayRandomQuestion();
    }

    void DelayUI()
    {
        UIRiddles.gameObject.SetActive(true);
        Manager.turnOn = false;
    }
    void playerMoves()
    {
        Manager2.code = false;
        Manager2.canFollow = true;
        canMove.Movement1();
    }
}
