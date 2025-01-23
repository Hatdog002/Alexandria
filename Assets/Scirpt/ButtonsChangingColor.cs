using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsChangingColor : MonoBehaviour
{
    public Button button;
    public Image buttonImage;

    public float timer = 6;
    public float transitionDuration = 1f;

    private Coroutine transitionCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 6 && timer >= 4)
        {
            color1();
            timer -= Time.deltaTime;
        }
        else if (timer <= 4 && timer >= 2)
        {
            color2();
            timer -= Time.deltaTime;
        }
        else if (timer <= 2 && timer >= 0)
        {
            color3();
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 6;
        }
    }

    void color1()
    {
        StartColorTransition(Color.red);
    }

    void color2()
    {
        StartColorTransition(Color.green);
    }

    void color3()
    {
        StartColorTransition(Color.yellow);
    }
    private void StartColorTransition(Color targetColor)
    {
        // Stop any ongoing transition
        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }

        // Start the new transition
        transitionCoroutine = StartCoroutine(TransitionColor(targetColor));
    }

    private System.Collections.IEnumerator TransitionColor(Color targetColor)
    {
        Color startColor = buttonImage.color;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            buttonImage.color = Color.Lerp(startColor, targetColor, elapsedTime / transitionDuration);
            yield return null;  // Wait for the next frame
        }

        // Ensure the final color is set
        buttonImage.color = targetColor;
    }
}
