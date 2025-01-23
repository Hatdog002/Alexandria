using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemChecker item;

    public bool correctAnswer1;
    public bool correctAnswer2;
    public bool correctAnswer3;
    public bool correctAnswer4;
    public bool correctAnswer5;
    public bool correctAnswer6;



    public void Start()
    {
        if (item.Answer1 == true)
        {
            correctAnswer1 = true;
        }

        if(item.Answer2== true)
        {
            correctAnswer2 = true;
        }

        if (item.Answer3 == true)
        {
            correctAnswer3 = true;
        }
        if (item.Answer4 == true)
        {
            correctAnswer4 = true;
        }
        if (item.Answer5 == true)
        {
            correctAnswer5 = true;
        }
        if (item.Answer6 == true)
        {
            correctAnswer6 = true;
        }

    }
}
