using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverFix : MonoBehaviour
{
    private Button button;

    //public string color;
    //public Image Image;
    public void Start()
    {
        button = GetComponent<Button>();
    }
    public void Drag()
    {
        ColorBlock colorBlock = button.colors;

        // Modify the normalColor
        colorBlock.normalColor = Color.white;

        // Assign the updated ColorBlock back to the button
        button.colors = colorBlock;
    }

    public void Enter()
    {
        ColorBlock colorBlock = button.colors;

        // Modify the normalColor
        colorBlock.highlightedColor = Color.grey;

        // Assign the updated ColorBlock back to the button
        button.colors = colorBlock;
        //mage.color = Color.grey;
    }

    public void SetHighlightedColor(string colorHex)
    {
        ColorBlock colorBlock = button.colors;

        // Try to parse the hex color string
        if (ColorUtility.TryParseHtmlString(colorHex, out Color parsedColor))
        {
            colorBlock.normalColor = parsedColor; // Set the highlighted color
            button.colors = colorBlock;              // Apply the modified ColorBlock
        }
        else
        {
            Debug.LogError("Invalid color string: " + colorHex);
        }
    }

    public void SetHighligtColor(string colorHex)
    {
        ColorBlock colorBlock = button.colors;

        // Try to parse the hex color string
        if (ColorUtility.TryParseHtmlString(colorHex, out Color parsedColor))
        {
            colorBlock.highlightedColor = parsedColor; // Set the highlighted color
            button.colors = colorBlock;              // Apply the modified ColorBlock
        }
        else
        {
            Debug.LogError("Invalid color string: " + colorHex);
        }
    }
    public void Exit()
    {
        ColorBlock colorBlock = button.colors;

        // Modify the normalColor
        colorBlock.highlightedColor = Color.white;

        // Assign the updated ColorBlock back to the button
        button.colors = colorBlock;
    }
}
