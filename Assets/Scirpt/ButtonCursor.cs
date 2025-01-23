using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Texture2D customCursor;
    private bool isPointerOver = false;  // To track if the pointer is over the button
    private float pointerStayTime = 0f;  // Timer to track how long the pointer stays over the button
    public float pointerStayThreshold = 1f;  // Threshold time to trigger an action when pointer stays over the button

    

    void Update()
    {
        // If the pointer is over the button, increment the timer
        if (isPointerOver)
        {
            pointerStayTime += Time.deltaTime;

            // If the pointer stays long enough (after threshold), perform an action
            if (pointerStayTime >= pointerStayThreshold)
            {
                // You can perform actions here, like changing the cursor or something else
                Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
            }
        }

        if (!gameObject.activeSelf)
        {
            isPointerOver = false;  // Pointer is no longer over the button
            pointerStayTime = 0f;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    // When the pointer enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;  // Pointer is over the button
        pointerStayTime = 0f;  // Reset the timer

        // Set the cursor to the custom one when hovering over the button
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);  // Custom cursor
    }

    // When the pointer exits the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;  // Pointer is no longer over the button
        pointerStayTime = 0f;  // Reset the timer

        // Reset to default system cursor when the pointer exits the button
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);  // Reset to default cursor
    }

    // When the pointer clicks the button
    public void OnPointerClick(PointerEventData eventData)
    {
        // Reset to the default system cursor when the pointer clicks
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);  // Reset to default cursor
    }
}
