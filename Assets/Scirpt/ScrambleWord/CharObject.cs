using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharObject : MonoBehaviour
{
    public char character;
    public TextMeshProUGUI text;
    public Image image;
    public RectTransform rectTransform;
    public int index;


    [Header("Appearance")]
    public Color normalColor;
    public Color selectedColor;


    bool isSelected = false;
    public CharObject Init(char c)
    {
        character = c;
        text.text = c.ToString();
        gameObject.SetActive(true);
        return this;
    }
    

    public void Select()
    {
        isSelected = !isSelected;

        image.color = isSelected ? selectedColor : normalColor;

        if (isSelected)
        {
            WordScramble.Main.Select(this);
        }
        else
        {
            WordScramble.Main.UnSelect();
        }
    }
}
