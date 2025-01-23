using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemP5 : MonoBehaviour
{
    public ItemCheckerP5 item;

    public bool[] correctAnswers = new bool[7];

    public void Start()
    {
        bool[] itemAnswers = {
            item.P4Ans1, item.P4Ans2, item.P4Ans3, item.P4Ans4,
            item.P4Ans5,item.P4Ans6
        };

        for (int i = 0; i < correctAnswers.Length; i++)
        {
            correctAnswers[i] = itemAnswers[i];
        }
    }
}
