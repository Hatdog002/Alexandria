using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public string questionText; // Text of the question
    public string[] choices; // Array of choices for the question
    public Button button;
    public int correctAnswerIndex;
}

public class RandomQuestionGenerator : MonoBehaviour
{
    public Question[] questions; // Array to hold questions and choices

    public Question GetRandomQuestion()
    {
        if (questions.Length > 0)
        {
            // Generate a random index to select a question from the array
            int randomIndex = Random.Range(0, questions.Length);

            // Return the randomly selected question
            return questions[randomIndex];
        }
        else
        {
            Debug.LogError("No questions found in the array!");
            return null;
        }
    }
}
