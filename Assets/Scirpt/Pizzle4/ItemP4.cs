using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemP4 : MonoBehaviour
{
    public ItemCheckerP4 item;

    public bool[] correctAnswers = new bool[17];

    public void Start()
    {
        bool[] itemAnswers = {
            item.P4Ans1, item.P4Ans2, item.P4Ans3, item.P4Ans4,
            item.P4Ans5, item.P4Ans6, item.P4Ans7, item.P4Ans8,
            item.P4Ans9, item.P4Ans10, item.P4Ans11, item.P4Ans12,
            item.P4Ans13, item.P4Ans14, item.P4Ans15, item.P4Ans16,
            item.P4Ans17
        };

        for (int i = 0; i < correctAnswers.Length; i++)
        {
            correctAnswers[i] = itemAnswers[i];
        }
    }
}
